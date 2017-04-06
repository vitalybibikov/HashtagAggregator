using System.Linq;
using System.Reflection;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using MyStudyProject.IdentityServer.Database.Context;
using MyStudyProject.IdentityServer.Database.Identity;
using MyStudyProject.IdentityServer.Services;

namespace MyStudyProject.IdentityServer
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("identityserversettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"identityserversettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, CustomProfileService>();

            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();

            var connectionString = Configuration.GetSection("AppSettings:ConnectionString").Value;
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

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
               .AddConfigurationStore(builder =>
                    builder.UseSqlServer(connectionString, options =>
                    options.MigrationsAssembly(migrationsAssembly)))
                .AddOperationalStore(builder =>
                    builder.UseSqlServer(connectionString, options =>
                    options.MigrationsAssembly(migrationsAssembly)))
                .AddAspNetIdentity<ApplicationUser>()
                .AddProfileService<CustomProfileService>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            var id4Initializer = new IdentityServerInitializer();
            id4Initializer.InitializeDatabase(app, Configuration);

            app.UseCors("CorsPolicy");

            app.UseIdentity();
            app.UseIdentityServer();

            //after identity before mvc
            app.UseTwitterAuthentication(new TwitterOptions
            {
                AuthenticationScheme = "Id",
                DisplayName = "Twitter",
                SignInScheme = "Identity.External",

                ConsumerKey = Configuration.GetSection("TwitterAuthSettings:ConsumerKey").Value,
                ConsumerSecret = Configuration.GetSection("TwitterAuthSettings:ConsumerSecret").Value,
                SaveTokens = true
            });
            

            app.UseMvcWithDefaultRoute();
        }
    }
}