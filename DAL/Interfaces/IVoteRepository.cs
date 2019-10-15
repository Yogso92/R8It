using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public interface IVoteRepository
    {
        DbVote Insert(DbVote vote);
        IEnumerable<DbVote> GetVotes(int uploadid);
        IEnumerable<DbVote> GetAll();
        DbVote Get(int id);
        bool Delete(int id);
    }
}
