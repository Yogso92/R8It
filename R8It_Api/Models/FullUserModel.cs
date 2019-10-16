using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R8It_Api.Models
{
    public class FullUserModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public IEnumerable<BaseUserModel> Following { get; set; }
        public IEnumerable<BaseUserModel> FollowedBy { get; set; }
        public IEnumerable<CategoryModel> FollowedCategories { get; set; }
    }
}
