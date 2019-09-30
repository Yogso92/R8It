using DAL;
using DbEntities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace TestAdo
{
    class Program
    {
        static void Main(string[] args)
        {
            //register factory as Core does not natively supports System.Data.SqlClient

            //TODO register in asp app
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            ServiceProvider serviceProvider = new ServiceCollection()
                                .AddSingleton<UserService>()
                                .AddSingleton<CategoryService>()
                                .AddSingleton<FollowService>()
                                .BuildServiceProvider();


            #region test USerService OK
            //UserService service = serviceProvider.GetService<UserService>();
            //DbUser testReceive = service.Login("test@test.com", "testpw");
            //Console.WriteLine(testReceive.Nickname);
            //testReceive.Nickname = "test2";
            //testReceive.Email = "yolo@test.com";
            //testReceive.Password = "testpw";
            //service.Register(testReceive);

            //foreach (DbUser user in service.GetAll())
            //{
            //    Console.WriteLine(user.Email);
            //}
            #endregion
            #region test CategoryService OK
            //CategoryService service = serviceProvider.GetService<CategoryService>();
            //DbCategory category = new DbCategory
            //{
            //    Name = "yolo2"
            //};
            //category = service.Insert(category);
            //Console.WriteLine(category.Id);
            #endregion
            #region test CountryService TODO
            #endregion
            #region test FollowService OK
            //DbFollow follow = new DbFollow
            //{
            //    FollowedId = 1,
            //    FollowerId = 4
            //};
            //FollowService service = serviceProvider.GetService<FollowService>();
            //try
            //{
            //    service.Follow(1, 4);

            //    service.Follow(1, 4);
            //    Console.WriteLine("follow unique pas ok");
            //}catch(Exception e)
            //{
            //    Console.WriteLine("follow unique ok");
            //}
            //foreach (DbFollow item in service.GetFollowed(1))
            //{
            //    Console.WriteLine(item.FollowedId.ToString(), item.FollowerId.ToString());

            //}
            //foreach (DbFollow item in service.GetFollowers(1))
            //{
            //    Console.WriteLine(item.FollowedId.ToString(), item.FollowerId.ToString());

            //}
            //service.Unfollow(1, 4);


            #endregion


            Console.ReadKey();
        }
    }
}
