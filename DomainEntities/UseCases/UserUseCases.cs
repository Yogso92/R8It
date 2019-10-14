using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DbEntities;
using DomainEntities;
using Tools;
using Provider = DAL.DALService;

namespace R8It_Domain.UseCases
{
    public static class UserUseCases
    {
        public static User Register(User user)
        {
            return Provider.GetService<UserService>().Register(user.Map<DbUser>()).Map<User>();
        }
        public static User Login(string email, string password)
        {
            return Provider.GetService<UserService>().Login(email, password).Map<User>();
        }
        public static User UpdateInfos(User user)
        {
            return Provider.GetService<UserService>().Update(user.Map<DbUser>()).Map<User>();
        }
    }
}
