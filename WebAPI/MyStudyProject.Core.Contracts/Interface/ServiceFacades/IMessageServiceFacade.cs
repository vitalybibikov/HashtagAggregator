using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyStudyProject.Core.Contracts.Interface.Cqrs;

namespace MyStudyProject.Core.Contracts.Interface.ServiceFacades
{
    public interface IMessageServiceFacade<T> 
    {
        Task<IEnumerable<T>> GetAll(string hashtag);

        Task<IEnumerable<T>> GetNumber(int number, string hashtag);

        Task<IEnumerable<T>> GetSinceLastId(long lastId, string hashtag);
    }
}
