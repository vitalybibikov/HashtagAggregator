using System;
using System.Collections.Generic;
using Bogus;
using Bogus.DataSets;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Shared.Contracts.Enums;
using HashTagAggregator.Tests.DataHelpers.Common;

namespace HashTagAggregator.Tests.DataHelpers
{
    public class CommandDataGenerator
    {
        public static List<MessageCreateCommand> GetCommands(List<HashTagCreateCommand> hashtags, UserCreateCommand user, int count = 1)
        {
            var messages = new List<MessageCreateCommand>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var command = new MessageCreateCommand
                {
                    MediaType = SocialMediaType.Twitter,
                    MessageText = "TestBody",
                    PostDate = DateTime.Now,
                    HashTags = hashtags,
                    NetworkId = IdGenerator.GetNetworkId(),
                    Id = 1,
                    User = user
                };
                messages.Add(command);
            }
            return messages;
        }

        public static List<UserCreateCommand> GetUsers(int count = 1)
        {
            var users = new List<UserCreateCommand>();

            for (int i = 0; i < count; i++)
            {
                var user  = new UserCreateCommand()
                {
                    Id = 0,
                    NetworkId = IdGenerator.GetNetworkId(),
                    ProfileId = IdGenerator.GetNetworkId(),
                    Url = "http://sdf.com",
                    UserName = "Name"
                };
                users.Add(user);
            }
            return users;
        }

        public static List<HashTagCreateCommand> GetHashTags(int count = 1)
        {
            var tags = new List<HashTagCreateCommand>();
       
            for (int i = 0; i < count; i++)
            {
                var lorem = new Lorem();
                var tag = new HashTagCreateCommand()
                {
                    HashTag = lorem.Word(),
                    IsEnabled = false
                };
                tags.Add(tag);
            }
            return tags;
        }
    }
}
