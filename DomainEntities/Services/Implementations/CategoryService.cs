using DAL;
using DAL.Interfaces;
using DbEntities;
using DomainEntities;
using R8It_Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;

namespace R8It_Domain.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository CategoryRepository;
        private readonly ISubscriptionRepository SubscriptionRepository;
        public CategoryService(ICategoryRepository categoryRepository, ISubscriptionRepository subscriptionRepository)
        {
            CategoryRepository = categoryRepository;
            SubscriptionRepository = subscriptionRepository;
        }
        public Category Get(int id)
        {
            return CategoryRepository.Get(id).Map<Category>();
        }

        public IEnumerable<Category> GetAll()
        {
            return CategoryRepository.GetAll().Select(c => c.Map<Category>());
        }

        public IEnumerable<Category> GetSubscribedCategories(int userid)
        {
            return SubscriptionRepository.GetSubscriptions(userid).Select(c => c.Map<Category>());
        }

        public Category Insert(Category category)
        {
            return CategoryRepository.Insert(category.Map<DbCategory>()).Map<Category>();
        }
    }
}
