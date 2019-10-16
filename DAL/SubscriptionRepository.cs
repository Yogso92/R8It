using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Toolbox.Mappers;

namespace DAL
{
    public class SubscriptionRepository: ISubscriptionRepository
    {
        #region singleton pattern
        private Connection _connection;
        private static SubscriptionRepository _instance;
        public static SubscriptionRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new SubscriptionRepository();
                }
                return _instance;
            }
        }
        public SubscriptionRepository()
        {
            _connection = new Connection(@"Data Source = TECHNOBEL\; Initial Catalog = R8It; User ID = sa; Password = test1234=", "System.Data.SqlClient");
        }
        #endregion

        public IEnumerable<DbCategory> GetSubscriptions(int userId)
        {
            Command cmd = new Command("SELECT * FROM CATEGORY WHERE Id IN (SELECT CategoryId FROM Subscription WHERE UserId = @userid)");
            cmd.AddParameter("userid", userId);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbCategory>);
        }
        public IEnumerable<DbUser> GetSubscribers(int categoryId)
        {
            Command cmd = new Command("SELECT Id, RoleId, Nickname, Birthdate, Email, CountryId FROM [User] WHERE Id IN (SELECT UserId FROM Subscription WHERE CategoryId = @categoryid)");
            cmd.AddParameter("categoryId", categoryId);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbUser>);
        }
        public bool Subscribe(int userId, int categoryId)
        {
            Command cmd = new Command("INSERT INTO Subscription(UserId, CategoryId) VALUES (@userid, @categoryid)");
            cmd.AddParameter("categoryid", categoryId);
            cmd.AddParameter("userid", userId);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }
        public bool Unsubscribe(int userId, int categoryId)
        {
            Command cmd = new Command("DELETE FROM Subscription WHERE UserId = @userid AND CategoryId = @categoryid");
            cmd.AddParameter("categoryid", categoryId);
            cmd.AddParameter("userid", userId);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

    }
}
