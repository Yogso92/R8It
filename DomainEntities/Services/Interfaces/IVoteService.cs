using DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace R8It_Domain.Services.Interfaces
{
    public interface IVoteService
    {
        IEnumerable<Vote> GetVotes(int uploadId);
        Vote AddVote(Vote vote);
        double GetResult(int uploadId);
        bool CanVote(int userId, int uploadId);

    }
}
