using DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IService<T> where T:TEntity<int>
    {
        T Get(int id);
    }
}
