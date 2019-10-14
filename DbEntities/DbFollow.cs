using System;
using System.Collections.Generic;
using System.Text;

namespace DbEntities
{
    public class DbFollow : TEntity<int>
    {
        public int FollowerId { get; set; }
        public int FollowedId { get; set; }
    }
}
