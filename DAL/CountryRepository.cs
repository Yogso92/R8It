using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public class CountryRepository : ICountryRepository
    {
        #region singleton pattern
        private Connection _connection;
        private static ICountryRepository _instance;
        public static ICountryRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new ICountryRepository();
                }
                return _instance;
            }
        }
        public ICountryService()
        {
            Console.WriteLine("UserService ctor");
            _connection = new Connection(@"Data Source = TECHNOBEL\; Initial Catalog = R8It; User ID = sa; Password = test1234=", "System.Data.SqlClient");
        }
        #endregion

        public DbCountry Get(int id)
        {
            Command cmd = new Command("SELECT * FROM Country WHERE Id = @id");
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbCountry>).FirstOrDefault();
        }

        public IEnumerable<DbCountry> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Country");
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbCountry>);
        }

    }
}
