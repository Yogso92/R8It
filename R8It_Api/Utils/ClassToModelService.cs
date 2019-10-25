using DAL;
using DomainEntities;
using R8It_Api.Models;
using R8It_Domain.Entities;
using R8It_Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools;

namespace R8It_Api.Utils
{
    public class ClassToModelService
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly ICountryRepository _countryRepository;
        private readonly IRatingService _ratingService;
        private readonly IVoteService _voteService;
        private readonly IRoleRepository _roleRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public ClassToModelService(IUserService userService, ICategoryService categoryService, ICountryRepository countryRepository, IRatingService ratingService, IVoteService voteService, IRoleRepository roleRepository, ISubscriptionRepository subscriptionRepository )
        {
            _userService = userService;
            _categoryService = categoryService;
            _countryRepository = countryRepository;
            _ratingService = ratingService;
            _voteService = voteService;
            _roleRepository = roleRepository;
            _subscriptionRepository = subscriptionRepository;
        }

        public BaseUserModel ToBaseUserModel(User user)
        {
            BaseUserModel model = user.Map<BaseUserModel>();
            //model.Country = _countryRepository.Get(user.CountryId).Name;
            model.Role = _roleRepository.Get(user.RoleId).Name;
            return model;
        }

        public FullUserModel GetFullUser(int id)
        {
            User origin = _userService.GetFullUser(id);
            FullUserModel model = ToBaseUserModel(origin).Map<FullUserModel>();
            model.FollowedCategories = origin.FollowedCategories.Select(c => ToCategoryModel(c));
            model.FollowedBy = origin.FollowedBy.Select(u => ToBaseUserModel(u));
            model.Following = origin.Following.Select(u => ToBaseUserModel(u));
            return model;
        }
        public CategoryModel ToCategoryModel(Category category)
        {
            CategoryModel model = category.Map<CategoryModel>();
            return model;
        }
        public UploadModel ToUploadModel(Upload upload)
        {
            UploadModel model = upload.Map<UploadModel>();
            model.Result = _voteService.GetResult(model.Id);
            return model;
        }
    }
}
