using DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace R8It_Domain.Services.Interfaces
{
    public interface ICountryService
    {
        IEnumerable<Country> Get();
    }
}
