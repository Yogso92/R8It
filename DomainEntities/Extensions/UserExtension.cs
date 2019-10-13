using DAL;
using DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;
using Provider = DAL.DALService;

namespace R8It_Domain.Extensions
{
    public static class UserExtension
    {
        public static void ChangeCountry(this User user, Country country)
        {
            user.Country = country;
        }
        public static void Unfollow(this User user, User unfollowed)
        {
            Provider.GetService < FollowService>().Unfollow(user.Id, unfollowed.Id);
            //forces refresh of lazy loading
            user.Following = null;
        }
        public static void Follow(this User user, int followid)
        {
            Provider.GetService<FollowService>().Follow(user.Id, followid);
            user.Following = null;
        }

    }
}
