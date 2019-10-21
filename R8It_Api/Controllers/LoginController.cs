using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using R8It_Api.Models;
using R8It_Domain.Services.Interfaces;
using Tools;

namespace R8It_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _UserService;
        private readonly IConfiguration _Configuration;
        private readonly ITokenService _TokenService;
        public LoginController(IUserService userService, IConfiguration configuration, ITokenService tokenService)
        {
            _UserService = userService;
            _Configuration = configuration;
            _TokenService = tokenService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel model)
        {
            IActionResult result = this.Unauthorized();
            if (model != null)
            {
                User user = _UserService.Login(model.Email, model.Password);
                if (user == null) return result;
                BaseUserModel logged = _UserService.Get(user.Id).Map<BaseUserModel>();
                logged.Token = this.CreateToken(user);
                result = this.Ok(logged);
            }
            return result;
        }

        [HttpGet("{n}", Name = "GetUser")]
        public User Get(int n)
        {
            return _UserService.GetFullUser(n);
        }



        private string CreateToken(User user)
        {
            

            return _TokenService.GenerateToken(user);
        }
    }
}