using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStudyProject.Shared.Common.Helpers
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// Объединить не пустую коллекцию.
        /// </summary>
        /// <typeparam name="T">Тип коллекции.</typeparam>
        /// <param name="collection">Коллекция.</param>
        /// <param name="separator">Разделитель.</param>
        /// <returns>Строковое представление коллекции через разделитель.</returns>
        public static string JoinNonEmpty<T>(this IEnumerable<T> collection, string separator = ",")
        {
            if (collection == null)
            {
                return String.Empty;
            }

            return string.Join(
                separator,
                collection.Select(i => i.ToString().Trim())
                    .Where(s => !string.IsNullOrWhiteSpace(s)
                    ));
        }
    }
}