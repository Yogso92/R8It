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
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        [AllowAnonymous]
        public List<Country> Get()
        {

            return _countryService.Get().ToList();
        }
    }
}