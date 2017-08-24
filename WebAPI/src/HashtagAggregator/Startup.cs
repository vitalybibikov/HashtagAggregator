using System;
using System.Net;
using Autofac;
using AutoMapper;
using Serilog;
using HashtagAggregator.Configuration;
using HashtagAggregator.Data.DataAccess.Context;
using HashtagAggregator.Data.DataAccess.Interface;
using HashtagAggregator.DependencyInjection;
using HashtagAggregator.Domain.Cqrs.EF.Abstract;
using HashtagAggregator.Infrastructure;
using HashtagAggregator.Settings;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace HashtagAggregator
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

            //Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(Configuration)
                .WriteTo.ApplicationInsightsTraces(
                    Configuration.GetSection("ApplicationInsights:InstrumentationKey").Value)
                .CreateLogger();

            if (env.IsEnvironment("dev"))
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
        }

        private readonly MapperConfiguration mapperConfiguration;

        public IMapper Mapper { get; set; }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<VkAuthSettings>(Configuration.GetSection("VkAuthSettings"));
            services.Configure<VkSettings>(Configuration.GetSection("VkSettings"));
            services.Configure<EndpointSettings>(Configuration.GetSection("EndpointSettings"));
            services.Configure<VkConsumeSettings>(Configuration.GetSection("VkConsumeSettings"));
            services.Configure<TwitterConsumeSettings>(Configuration.GetSection("TwitterConsumeSettings"));
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile
                    {
                        Duration = 60
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {Title = "HashtagAggregator", Version = "v1"});
            });

            services.AddMediatR(typeof(EfQueryHandler));
            var connectionString = Configuration.GetSection("AppSettings:ConnectionString").Value;

            services.AddEntityFrameworkSqlServer()
                .AddDbContextPool<SqlApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped(sp => mapperConfiguration.CreateMapper());
            mapperConfiguration.AssertConfigurationIsValid();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    o.Authority = Configuration.GetSection("EndpointSettings:AuthEndpoint").Value;
                    o.Audience = "statisticsapi";
                    o.RequireHttpsMetadata = false;
                });

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()));

            var container = new AutofacModulesConfigurator().Configure(services);

            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            IServiceStarter starter, IDbSeeder seeder)
        {
            loggerFactory.AddDebug();
            loggerFactory.AddSerilog();

            app.UseExceptionHandler(options =>
            {
                options.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            var err = $"Error: {ex.Error.Message}{ex.Error.StackTrace}";
                            Log.Error(ex.Error, "Server Error", ex);
                            await context.Response.WriteAsync(err).ConfigureAwait(false);
                        }
                    });
            });

            app.UseCors("CorsPolicy");

            seeder.Seed(Configuration.GetSection("AppSettings:ConnectionString").Value);
            starter.Start();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseAuthentication();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseMvc();
        }
    }
}