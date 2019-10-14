using System;
using System.Collections.Generic;
using System.Text;

namespace DbEntities
{
    public class DbSubscription : TEntity<int>
    {
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
