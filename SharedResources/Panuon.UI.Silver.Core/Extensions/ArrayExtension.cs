using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver.Core
{
    public static class ArrayExtension
    {
        public static void Fill<T>(this T[] array, T value)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }
    }
}
