using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public interface ICountryService
    {
        public DbCountry Get(int id);

        public IEnumerable<DbCountry> GetAll();

    }
}
