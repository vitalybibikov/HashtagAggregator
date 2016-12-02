using System;
using System.Collections.Generic;

using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Cqrs.Results;
using MyStudyProject.Domain.Services.Services.Vk;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Domain.Services.Assemblers.Vk
{
    public class VkMessageResultMapper : IMapper<MessageQueryResult, VkNewsSearchResult>
    {
        public MessageQueryResult Map(VkNewsSearchResult post, string hashtag)
        {
            MessageQueryResult message = new MessageQueryResult
            {
                Body = post.Text,
                HashTag = hashtag,
                Id = post.Id,
                Media = SocialMediaType.Twitter,
                PostDate = DateTimeOffset.FromUnixTimeSeconds(post.UnixTimeStamp).DateTime
            };

            return message;
        }

        public IEnumerable<MessageQueryResult> MapBunch(IEnumerable<VkNewsSearchResult> messages, string hashtag)
        {
            var results = new List<MessageQueryResult>();
            foreach (var post in messages)
            {
                MessageQueryResult message = new MessageQueryResult()
                {
                    Body = post.Text,
                    HashTag = hashtag,
                    Id = post.Id,
                    Media = SocialMediaType.VK,
                    PostDate = DateTimeOffset.FromUnixTimeSeconds(post.UnixTimeStamp).DateTime
                };
                results.Add(message);
            }
            return results;
        }
    }
}
