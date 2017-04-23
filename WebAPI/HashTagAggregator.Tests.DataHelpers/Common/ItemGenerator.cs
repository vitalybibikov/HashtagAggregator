using System;
using System.Collections.Generic;

namespace HashTagAggregator.Tests.DataHelpers.Common
{
    public class ItemGenerator
    {
        public static List<T> GetList<T>(Func<T> itemsFunc, int count)
        {
            var items = new List<T>();
            if (itemsFunc != null)
            {
                for (int i = 0; i < count; i++)
                {
                    items.Add(itemsFunc());
                }
            }
            return items;
        }
    }
}
