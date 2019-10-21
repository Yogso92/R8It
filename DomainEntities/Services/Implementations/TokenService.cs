using DomainEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using R8It_Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace R8It_Domain.Services.Implementations
{
    public class TokenService : ITokenService
    {

        private JwtSecurityTokenHandler _Handler;
        private SymmetricSecurityKey _SecurityKey;
        private readonly IConfiguration _Configuration;
        public TokenService(IConfiguration configuration)
        {
            _Configuration = configuration;
            _Handler = new JwtSecurityTokenHandler();
            _SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["jwt:key"]));
        }
        public string GenerateToken(User user)
        {
            SigningCredentials credentials = new SigningCredentials(_SecurityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                "webAPI",
                "front end angular",
                new List<Claim> {
                new Claim("email", user.Email),
                new Claim("role", user.Role.Name) },
                DateTime.Now,
                DateTime.Now.AddYears(1),
                credentials
                );
            return _Handler.WriteToken(token);
        }
        public ClaimsPrincipal ValidateToken(string token) // si token non valide, renvois un null
        {
            return _Handler.ValidateToken(
                token,
                new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "webAPI",
                    ValidAudience = "front end ionic",
                    RequireSignedTokens = true,
                    IssuerSigningKey = _SecurityKey
                },
                out SecurityToken validatedToken);

        }
     
    }
}
