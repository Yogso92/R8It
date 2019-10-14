using DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ICategoryService
    {
        DbCategory Get(int id);

        IEnumerable<DbCategory> GetAll();
        DbCategory Insert(DbCategory category);
    }
}
