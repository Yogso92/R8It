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
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<RatingType> GetAll()
        {
            return _ratingService.GetAll();
        }
        [HttpGet("{n}")]
        [AllowAnonymous]
        public RatingType Get(int n)
        {
            return _ratingService.Get(n);
        }
    }
}