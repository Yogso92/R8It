using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public interface IRoleRepository
    {
        public DbRole Get(int id);

        public IEnumerable<DbRole> GetAll();
        public DbRole Insert(DbCategory category);
    }
}
