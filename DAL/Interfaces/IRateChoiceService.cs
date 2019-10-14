using DbEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DB;
using Toolbox.Mappers;

namespace DAL
{
    public interface IRateChoiceService
    {
        DbRateChoice Get(int id);
        IEnumerable<DbRateChoice> GetChoices(int ratingTypeId);

        DbRateChoice Insert(DbRateChoice choice);
        bool Delete(int id);
        DbRateChoice Update(DbRateChoice choice);

        

    }
}
