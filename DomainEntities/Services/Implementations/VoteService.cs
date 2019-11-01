using DAL;
using DbEntities;
using DomainEntities;
using R8It_Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;

namespace R8It_Domain.Services.Implementations
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository VoteRepository;
        private readonly IUserRepository UserRepository;
        private readonly IRateChoiceRepository RateChoiceRepository;
        public VoteService(IVoteRepository voteRepository, IUserRepository userRepository, IRateChoiceRepository rateChoiceRepository)
        {
            VoteRepository = voteRepository;
            UserRepository = userRepository;
            RateChoiceRepository = rateChoiceRepository;
        }
        public Vote AddVote(Vote vote)
        {
            return VoteRepository.Insert(vote.Map<DbVote>()).Map<Vote>();
        }

        public double GetResult(int uploadId) //returns average score in percent
        {
            IEnumerable<Vote> votes = GetVotes(uploadId);
            return votes.Average(v => v.Rating.Value)/votes.Max(v => v.Rating.Value)*100;
        }

        public IEnumerable<Vote> GetVotes(int uploadId)
        {
            foreach(DbVote vote in VoteRepository.GetVotes(uploadId))
            {
                Vote retour = vote.Map<Vote>();
                retour.Voter = UserRepository.Get(retour.UserId).Map<User>();
                retour.Rating = RateChoiceRepository.Get(retour.RateChoiceId).Map<RateChoice>();
                yield return retour;
            }
        }
        public bool HasVoted(int userId, int uploadId)
        {
            return VoteRepository.GetVotes(uploadId).Where(v => v.Id == userId).FirstOrDefault() != null;
        }
    }
}
