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
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly ISubscriptionRepository SubscriptionRepository;
        private readonly IFollowRepository FollowRepository;
        private readonly ICountryRepository CountryRepository;
        private readonly IRoleRepository RoleRepository;
        public UserService(IUserRepository userRepository, ISubscriptionRepository subscriptionRepository, IFollowRepository followRepository, ICountryRepository countryRepository, IRoleRepository roleRepository)
        {
            UserRepository = userRepository;
            SubscriptionRepository = subscriptionRepository;
            FollowRepository = followRepository;
            CountryRepository = countryRepository;
            RoleRepository = roleRepository;
        }
        public User Create(User user)
        {
            return UserRepository.Register(user.Map<DbUser>()).Map<User>();
        }

        public User Get(int id)
        {
            return UserRepository.Get(id).Map<User>();
        }

        public User Login(string email, string password)
        {
            return UserRepository.Login(email, password).Map<User>();
        }
        public User GetFullUser(int id )
        {
            User user = UserRepository.Get(id).Map<User>();
            user.FollowedCategories = SubscriptionRepository.GetSubscriptions(id).Select(c => c.Map<Category>());
            user.Following = FollowRepository.GetFollowing(id).Select(u => u.Map<User>());
            user.FollowedBy = FollowRepository.GetFollowers(id).Select(u => u.Map<User>());
            user.Country = CountryRepository.Get(user.CountryId).Map<Country>();
            user.Role = RoleRepository.Get(user.RoleId).Map<Role>();
            return user;
        }
        public User Update(User user)
        {
            return UserRepository.Update(user.Map<DbUser>()).Map<User>();
        }
    }
}
