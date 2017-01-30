using System;

namespace MyStudyProject.Data.Contracts.Interface.JobObjects
{
    public interface IBackgroundJob<in T>
    {
        void Publish(T command);
    }
}
