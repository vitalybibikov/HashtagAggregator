using System;
using System.Collections.Generic;
using System.Text;

namespace HashtagAggregator.Data.Contracts.Interface
{
    public interface IDbSeeder
    {
        void Seed(string connectionString);
    }
}
