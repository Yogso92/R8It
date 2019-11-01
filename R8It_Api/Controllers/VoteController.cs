using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R8It_Domain.Services.Interfaces;

namespace R8It_Api.Controllers
{   
    [Route("api/[controller]")]
    [Authorize]
    public class VoteController : Controller
    {
        private readonly IVoteService _voteService;
        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }
        [HttpPost]
        public IEnumerable<Vote> Submit(Vote vote)
        {
            _voteService.AddVote(vote);
            return _voteService.GetVotes(vote.UploadId);
        }
        [HttpGet("hasvoted/{userId}/{uploadId}")]
        public bool HasVoted(int userId, int uploadId)
        {
            return _voteService.HasVoted(userId, uploadId);
        }
    }
}