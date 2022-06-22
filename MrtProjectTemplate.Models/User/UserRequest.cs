using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrtProjectTemplate.Models.User
{
    public class UserRequest
    {
        [Required]
        public string Email { get; set; } 
    }
}