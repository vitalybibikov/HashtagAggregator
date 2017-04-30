using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace HashtagAggregator.Data.DataAccess.Context
{
    public class SqlApplicationDbContextFactory : IDbContextFactory<SqlApplicationDbContext>
    {
        private string ParentProject = @"src\HashtagAggregator";
        private IConfigurationRoot configuration;

        public SqlApplicationDbContext Create(DbContextFactoryOptions options)
        {
            var path = Path.Combine(Directory.GetParent(options.ContentRootPath).Parent.FullName, ParentProject);
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{options.EnvironmentName}.json", optional: true);
 
            configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<SqlApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetSection("AppSettings:ConnectionString").Value, m => { m.EnableRetryOnFailure(); });

            return new SqlApplicationDbContext(optionsBuilder.Options);
        }
    }
}
