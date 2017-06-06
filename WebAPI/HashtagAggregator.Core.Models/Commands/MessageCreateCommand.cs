using System;
using System.Collections.Generic;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Core.Models.Commands
{
    public class MessageCreateCommand : ICommand
    {
        public MessageCreateCommand()
        {
            HashTags = new List<HashTagCreateCommand>();
        }

        public long Id { get; set; }

        public string MessageText { get; set; }

        public List<HashTagCreateCommand> HashTags { get; set; }

        public SocialMediaType MediaType { get; set; }

        public DateTime? PostDate { get; set; }

        public UserCreateCommand User { get; set; }

        public string NetworkId { get; set; }
    }
}