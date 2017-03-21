using IdentityServer4;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyStudyProject.IdentityServer.Services;

namespace MyStudyProject.IdentityServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

            services.AddMvcCore().AddJsonFormatters();
            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()));

            services.AddIdentityServer()
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddTemporarySigningCredential();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            app.UseCors("CorsPolicy");

            app.UseIdentityServer();
            //todo secure store
            app.UseTwitterAuthentication(new TwitterOptions
            {
                AuthenticationScheme = "Twitter",
                DisplayName = "Twitter",
                SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme,
                ConsumerKey = "rggmXYCWck4rlzsCQmI6QHkCG",
                ConsumerSecret = "M3m4ye2ooJwQTicrK0yGVl9Ui3FPJznH3eXFPyZhdpVVeTusNM"
            });
            app.UseMvc();
        }
    }
}