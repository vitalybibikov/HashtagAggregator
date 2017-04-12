using System;
using System.Collections.Generic;
using System.Linq;

namespace HashtagAggregator.Shared.Common.Helpers
{
    public static class EnumerableExtension
    {
        public static string JoinNonEmpty<T>(this IEnumerable<T> collection, string separator = ",")
        {
            if (collection == null)
            {
                return String.Empty;
            }

            return String.Join(
                separator,
                collection.Select(i => i.ToString().Trim())
                    .Where(s => !String.IsNullOrWhiteSpace(s)
                    ));
        }
    }
}