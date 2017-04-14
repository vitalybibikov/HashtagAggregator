using System.Net;
using System.Reflection;
using HashtagAggregator.IdentityServer.Configuration;
using HashtagAggregator.IdentityServer.Database.Context;
using HashtagAggregator.IdentityServer.Database.Identity;
using HashtagAggregator.IdentityServer.Infrastructure;
using HashtagAggregator.IdentityServer.Services;

using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace HashtagAggregator.IdentityServer
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("identityserversettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"identityserversettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(Configuration)
                .CreateLogger();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TwitterAuthSettings>(Configuration.GetSection("TwitterAuthSettings"));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITwitterVerifier, TwitterVerifier>();
            services.AddScoped<IProfileService, CustomProfileService>();
            
            services.AddMvcCore().AddAuthorization()
                .AddJsonFormatters();

            var connectionString = Configuration.GetSection("AppSettings:ConnectionString").Value;
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<SqlIdentityDbContext>(
             options => options.UseSqlServer(connectionString));

            services.AddEntityFramework()
                    .AddDbContext<SqlIdentityDbContext>(
                options => options.UseSqlServer(connectionString));

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
            loggerFactory.AddSerilog();
            loggerFactory.AddConsole(LogLevel.Debug);

            var id4Initializer = new IdentityServerInitializer();
            id4Initializer.InitializeDatabase(app, Configuration);

            app.UseCors("CorsPolicy");

            app.UseIdentity();
            app.UseIdentityServer();

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