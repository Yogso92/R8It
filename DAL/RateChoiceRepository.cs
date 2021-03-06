﻿using DbEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DB;
using Toolbox.Mappers;

namespace DAL
{
    public class RateChoiceRepository : IRateChoiceRepository
    {
        #region singleton pattern
        private Connection _connection;
        private static RateChoiceRepository _instance;
        public static RateChoiceRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new RateChoiceRepository();
                }
                return _instance;
            }
        }
        public RateChoiceRepository()
        {
            _connection = new Connection(Environment.GetEnvironmentVariable("connectionString"), "System.Data.SqlClient");
        }
        #endregion
        public DbRateChoice Get(int id)
        {
            Command cmd = new Command("SELECT * FROM RateChoice WHERE Id = @id");
            cmd.AddParameter("id", id);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbRateChoice>).FirstOrDefault();
        }
        public IEnumerable<DbRateChoice> GetChoices(int ratingTypeId)
        {
            Command cmd = new Command("SELECT * FROM RateChoice WHERE RatingTypeId = @ratingtypeid");
            cmd.AddParameter("ratingtypeid", ratingTypeId);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbRateChoice>);
        }

        public DbRateChoice Insert(DbRateChoice choice)
        {
            Command cmd = new Command("INSERT INTO RateChoice (RatingTypeId, Text, [Value]) OUTPUT inserted.* VALUES (@ratingtypeid, @text, @value)");
            cmd.SetParameters(choice);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbRateChoice>).FirstOrDefault() ;
        }
        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM RateChoice WHERE Id = @id");
            cmd.AddParameter("id", id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }
        public DbRateChoice Update(DbRateChoice choice)
        {
            Command cmd = new Command("UPDATE RateChoice SET RatingTypeId = @ratingtypeid, Text = @text, [Value] = @value OUTPUT inserted.* WHERE Id = @id");
            cmd.SetParameters(choice);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbRateChoice>).FirstOrDefault();
        }

        

    }
}
