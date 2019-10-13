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
            
            #region test DALService OK
            //first call should cw the add of CategoryService to the provider
            CategoryService service = Provider.GetService<CategoryService>();
            RateChoiceService service1 = Provider.GetService<RateChoiceService>();

            RateChoiceService service2 = Provider.GetService<RateChoiceService>();
            // testing multiple call to provider
            //should NOT cw the add of CategoryService to the provider
            testSingleton test = new testSingleton();
            testSingleton test2 = new testSingleton();

            //testing the actual service
            foreach (DbCategory category in service.GetAll())
            {
                Console.WriteLine(category.Name);
            }

            

            #endregion
            //TODO register in asp app
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
            #region RatingServiceTest OK
            //RatingTypeService service = serviceProvider.GetService<RatingTypeService>();
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
            #region SubscriptionService OK 
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
            #endregion
            #region RateChoiceService

            //RateChoiceService service = serviceProvider.GetService<RateChoiceService>();
            //DbRateChoice choice = new DbRateChoice
            //{
            //    RatingTypeId = 2,
            //    Text = "Yes",
            //    Value = 10
            //};
            //try
            //{
            //    choice = service.Insert(choice);
            //    choice = service.Insert(choice);
            //    Console.WriteLine("insert pas ok");
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("insert ok");
            //}

            //Console.WriteLine(choice.Id);
            //foreach(DbRateChoice choice in service.GetChoices(1))
            //{
            //    Console.WriteLine($"{choice.Text} : {choice.Value}");
            //}

            #endregion
            #region UploadService OK
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

            //foreach(DbUpload upload1 in service.GetAll())
            //{
            //    Console.WriteLine(upload1.Context);
            //}
            //foreach(DbUpload upload2 in service.GetAllFromUser(1))
            //{
            //    Console.WriteLine(upload2.Context);
            //}
            #endregion
            #region VoteService OK
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
            //foreach(DbVote item in service.GetAll())
            //{
            //    Console.WriteLine(  item.RateChoiceId);
            //}

            #endregion
            Console.ReadKey();
        }
    }
}
