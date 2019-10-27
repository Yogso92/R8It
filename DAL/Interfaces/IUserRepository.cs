using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using Toolbox.Mappers;

namespace DAL
{
    public interface IUserRepository 
    {

        DbUser Login(string email, string pw);

        DbUser Register(DbUser user);

        IEnumerable<DbUser> GetAll();
        bool Update(DbUser user);
        DbUser Get(int id);

    }
}
