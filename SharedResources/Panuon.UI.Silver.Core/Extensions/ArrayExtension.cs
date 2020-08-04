using System.Linq;

namespace Panuon.UI.Silver.Core
{
    public static class ArrayExtension
    {
        #region Fill
        public static void Fill<T>(this T[] array, T value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }
        #endregion

        #region IsIncluded
        public static bool IsIncludedIn<T>(this T value, params T[] values)
        {
            if (values == null)
            {
                return false;
            }
            return values.Contains(value);
        }
        #endregion
    }

}
