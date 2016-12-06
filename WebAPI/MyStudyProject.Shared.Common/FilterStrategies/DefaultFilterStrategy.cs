using MyStudyProject.Shared.Common.FilterStrategies.Interface;

namespace MyStudyProject.Shared.Common.UpdateStrategies
{
    public class DefaultFilterStrategy : IFilterStrategy
    {
        public virtual bool IsOperationAllowed()
        {
            return true;
        }
    }
}
