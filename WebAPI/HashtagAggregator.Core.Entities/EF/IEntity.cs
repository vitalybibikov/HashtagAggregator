namespace HashtagAggregator.Core.Entities.EF
{
    public interface IEntity
    {
        long Id
        {
            get;
            set;
        }

        bool IsNew
        {
            get;
        }
    }
}
