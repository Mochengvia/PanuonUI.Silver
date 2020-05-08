using System;
using System.Collections.Generic;

namespace Panuon.UI.Silver.Core
{
    public static class IEnumerableExtension
    {
        #region Apply
        public static void Apply<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
        #endregion

        #region Range
        public static IEnumerable<T> Range<T>(this IEnumerable<T> items, int index, int count)
        {
            var i = 0;
            foreach (var item in items)
            {
                if (i < index || i >= (index + count))
                {
                    i++;
                    continue;
                }
                i++;
                yield return item;
            }
        }
        #endregion

        #region Count

        #endregion
    }
}
