using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Domain.Services.Services.Twitter;
using MyStudyProject.Domain.Services.Services.Vk;

namespace MyStudyProject.Domain.Services.Services
{
    public class MessageService : IMessageService
    {
        private readonly IVkServiceFacade vkService;
        private readonly ITwitterServiceFacade twitterService;

        public MessageService(IVkServiceFacade vkService , ITwitterServiceFacade twitterService)
        {
            this.vkService = vkService;
            this.twitterService = twitterService;
        }

        public async Task<IEnumerable<MessageQueryResult>> GetAllAsync(string hashtag)
        {
            var vks = await vkService.GetAllAsync(hashtag);
            var twits = await twitterService.GetAllAsync(hashtag);
            return vks.Concat(twits);
        }

        public async Task<IEnumerable<MessageQueryResult>> GetNumberAsync(int number, string hashtag)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MessageQueryResult>> GetSinceLastIdAsync(long lastId, string hashtag)
        {
            throw new NotImplementedException();
        }
    }
}
