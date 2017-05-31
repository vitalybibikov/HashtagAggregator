using System.Threading.Tasks;

namespace HashtagAggregator.Core.Contracts.Interface
{
    public interface IRequestFilter
    {
        Task<bool> IsRequestAllowed(object handler);
    }
}
