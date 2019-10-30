using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
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

            //setup JWT tokens
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["jwt:key"]))
                    };
                });
            //setup cors
            const string corsUrlKey = "Security:Cors:Url";
            services.AddCors(options =>
            {
                string url = this.Configuration[corsUrlKey];
                options.AddPolicy("AllowAnyRequest",
                                  builder => builder.AllowAnyOrigin()
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod()
                                                    ) ;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Environment.SetEnvironmentVariable("connectionString", @"Data Source=LENOVO-3373;Initial Catalog=R8It;User ID=sa; Password=test1234=");
            Environment.SetEnvironmentVariable("connectionString", @"Data Source=TECHNOBEL\;Initial Catalog=R8It;Persist Security Info=True;User ID=sa;Password=test1234=");
            //Environment.SetEnvironmentVariable("connectionString", @"Data Source = TECHNOBEL\; Initial Catalog = R8It; User ID = sa; Password = test1234=");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowAnyRequest");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            
            
        }
    }
}
