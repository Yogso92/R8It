using System;
using System.Collections.Generic;
using System.Text;

namespace DbEntities
{
    public abstract class TEntity<T>
    {
        public T Id { get; set; }
    }
}
