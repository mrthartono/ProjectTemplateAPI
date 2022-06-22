using MrtProjectTemplate.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrtProjectTemplate.Models.User
{
    public class UserListResponse : HttpCommonResponse
    {
        public List<RawUserListResponse> Data { get; set; }
    }
    public class RawUserListResponse
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
