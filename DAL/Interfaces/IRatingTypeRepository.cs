using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public interface IRatingTypeRepository { 
        DbRatingType Get(int id);
        IEnumerable<DbRatingType> GetAll();

        DbRatingType Insert(DbRatingType item);
        bool Delete(int id);
        DbRatingType Update(DbRatingType item);

    }
}
