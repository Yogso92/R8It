using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using Toolbox.Mappers;

namespace DAL
{
    public class UserService // singleton
    {
        #region singleton pattern
        private Connection _connection;
        private static UserService _instance;
        public static UserService Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new UserService();
                }
                return _instance;
            }
        }
        public UserService()
        {
            Console.WriteLine("UserService ctor");
            _connection = new Connection(@"Data Source = TECHNOBEL\; Initial Catalog = R8It; User ID = sa; Password = test1234=", "System.Data.SqlClient");
        }
        #endregion
        
        public DbUser Login(string email, string pw)
        {
            Command cmd = new Command("SP_Login", true);
            cmd.AddParameter("email", email);
            cmd.AddParameter("password", pw);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbUser>).FirstOrDefault();

        }

        public bool Register(DbUser user)
        {
            Command cmd = new Command("SP_Register", true);
            cmd.AddParameter("nickname", user.Nickname);
            cmd.AddParameter("birthdate", user.Birthdate);
            cmd.AddParameter("email", user.Email);
            cmd.AddParameter("password", user.Password);
            cmd.AddParameter("countryid", user.CountryId);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<DbUser> GetAll()
        {
            Command cmd = new Command("SELECT Id, RoleId, Nickname, Birthdate, Email, CountryId FROM [User]");
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbUser>);

        }
        public bool Update(DbUser user)
        {
            Command cmd = new Command("UPDATE [User] SET RoleId = @roleid, Nickname = @nickname, Birthdate = @birthdate, CountryId = @countryid WHERE Id = @id ");
            cmd.SetParameters(user);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

    }
}
