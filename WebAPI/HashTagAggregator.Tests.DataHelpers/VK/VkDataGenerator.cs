using System;
using System.Collections.Generic;
using Bogus.DataSets;

using HashtagAggregator.Core.Entities.VkEntities;
using HashtagAggregator.Shared.Common.Extensions;
using HashTagAggregator.Tests.DataHelpers.Common;


namespace HashTagAggregator.Tests.DataHelpers.VK
{
    public class VkDataGenerator
    {
        public static List<VkNewsSearchResult> GetSearches(int count = 1)
        {
            var lorem = new Lorem();
            return ItemGenerator.GetList(() =>
                new VkNewsSearchResult
                {
                    FromId = IdGenerator.GetInt32RandomId(),
                    Id = IdGenerator.GetInt32RandomId(),
                    OwnerId = IdGenerator.GetInt32RandomId(),
                    Text = lorem.Word(),
                    UnixTimeStamp = DateTime.Now.ToUnixTime()
                },
            count);
        }

        public static List<VkNewsProfile> GetProfiles(long profileId, int count = 1)
        {
            var lorem = new Lorem();
            return ItemGenerator.GetList(() =>
                new VkNewsProfile
                {
                    FirstName = lorem.Word(),
                    Id = profileId,
                    LastName = lorem.Word(),
                    UserName = lorem.Word(),
                    PhotoLink50 = new Internet().Url()
                },
          count);
        }
    }
}
