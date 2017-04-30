using System;
using System.Collections.Generic;
using System.IO;

namespace HashtagAggregator.Data.DataAccess.Seed
{
    public static class ScriptsRetriever
    {
        private const string InitialDbScript = @"..\..\HashtagAggregator.Data.DataAccess\Seed\Scripts\Initial.sql";

        public static IEnumerable<string> GetNonQueryScripts()
        {
            var commands = new List<string>();
            var path = Path.Combine(Directory.GetCurrentDirectory(), InitialDbScript);
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found: " + path);
            }
            else
            {
                var text = File.ReadAllText(path);
                commands.Add(text);
            }
            return commands;
        }
    }
}
