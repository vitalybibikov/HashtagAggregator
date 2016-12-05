using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStudyProject.Core.Contracts.Interface.ServiceFacades
{
    public interface IMessageServiceFacade<T> 
    {
        Task<T> GetAllAsync(string hashtag);

        Task<T> GetNumberAsync(int number, string hashtag);

        Task<T> GetSinceLastIdAsync(long lastId, string hashtag);
    }
}
