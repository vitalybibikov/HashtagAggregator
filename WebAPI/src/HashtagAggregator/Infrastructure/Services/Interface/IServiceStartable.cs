using System.Threading.Tasks;

namespace HashtagAggregator.Infrastructure.Services.Interface
{
    public interface IServiceStartable
    {
        Task Start();

        Task Stop();
    }
}
