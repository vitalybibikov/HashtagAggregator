using HashtagAggregator.Shared.Common.FilterStrategies.Interface;

namespace HashtagAggregator.Shared.Common.FilterStrategies
{
    public class DefaultFilterStrategy : IFilterStrategy
    {
        public virtual bool IsOperationAllowed()
        {
            return true;
        }
    }
}
