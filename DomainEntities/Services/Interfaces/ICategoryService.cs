using DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace R8It_Domain.Services.Interfaces
{
    public interface ICategoryService
    {
        Category Get(int id);
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetSubscribedCategories(int userid);
        Category Insert(Category category);
    }
}
