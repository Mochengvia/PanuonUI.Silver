using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Panuon.UI.Silver.Internal.Utils
{
   static class DependencyObjectUtils
    {
        internal static bool IsDefaultValue(DependencyObject d, DependencyProperty dp)
        {
            return DependencyPropertyHelper.GetValueSource(d, dp).BaseValueSource == BaseValueSource.Default;
        }
    }
}
