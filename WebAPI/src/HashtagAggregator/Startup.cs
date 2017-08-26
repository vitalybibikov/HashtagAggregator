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
        public readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
        }

        private readonly MapperConfiguration mapperConfiguration;

        public IMapper Mapper { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.Configure<VkAuthSettings>(configuration.GetSection("VkAuthSettings"));
            services.Configure<VkSettings>(configuration.GetSection("VkSettings"));
            services.Configure<EndpointSettings>(configuration.GetSection("EndpointSettings"));
            services.Configure<VkConsumeSettings>(configuration.GetSection("VkConsumeSettings"));
            services.Configure<TwitterConsumeSettings>(configuration.GetSection("TwitterConsumeSettings"));
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
            var connectionString = configuration.GetSection("AppSettings:ConnectionString").Value;

            services.AddEntityFrameworkSqlServer()
                .AddDbContextPool<SqlApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(sp => mapperConfiguration.CreateMapper());
            mapperConfiguration.AssertConfigurationIsValid();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    o.Authority = configuration.GetSection("EndpointSettings:AuthEndpoint").Value;
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

        public void Configure(IApplicationBuilder app, IServiceStarter starter, IDbSeeder seeder)
        {
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

            seeder.Seed(configuration.GetSection("AppSettings:ConnectionString").Value);
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