using DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ICategoryRepository
    {
        DbCategory Get(int id);

        IEnumerable<DbCategory> GetAll();
        DbCategory Insert(DbCategory category);
    }
}
