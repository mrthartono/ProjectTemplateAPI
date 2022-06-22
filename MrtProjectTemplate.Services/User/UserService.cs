using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MrtProjectTemplate.Dapper.Concrete;
using MrtProjectTemplate.Models.Shared;
using MrtProjectTemplate.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MrtProjectTemplate.Services.User
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IDapperManager _dapperManager;
        public UserService(IDapperManager dapperManager, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings.Value));
            _dapperManager = dapperManager ?? throw new ArgumentNullException(nameof(dapperManager));

        }
        public UserResponse GenerateJwtToken(UserRequest userRequest)
        {
            //attention! validate your email first

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var exp = DateTime.Now.AddHours(12);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userRequest.Email) }),
                Expires = exp,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserResponse { Data = new RawUserResponse { BearerToken = tokenHandler.WriteToken(token), Expired = exp }, IsSuccess = true };

        }
        public async Task<UserListResponse> GetListUserAsync(UserListRequest userListRequest)
        {
            try
            {
                var SQL = $"SELECT * FROM USER WHERE 1=1 ";
                if (!string.IsNullOrWhiteSpace(userListRequest.search))
                {
                    SQL += $" AND FIRSTNAME LIKE '%{userListRequest.search}%' ";
                }
                SQL += $" ORDER BY {userListRequest.orderBy} {userListRequest.direction ?? "DESC"} OFFSET {userListRequest.skip} ROWS FETCH NEXT {userListRequest.take} ROWS ONLY; ";
                var userList = await _dapperManager.GetAll<RawUserListResponse>
                                (SQL, null, commandType: CommandType.Text);
                return new UserListResponse
                {
                    IsSuccess = true,
                    Data = userList
                };
            }
            catch
            {
                throw;
            }

        }
    }
}
