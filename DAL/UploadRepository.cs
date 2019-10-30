using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public class UploadRepository: IUploadRepository
    {
        #region singleton pattern
        private Connection _connection;
        private static UploadRepository _instance;
        public static UploadRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new UploadRepository();
                }
                return _instance;
            }
        }
        public UploadRepository()
        {
            _connection = new Connection(Environment.GetEnvironmentVariable("connectionString"), "System.Data.SqlClient");
        }
        #endregion

        public DbUpload Get(int id)
        {
            Command cmd = new Command("SELECT * FROM Upload WHERE Id = @id AND Deleted != 1");
            cmd.AddParameter("id", id);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbUpload>).FirstOrDefault();
        }
        public IEnumerable<DbUpload> GetAllFromUser(int id)
        {
            Command cmd = new Command("SELECT * FROM Upload WHERE UserId = @id AND Deleted != 1");
            cmd.AddParameter("id", id);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbUpload>);
        }
        public IEnumerable<DbUpload> GetAllFromCategory(int categoryId)
        {
            //TODO exclude uploads already voted on
            Command cmd = new Command("SELECT * FROM Upload WHERE CategoryId = @categoryid AND Deleted != 1");
            cmd.AddParameter("categoryid", categoryId);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbUpload>);
        }

        public IEnumerable<DbUpload> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Upload WHERE Deleted != 1");
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
