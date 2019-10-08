using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public class RatingService
    {
        #region singleton pattern
        private Connection _connection;
        private static RatingService _instance;
        public static RatingService Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new RatingService();
                }
                return _instance;
            }
        }
        public RatingService()
        {
            _connection = new Connection(@"Data Source = TECHNOBEL\; Initial Catalog = R8It; User ID = sa; Password = test1234=", "System.Data.SqlClient");
        }
        #endregion

        public DbRatingType Get(int id)
        {
            Command cmd = new Command("SELECT * FROM RatingType WHERE Id = @id");
            cmd.AddParameter("id", id);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbRatingType>).FirstOrDefault();
        }
        public IEnumerable<DbRatingType> GetAll()
        {
            Command cmd = new Command("SELECT * FROM RatingType");
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbRatingType>);
        }

        public DbRatingType Insert(DbRatingType item)
        {
            Command cmd = new Command("INSERT INTO RatingType(Name, Definition) OUTPUT inserted.* VALUES (@name, @definition)");
            cmd.SetParameters(item);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbRatingType>).FirstOrDefault();
        }
        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM RatingType WHERE Id = @id");
            cmd.AddParameter("id", id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }
        public DbRatingType Update(DbRatingType item)
        {
            Command cmd = new Command("UPDATE RatingType SET Name = @name, Definition = @definition OUTPUT inserted.* ");
            cmd.SetParameters(item);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbRatingType>).FirstOrDefault();
        }

    }
}
