using DomainEntities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace R8It_Domain.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        ClaimsPrincipal ValidateToken(string token); // si token non valide, renvois un null
    }
}
