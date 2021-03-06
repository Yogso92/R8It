﻿using DB;
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
        private static CountryRepository _instance;
        public static CountryRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new CountryRepository();
                }
                return _instance;
            }
        }
        public CountryRepository()
        {
            Console.WriteLine("UserService ctor");
            _connection = new Connection(Environment.GetEnvironmentVariable("connectionString"), "System.Data.SqlClient");
        }
        #endregion

        public DbCountry Get(int id)
        {
            Command cmd = new Command("SELECT * FROM Country WHERE Id = @id");
            cmd.AddParameter("id", id);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbCountry>).FirstOrDefault();
        }

        public IEnumerable<DbCountry> GetAll()
        {
            Command cmd = new Command("SELECT Id, Alpha3 as [Iso], langEN as [Name] FROM Country");
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbCountry>);
        }

    }
}
