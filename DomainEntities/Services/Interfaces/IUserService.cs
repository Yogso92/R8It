using DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace R8It_Domain.Services.Interfaces
{
    public interface IUserService
    {
        User Update(User user);
        User Create(User user);
        User Get(int id);
        User Login(string email, string password);
        User GetFullUser(int id);
    }
}
