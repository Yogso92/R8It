using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R8It_Api.Models;
using R8It_Api.Utils;
using R8It_Domain.Services.Interfaces;
using Tools;

namespace R8It_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;
        //private readonly IClassToModelService _classToModelService;
        public RegisterController(IUserService userService /*,IClassToModelService classToModelService*/)
        {
            _userService = userService;
            //_classToModelService = classToModelService;
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody] BaseUserModel model)
        {
            IActionResult result = this.Problem();
            if (ModelState.IsValid)
            {
                try
                {
                    User toInsert = model.Map<User>();
                    toInsert.CountryId = model.Country.Id;
                    BaseUserModel body = _userService.Create(toInsert)
                                                        .Map<BaseUserModel>();
                    result = this.Ok(body);
                }
                catch (Exception ex)
                {
                    result = this.ValidationProblem();
                }
            }
            return result;
            
        }
        
    }
}