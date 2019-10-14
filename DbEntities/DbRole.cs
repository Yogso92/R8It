using System;
using System.Collections.Generic;
using System.Text;

namespace DbEntities
{
    public class DbRole : TEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
