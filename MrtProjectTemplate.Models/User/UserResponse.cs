using MrtProjectTemplate.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrtProjectTemplate.Models.User
{
    public class UserResponse :HttpCommonResponse
    {
        public RawUserResponse Data { get; set; }
    }
    public class RawUserResponse
    {
        public string BearerToken { get; set; }
        public DateTime Expired { get; set; }
    }
}
