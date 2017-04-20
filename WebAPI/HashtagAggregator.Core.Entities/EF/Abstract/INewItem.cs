using System;
using System.Collections.Generic;
using System.Text;

namespace HashtagAggregator.Core.Entities.EF.Abstract
{
    public interface INewItem
    {
        bool IsNew
        {
            get;
        }
    }
}
