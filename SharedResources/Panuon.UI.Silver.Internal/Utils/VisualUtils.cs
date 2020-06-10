using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal static class VisualUtils
    {
        internal static T GetVisualChild<T>(DependencyObject parent) where T : FrameworkElement
        {
            var child = default(T);
            var count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var element = (FrameworkElement)VisualTreeHelper.GetChild(parent, i);
                child = element as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(element);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

    }
}
