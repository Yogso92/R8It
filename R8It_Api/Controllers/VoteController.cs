using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R8It_Api.Models;
using R8It_Domain.Services.Interfaces;
using Tools;

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
        public double Submit([FromBody]VoteModel vote)
        {
            _voteService.AddVote(vote.Map<Vote>());
            return _voteService.GetResult(vote.UploadId);
        }
        [HttpGet("canvote/{userId}/{uploadId}")]
        public bool CanVote(int userId, int uploadId)
        {
            return _voteService.CanVote(userId, uploadId);
        }
    }
}