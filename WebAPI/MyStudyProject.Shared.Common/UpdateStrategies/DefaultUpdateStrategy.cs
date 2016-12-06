namespace MyStudyProject.Shared.Common.UpdateStrategies
{
    public class DefaultUpdateStrategy : IUpdateStrategy
    {
        public bool IsOperationAllowed()
        {
            return true;
        }
    }
}
