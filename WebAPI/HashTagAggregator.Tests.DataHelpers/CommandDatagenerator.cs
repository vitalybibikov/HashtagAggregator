using System;
using System.Collections.Generic;

using Bogus.DataSets;

using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Shared.Contracts.Enums;
using HashTagAggregator.Tests.DataHelpers.Common;

namespace HashTagAggregator.Tests.DataHelpers
{
    public class CommandDataGenerator
    {
        public static List<MessageCreateCommand> GetMessages(List<HashTagCreateCommand> hashtags, UserCreateCommand user, int count = 1)
        {
            var word = new Lorem();

            return ItemGenerator.GetList(() =>
                     new MessageCreateCommand
                     {
                         MediaType = SocialMediaType.Twitter,
                         MessageText = word.Sentence(5),
                         PostDate = DateTime.Now,
                         HashTags = hashtags,
                         NetworkId = IdGenerator.GetNetworkId(),
                         Id = 1,
                         User = user
                     },
            count);
        }

        public static List<UserCreateCommand> GetUsers(int count = 1)
        {
            var internet = new Internet();
            var word = new Lorem();

            return ItemGenerator.GetList(() =>
                    new UserCreateCommand
                    {
                        Id = 0,
                        NetworkId = IdGenerator.GetNetworkId(),
                        ProfileId = IdGenerator.GetNetworkId(),
                        Url = internet.Url(),
                        UserName = word.Word(),
                        AvatarUrl50 = internet.Url()
                    },
            count);
        }

        public static List<HashTagCreateCommand> GetHashTags(int count = 1)
        {
            var lorem = new Lorem();
            return ItemGenerator.GetList(() =>
                      new HashTagCreateCommand
                      {
                          HashTag = lorem.Word(),
                          IsEnabled = false
                      },
            count);
        }
    }
}
