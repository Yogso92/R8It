using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public interface IFollowService 
    {
        IEnumerable<DbFollow> GetFollowers(int followedId);
        IEnumerable<DbFollow> GetFollowed(int followerId);
        bool Follow(int followerId, int followedId);
        bool Unfollow(int followerId, int followedId);
    }
}
