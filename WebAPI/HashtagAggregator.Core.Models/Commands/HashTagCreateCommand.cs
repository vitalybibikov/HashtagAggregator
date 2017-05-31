using System;

using HashtagAggregator.Core.Models.Interface.Cqrs.Command;

namespace HashtagAggregator.Core.Models.Commands
{
    public class HashTagCreateCommand : ICommand
    {
        public string HashTag { get; set; }

        public bool IsEnabled { get; set; }
    }
}
