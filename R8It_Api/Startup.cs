using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using R8It_Domain.Services.Implementations;
using Tools;

namespace R8It_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            services.AddControllers();
            //added DAL services. 
            //TODO: build Domain services and replace these DAL services with the domains
            //services.AddSingleton<IUserRepository, UserRepository>()
            //        .AddSingleton<ICategoryRepository, CategoryRepository>()
            //        .AddSingleton<IFollowRepository, FollowRepository>()
            //        .AddSingleton<IRatingTypeRepository, RatingTypeRepository>()
            //        .AddSingleton<ISubscriptionRepository, SubscriptionRepository>()
            //        .AddSingleton<IRateChoiceRepository, RateChoiceRepository>()
            //        .AddSingleton<IUploadRepository, UploadRepository>()
            //        .AddSingleton<IVoteRepository, VoteRepository>();

            //automatically scans Services and Repos to inject
            services.ScanTypesFrom(typeof(UserRepository).Assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsInterfaces()
                .RegisterAsSingleton(services)
                .ScanTypesFrom(typeof(UserService).Assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsInterfaces()
                .RegisterAsSingleton(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
