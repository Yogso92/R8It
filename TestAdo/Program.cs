using DAL;
using DbEntities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using Provider = DAL.DALService;

namespace TestAdo
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("connectionString", @"Data Source=TECHNOBEL\;Initial Catalog=R8It;Persist Security Info=True;User ID=sa;Password=test1234=");
            #region test DALService OK
            // first call should cw the add of CategoryService to the provider
            // CategoryRepository service = Provider.GetService<CategoryRepository>();
            // IRateChoiceRepository service1 = Provider.GetService<IRateChoiceRepository>();

            // IRateChoiceRepository service2 = Provider.GetService<IRateChoiceRepository>();
            // testing multiple call to provider
            //should NOT cw the add of CategoryService to the provider
            //testSingleton test = new testSingleton();
            // testSingleton test2 = new testSingleton();

            // testing the actual service
            // foreach (DbCategory category in service.GetAll())
            // {
            //     Console.WriteLine(category.Name);
            // }



            #endregion
            #region test USerService 
            //TODO Update
            //UserRepository uservice = Provider.GetService<UserRepository>();
            //DbUser testReceive = uservice.Login("test@test.com", "testpw");
            //Console.WriteLine(testReceive.Nickname);
            //testReceive.Nickname = "test2";
            //testReceive.Email = "yolo@test.com";
            //testReceive.Password = "testpw";
            //uservice.Register(testReceive);

            //foreach (DbUser user in uservice.GetAll())
            //{
            //    Console.WriteLine(user.Email);
            //}
            #endregion
            #region test CategoryService OK
            //CategoryRepository service = Provider.GetService<CategoryRepository>();
            //DbCategory category = new DbCategory
            //{
            //    Name = "yolo2"
            //};
            //category = service.Insert(category);
            //Console.WriteLine(category.Id);
            #endregion
            //#region test CountryService TODO
            //#endregion
            //#region test FollowService OK
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
            //}
            //catch (Exception e)
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


            //#endregion
            #region RatingServiceTest OK
            //RatingTypeRepository service = Provider.GetService<RatingTypeRepository>();
            //service.Delete(1);

            //DbRatingType ratingType = new DbRatingType
            //{
            //    Name = "Yes or No",
            //    Definition = "Get votes on a yes or no basis. R8ers like it or they don't, no in between."
            //};
            //ratingType = service.Insert(ratingType);
            //Console.WriteLine(ratingType.Id);

            //Console.WriteLine(service.GetAll().FirstOrDefault().Name);
            #endregion
            //#region SubscriptionService OK 
            //SubscriptionService ss = serviceProvider.GetService<SubscriptionService>();
            //try
            //{
            //    ss.Subscribe(1, 1);
            //    ss.Subscribe(4, 3);
            //    ss.Subscribe(1, 3);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("subscribe ok");
            //}
            //foreach (DbUser user in ss.GetSubscribers(3))
            //{
            //    Console.WriteLine(user.Nickname);
            //}
            //foreach (DbCategory cat in ss.GetSubscriptions(1))
            //{
            //    Console.WriteLine(cat.Name);
            //}

            //ss.Unsubscribe(1, 1);
            //foreach (DbCategory cat in ss.GetSubscriptions(1))
            //{
            //    Console.WriteLine(cat.Name);
            //}
            //#endregion
            #region RateChoiceService

            RateChoiceRepository service2 = Provider.GetService<RateChoiceRepository>();
            DbRateChoice choice = new DbRateChoice
            {
                RatingTypeId = 1,
                Text = "Yes",
                Value = 10
            };
            DbRateChoice choice2 = new DbRateChoice
            {
                RatingTypeId = 1,
                Text = "No",
                Value = 0
            };
            try
            {
                choice = service2.Insert(choice);
                choice = service2.Insert(choice2);
                choice = service2.Insert(choice2);
                Console.WriteLine("insert pas ok");
            }
            catch (Exception)
            {
                Console.WriteLine("insert ok");
            }

            Console.WriteLine(choice.Id);
            foreach (DbRateChoice choicee in service2.GetChoices(1))
            {
                Console.WriteLine($"{choicee.Text} : {choicee.Value}");
            }

            #endregion
            //#region UploadService OK
            //UploadService service = serviceProvider.GetService<UploadService>();
            //DbUpload upload = new DbUpload
            //{
            //    Context = "Yolo",
            //    UserId = 1,
            //    CategoryId = 1,
            //    File = File.ReadAllBytes("C:/test.png"),
            //    RatingTypeId = 2,
            //    Anonymous = false,
            //    LimitDate = DateTime.Now.AddDays(7),
            //    UploadDate = DateTime.Now
            //};

            //upload = service.Insert(upload);
            //Console.WriteLine(upload.Id);
            //Console.WriteLine(upload.LimitDate);

            //DbUpload upload = service.Get(1);
            //File.WriteAllBytes("D:/yolo.png", upload.File);

            //foreach (DbUpload upload1 in service.GetAll())
            //{
            //    Console.WriteLine(upload1.Context);
            //}
            //foreach (DbUpload upload2 in service.GetAllFromUser(1))
            //{
            //    Console.WriteLine(upload2.Context);
            //}
            //#endregion
            //#region VoteService OK
            //VoteService service = serviceProvider.GetService<VoteService>();
            //DbVote vote = new DbVote
            //{
            //    UserId = 4,
            //    UploadId = 1,
            //    RateChoiceId = 11
            //};

            //try
            //{
            //    vote = service.Insert(vote);
            //    vote = service.Insert(vote);
            //    Console.WriteLine("insert pas ok");
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("insert ok");
            //}
            //Console.WriteLine(vote.Id);

            //foreach (DbVote item in service.GetVotes(1))
            //{
            //    Console.WriteLine(item.UserId);
            //}
            //foreach (DbVote item in service.GetAll())
            //{
            //    Console.WriteLine(item.RateChoiceId);
            //}

            //#endregion
            Console.ReadKey();
        }
    }
}
