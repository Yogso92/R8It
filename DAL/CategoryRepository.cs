using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DB;
using DbEntities;
using Toolbox.Mappers;
using DAL.Interfaces;

namespace DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        #region singleton pattern
        private Connection _connection;
        private static CategoryRepository _instance;
        public static CategoryRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    Console.WriteLine("creating CategoryService");
                    return _instance = new CategoryRepository();
                }
                return _instance;
            }
        }
        public CategoryRepository()
        {
            _connection = new Connection(Environment.GetEnvironmentVariable("connectionString"), "System.Data.SqlClient");
        }
        #endregion

        public DbCategory Get(int id)
        {
            Command cmd = new Command("SELECT * FROM Category WHERE Id = @id");
            cmd.AddParameter("id", id);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbCategory>).FirstOrDefault();
        }

        public IEnumerable<DbCategory> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Category");
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbCategory>);
        }
        public DbCategory Insert(DbCategory category)
        {
            Command cmd = new Command("INSERT INTO Category(Name, Icon) OUTPUT inserted.* VALUES (@name, @icon)");
            cmd.SetParameters(category);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbCategory>).FirstOrDefault();
        }
    }
}
