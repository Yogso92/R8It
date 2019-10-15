using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public class VoteRepository : IVoteRepository
    {
        #region singleton pattern
        private Connection _connection;
        private static IVoteRepository _instance;
        public static IVoteRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new IVoteRepository();
                }
                return _instance;
            }
        }
        public IVoteService()
        {
            _connection = new Connection(@"Data Source = TECHNOBEL\; Initial Catalog = R8It; User ID = sa; Password = test1234=", "System.Data.SqlClient");
        }
        #endregion

        public DbVote Insert(DbVote vote)
        {
            Command cmd = new Command("INSERT INTO Vote(UserId, UploadId, Comment, RateChoiceId) OUTPUT inserted.* VALUES (@userid, @uploadid, @comment, @ratechoiceid) ");
            cmd.SetParameters(vote);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbVote>).FirstOrDefault();
        }
        public IEnumerable<DbVote> GetVotes(int uploadid)
        {
            Command cmd = new Command("SELECT * FROM Vote WHERE UploadId = @uploadid");
            cmd.AddParameter("uploadid", uploadid);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbVote>);
        }
        public IEnumerable<DbVote> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Vote");
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbVote>);
        }
        public DbVote Get(int id)
        {
            Command cmd = new Command("SELECT * FROM Vote WHERE Id = @id");
            cmd.AddParameter("id", id);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbVote>).FirstOrDefault();
        }
        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Vote WHERE Id = @id");
            cmd.AddParameter("id", id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }


    }
}
