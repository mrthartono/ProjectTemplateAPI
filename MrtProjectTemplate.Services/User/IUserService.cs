using MrtProjectTemplate.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrtProjectTemplate.Services.User
{
    public interface IUserService
    {
        UserResponse GenerateJwtToken(UserRequest userRequest);
        Task<UserListResponse> GetListUserAsync(UserListRequest userListRequest);
    }
}
