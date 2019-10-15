using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Toolbox.Mappers;

namespace DAL
{
    public interface ISubscriptionRepository
    {
        public IEnumerable<DbCategory> GetSubscriptions(int userId);
        public IEnumerable<DbUser> GetSubscribers(int categoryId);
        public bool Subscribe(int userId, int categoryId);
        public bool Unsubscribe(int userId, int categoryId);
    }
}
