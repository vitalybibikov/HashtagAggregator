using System;
using System.Collections.Generic;

using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Shared.Common.Infrastructure;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashTagAggregator.Tests.DataHelpers
{
    public class DataGenerator
    {
        public static List<MessageEntity> GetMessages(UserEntity user, int count = 1, params HashTagWord[] tags)
        {
            var messages = new List<MessageEntity>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var entity = new MessageEntity
                {
                    MediaType = SocialMediaType.Twitter,
                    MessageText = "TestBody",
                    UserId = 0,
                    PostDate = DateTime.Now,
                    NetworkId = random.Next(1, Int32.MaxValue).ToString(),
                };
                entity.User = user;
                messages.Add(entity);

                foreach (var tag in tags)
                {
                    entity.HashTags.Add(new HashTagEntity() { HashTag = tag.NoHashTag });
                }
            }
            return messages;
        }

        public static List<UserEntity> GetUsers(int count = 1)
        {
            var random = new Random();
            var users = new List<UserEntity>();
            for (int i = 0; i < count; i++)
            {
                var user = new UserEntity()
                {
                    Id = 0,
                    NetworkId = random.Next(1, Int32.MaxValue).ToString(),
                    ProfileId = random.Next(1, Int32.MaxValue).ToString(),
                    Url = "http://sdf.com",
                    UserName = "Name"
                };
                users.Add(user);
            }
            return users;
        }
    }
}
