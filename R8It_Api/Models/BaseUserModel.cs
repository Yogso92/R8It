using DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace R8It_Api.Models
{
    public class BaseUserModel
    {
        public int Id { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Country Country { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

    }
}
