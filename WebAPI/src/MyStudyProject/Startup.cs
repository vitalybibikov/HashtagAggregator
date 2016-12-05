using System;
using System.Net;
using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using MyStudyProject.Configuration;
using MyStudyProject.Data.DataAccess.Context;
using MyStudyProject.DependencyInjection;
using MyStudyProject.Shared.Common.Settings;

namespace MyStudyProject
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
        }

        private MapperConfiguration mapperConfiguration;
        public IMapper Mapper { get; set; }
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<TwitterSettings>(Configuration.GetSection("TwitterSettings"));
            services.Configure<VkSettings>(Configuration.GetSection("VkSettings"));

            // Add framework services.
            services.AddMvc();

            // Adds EF Context per request
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<SqlApplicationDbContext>();

            services.AddSingleton(sp => mapperConfiguration.CreateMapper());
            services.AddSingleton<IConfiguration>(Configuration);
            mapperConfiguration.AssertConfigurationIsValid();

            var builder = new AutofacModulesConfigurator();
            return builder.Configure(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseExceptionHandler(options =>
            {
                options.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            var err = $"Error: {ex.Error.Message}{ex.Error.StackTrace}";
                            await context.Response.WriteAsync(err).ConfigureAwait(false);
                        }
                    });
            });

            app.UseMvc();
        }
    }
}
