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

        #region Count
       
        #endregion
    }
}
