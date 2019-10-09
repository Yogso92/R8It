using System;
using System.Collections.Generic;

namespace DomainEntities
{
    public class User
    {
        //Db Fields
        public int Id { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Domain Fields
        //TODO lazy loading
        public Country Country { get; set; }
        public Role Role { get; set; }
        public IEnumerable<User> Following { get; set; }
        public IEnumerable<User> FollowedBy { get; set; }
        public IEnumerable<Category> FollowedCategories { get; set; }
        

    }
}
