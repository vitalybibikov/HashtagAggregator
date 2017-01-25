using System;

namespace MyStudyProject.Data.Contracts.Interface
{
    public interface ITwitterBackgroundJob<in T>
    {
        void PublishTweet(T command);
    }
}
