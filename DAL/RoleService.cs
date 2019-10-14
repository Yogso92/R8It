﻿using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public class RoleService: IService<DbRole>
    {
        #region singleton pattern
        private Connection _connection;
        private static RoleService _instance;
        public static RoleService Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new RoleService();
                }
                return _instance;
            }
        }
        public RoleService()
        {
            _connection = new Connection(@"Data Source = TECHNOBEL\; Initial Catalog = R8It; User ID = sa; Password = test1234=", "System.Data.SqlClient");
        }
        #endregion

        public DbRole Get(int id)
        {
            Command cmd = new Command("SELECT * FROM Role WHERE Id = @id");
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbRole>).FirstOrDefault();
        }

        public IEnumerable<DbRole> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Role");
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbRole>);
        }
        public DbRole Insert(DbCategory category)
        {
            Command cmd = new Command("INSERT INTO Role(Name) OUTPUT inserted.* VALUES (@name)");
            cmd.SetParameters(category);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbRole>).FirstOrDefault();
        }
    }
}
