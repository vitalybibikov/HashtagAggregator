using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HashtagAggregator.Infrastructure.Services.Interface
{
    public interface IServiceNotifier
    {
        Task Send(HttpRequestMessage httpRequestMessage);
    }
}
