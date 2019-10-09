﻿using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public class UploadService
    {
        #region singleton pattern
        private Connection _connection;
        private static UploadService _instance;
        public static UploadService Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new UploadService();
                }
                return _instance;
            }
        }
        public UploadService()
        {
            _connection = new Connection(@"Data Source = TECHNOBEL\; Initial Catalog = R8It; User ID = sa; Password = test1234=", "System.Data.SqlClient");
        }
        #endregion

        public DbUpload Get(int id)
        {
            Command cmd = new Command("SELECT * FROM Upload WHERE Id = @id");
            cmd.AddParameter("id", id);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbUpload>).FirstOrDefault();
        }
        public IEnumerable<DbUpload> GetAllFromUser(int id)
        {
            Command cmd = new Command("SELECT * FROM Upload WHERE UserId = @id");
            cmd.AddParameter("id", id);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbUpload>);
        }

        public IEnumerable<DbUpload> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Upload");
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbUpload>);
        }

        public DbUpload Update(DbUpload upload)
        {
            Command cmd = new Command("UPDATE Upload OUTPUT inserted.* SET Context = @context, CategoryId = @categoryid, [File] = @file, LimitDate = @limitdate, Anonymous = @anonymous, Active = @active WHERE Id = @id" );
            cmd.SetParameters(upload);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbUpload>).FirstOrDefault();
        }
        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Upload WHERE Id = @id");
            cmd.AddParameter("id", id);
            return _connection.ExecuteNonQuery(cmd ) ==1;
        }
        public DbUpload Insert(DbUpload upload)
        {
            Command cmd = new Command("INSERT INTO Upload (Context, UserId, CategoryId, [File],  RatingTypeId, Anonymous) OUTPUT inserted.* VALUES (@context, @userid, @categoryid, CONVERT(VARBINARY(MAX), @file),  @ratingtypeid, @anonymous)");
            cmd.SetParameters(upload);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbUpload>).FirstOrDefault();
        }

    }
}
