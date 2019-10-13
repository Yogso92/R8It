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

        //Domain Fields
        //TODO lazy loading
        private Country _Country;
        public Country Country
        {
            get
            {
                if(_Country == null)
                {
                    _Country = Provider.GetService<CountryService>().Get(CountryId).Map<Country>();
                }
                return Country;
            }
            internal set
            //{
            //    _Country = value;
            //}
            //TODO: handle edits here or in use cases?
            {
                _Country = value;
                CountryId = value.Id;
                Provider.GetService<UserService>().Update(this.Map<DbUser>());
            }
        }
        private Role _Role;
        public Role Role 
        {
            get 
            {
                if(_Role == null)
                {
                    _Role = Provider.GetService<RoleService>().Get(RoleId).Map<Role>();
                }
                return _Role;
            } 
            internal set
            {
                //TODO handle edit
                _Role = value;
                RoleId = value.Id;
                Provider.GetService<UserService>().Update(this.Map<DbUser>());
            } 
        }
        private IEnumerable<User> _Following;
        public IEnumerable<User> Following { get; internal set; }
        private IEnumerable<User> _FollowedBy;
        public IEnumerable<User> FollowedBy { get; internal set; }
        private IEnumerable<Category> _FollowedCategories;
        public IEnumerable<Category> FollowedCategories { get; internal set; } 
        

    }
}
