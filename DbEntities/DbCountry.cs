using System;
using System.Collections.Generic;
using System.Text;

namespace DbEntities
{
    public class DbCountry : TEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso { get; set; }
    }
}
