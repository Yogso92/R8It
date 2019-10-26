using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public class VisibilityLimitRepository : IVisibilityLimitRepository
    {
        #region singleton pattern
        private Connection _connection;
        private static VisibilityLimitRepository _instance;
        public static VisibilityLimitRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new VisibilityLimitRepository();
                }
                return _instance;
            }
        }
        public VisibilityLimitRepository()
        {
            _connection = new Connection(Environment.GetEnvironmentVariable("connectionString"), "System.Data.SqlClient");
        }
        #endregion
        public DbVisibilityLimit Get(int id)
        {
            return null;
        }
        public DbVisibilityLimit Create(DbVisibilityLimit limit)
        {
            Command cmd = new Command("INSERT INTO VisibilityLimit(UploadId, CountryId) OUTPUT inserted.* VALUES (@uploadid, @countryid)");
            cmd.SetParameters(limit);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbVisibilityLimit>).FirstOrDefault();
        }

        public IEnumerable<DbVisibilityLimit> GetAll()
        {
            Command cmd = new Command("SELECT * FROM VisibilityLimit");
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbVisibilityLimit>);
        }
        public IEnumerable<DbVisibilityLimit> GetUploadLimits(int uploadId)
        {
            Command cmd = new Command("SELECT * FROM VisibilityLimit WHERE UploadId = @uploadid");
            cmd.AddParameter("uploadid", uploadId);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbVisibilityLimit>);
        }
        public bool Delete(DbVisibilityLimit limit)
        {
            Command cmd = new Command("DELETE * FROM VisibilityLimit WHERE UploadId = @uploadid AND CountryId = @countryid");
            cmd.SetParameters(limit);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
