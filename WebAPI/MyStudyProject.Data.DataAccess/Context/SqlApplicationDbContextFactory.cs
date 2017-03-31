using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace MyStudyProject.Data.DataAccess.Context
{
    public class SqlApplicationDbContextFactory : IDbContextFactory<SqlApplicationDbContext>
    {
        private IConfigurationRoot configuration;

        public SqlApplicationDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(options.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{options.EnvironmentName}.json", optional: true);

            configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<SqlApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("AppSettings"), m => { m.EnableRetryOnFailure(); });

            return new SqlApplicationDbContext(optionsBuilder.Options);
        }
    }
}
