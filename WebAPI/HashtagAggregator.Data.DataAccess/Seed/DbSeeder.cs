using System;
using System.IO;
using System.Linq;
using HashtagAggregator.Data.Contracts.Interface;

namespace HashtagAggregator.Data.DataAccess.Seed
{
    public class DbSeeder : IDbSeeder
    {
        public void Seed(string connectionString)
        {
            try
            {
                var dbConnector = new DbConnector(connectionString);
                var commands = ScriptsRetriever.GetNonQueryScripts().ToArray();
                dbConnector.ExecuteNonQuery(commands);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
