﻿using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public class FollowService : IService<DbFollow>
    {
        #region singleton pattern
        private Connection _connection;
        private static FollowService _instance;
        public static FollowService Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new FollowService();
                }
                return _instance;
            }
        }
        public FollowService()
        {
            _connection = new Connection(@"Data Source = TECHNOBEL\; Initial Catalog = R8It; User ID = sa; Password = test1234=", "System.Data.SqlClient");
        }
        #endregion
        public DbFollow Get(int id)
        {
            return null;
        }
        public IEnumerable<DbFollow> GetFollowers(int followedId)
        {
            //Command cmd = new Command("SELECT Id, RoleId, Nickname, Birthdate, Email, CountryId FROM USER WHERE Id IN (SELECT FollowerId FROM Follow WHERE FollowingId = @followingid");
            Command cmd = new Command("SELECT FollowerId, FollowedId FROM Follow WHERE FollowedId = @followedid");

            cmd.AddParameter("followedid", followedId);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbFollow>);
        }
        public IEnumerable<DbFollow> GetFollowed(int followerId)
        {
            //Command cmd = new Command("SELECT Id, RoleId, Nickname, Birthdate, Email, CountryId FROM USER WHERE Id IN (SELECT FollowingId FROM Follow WHERE FollowerId = @followerid");
            Command cmd = new Command("SELECT FollowerId, FollowedId FROM Follow WHERE FollowerId = @followerid");
            cmd.AddParameter("followerid", followerId);
            return _connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<DbFollow>);
        }
        public bool Follow(int followerId, int followedId)
        {
            Command cmd = new Command("INSERT INTO Follow(FollowerId, FollowedId) VALUES (@followerid, @followedid)");
            cmd.AddParameter("followerid", followerId);
            cmd.AddParameter("followedid", followedId);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }
        public bool Unfollow(int followerId, int followedId)
        {
            Command cmd = new Command("DELETE FROM Follow WHERE FollowerId = @followerid AND FollowedId = @followedid");
            cmd.AddParameter("followerid", followerId);
            cmd.AddParameter("followedid", followedId);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
