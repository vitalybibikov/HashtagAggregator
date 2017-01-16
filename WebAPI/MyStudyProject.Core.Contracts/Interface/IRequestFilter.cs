using System;

using System.Threading.Tasks;

namespace MyStudyProject.Core.Contracts.Interface
{
    public interface IRequestFilter
    {
        Task<bool> IsRequestAllowed(object handler);
    }
}
