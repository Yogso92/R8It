using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R8It_Api.Models
{
    public class BaseUserModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }

    }
}
