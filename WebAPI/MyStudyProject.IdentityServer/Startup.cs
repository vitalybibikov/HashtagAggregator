using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using MyStudyProject.IdentityServer.Database.Context;
using MyStudyProject.IdentityServer.Identity;
using MyStudyProject.IdentityServer.Services;

namespace MyStudyProject.IdentityServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();

            var connectionString = "Data Source=.;Initial Catalog=MyStudyDb;User ID=sa;Password=123456";

            services.AddDbContext<SqlIdentityDbContext>(
             options => options.UseSqlServer(connectionString));

            services.AddEntityFramework()
                    .AddDbContext<SqlIdentityDbContext>(options =>
                        options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SqlIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()));

            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddAspNetIdentity<ApplicationUser>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            app.UseCors("CorsPolicy");

            app.UseIdentity();
            app.UseIdentityServer();

            //after identity before mvc
            app.UseTwitterAuthentication(new TwitterOptions
            {
                AuthenticationScheme = "Id",
                DisplayName = "Twitter",
                SignInScheme = "Identity.External",

                ConsumerKey = "O7OYOgmutGRemGCThi51DYgyL",
                ConsumerSecret = "496fR6J70pryWgsKLYTOGvwpmKpYmmfJGm84bpmwmt4e866zRC",
                SaveTokens = true,
                
            });
        
            app.UseMvcWithDefaultRoute();
        }
    }
}