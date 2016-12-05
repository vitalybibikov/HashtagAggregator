using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudyProject.Data.Contracts.Interface
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
