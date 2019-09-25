using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DB;
using DbEntities;
using Toolbox.Mappers;

namespace DAL
{
    public class CategoryService
    {
        #region singleton pattern
        private Connection _connection;
        private static CategoryService _instance;
        public static CategoryService Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new CategoryService();
                }
                return _instance;
            }
        }
        public CategoryService()
        {
            Console.WriteLine("UserService ctor");
            _connection = new Connection(@"Data Source = TECHNOBEL\; Initial Catalog = R8It; User ID = sa; Password = test1234=", "System.Data.SqlClient");
        }
        #endregion

        public DbCategory Get(int id)
        {
            Command cmd = new Command("SELECT * FROM Country WHERE Id = @id");
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbCategory>).FirstOrDefault();
        }

        public IEnumerable<DbCategory> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Country");
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
