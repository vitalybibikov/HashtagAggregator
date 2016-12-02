using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyStudyProject.Core.Contracts.Interface.Cqrs;

namespace MyStudyProject.Core.Contracts.Interface.ServiceFacades
{
    public interface IMessageServiceFacade<T> 
    {
        Task<IEnumerable<T>> GetAllAsync(string hashtag);

        Task<IEnumerable<T>> GetNumberAsync(int number, string hashtag);

        Task<IEnumerable<T>> GetSinceLastIdAsync(long lastId, string hashtag);
    }
}
