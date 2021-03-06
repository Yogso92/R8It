﻿using DB;
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
        private static VoteRepository _instance;
        public static VoteRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new VoteRepository();
                }
                return _instance;
            }
        }
        public VoteRepository()
        {
            _connection = new Connection(Environment.GetEnvironmentVariable("connectionString"), "System.Data.SqlClient");
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
