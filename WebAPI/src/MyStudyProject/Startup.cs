using System;
using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            // Add framework services.
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<SqlApplicationDbContext>();

            //options =>
            //          options.UseSqlServer(Configuration["AppSettings:ConnectionString"],
            //              b => b.MigrationsAssembly("MyStudyProject.Data.DbMigration"))

            //.options.UseSqlServer(Configuration["AppSettings:ConnectionString"])

            services.AddMvc();

            services.AddSingleton(sp => mapperConfiguration.CreateMapper());
            mapperConfiguration.AssertConfigurationIsValid();

            services.AddSingleton<IConfiguration>(Configuration);
            //services.AddTransient<IMessageService, MessageService>();

            var builder = new AutofacModulesConfigurator();
            return builder.Configure(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
