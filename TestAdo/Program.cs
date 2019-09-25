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
                                .BuildServiceProvider();


            #region test USerService
            //UserService service = serviceProvider.GetService<UserService>();
            //DbUser testReceive = service.Login("test@test.com", "testpw");
            //Console.WriteLine(testReceive.Nickname);

            //foreach (DbUser user in service.GetAll())
            //{
            //    Console.WriteLine(user.Email);
            //}
            #endregion
            #region test CategoryService
            CategoryService service = serviceProvider.GetService<CategoryService>();
            DbCategory category = new DbCategory
            {
                Name = "yolo2"
            };
            category = service.Insert(category);
            Console.WriteLine(category.Id);
            #endregion
            #region test CountryService
            #endregion
            #region test FollowService
            #endregion


            Console.ReadKey();
        }
    }
}
