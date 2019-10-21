using DAL;
using DbEntities;
using System;
using System.Collections.Generic;
using Tools;
using Provider = DAL.DALService;

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
        public int CountryId { get; set; }
        public int RoleId { get; set; }

        public Country Country
        {
            get; set;
        }
        public Role Role
        {
            get; set;
        }
        public IEnumerable<User> Following { get;  set; }
        public IEnumerable<User> FollowedBy { get;  set; }
        public IEnumerable<Category> FollowedCategories { get;  set; } 
        public void EditCountry(Country country)
        {
            CountryId = country.Id;
        }
    }
}
