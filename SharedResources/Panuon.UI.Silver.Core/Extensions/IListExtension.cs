using System.Collections.Generic;
using System.Linq;

namespace Panuon.UI.Silver.Core
{
    public static class IListExtension
    {
        #region AddRange
        public static void AddRange<T>(this IList<T> items, IEnumerable<T> addItems)
        {
            foreach(var item in addItems)
            {
                items.Add(item);
            }
        }
        #endregion

        #region RemoveRange
        public static void RemoveRange<T>(this IList<T> items, IEnumerable<T> removeItems)
        {
            for(int i = items.Count - 1; i >= 0; i--)
            {
                var item = items[i];
                if (removeItems.Contains(item))
                    items.RemoveAt(i);
            }
        }
        #endregion
    }
}
