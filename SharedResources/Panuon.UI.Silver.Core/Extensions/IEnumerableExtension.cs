using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver.Core
{
    public static class IEnumerableExtension
    {
        #region Apply
        public static void Apply(this IEnumerable items, Action<object> action)
        {
            foreach (var item in items)
            {
                action.Invoke(item);
            }
        }

        public static void Apply<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach(var item in items)
            {
                action.Invoke(item);
            }
        }
        #endregion
    }
}
