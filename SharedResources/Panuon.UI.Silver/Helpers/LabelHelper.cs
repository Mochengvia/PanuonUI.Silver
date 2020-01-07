using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    public static class LabelHelper
    {
        #region Property

        #region CornerRadius
        public static CornerRadius GetCornerRadius(Label label)
        {
            return (CornerRadius)label.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(Label label, CornerRadius value)
        {
            label.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(LabelHelper));
        #endregion

        #endregion
    }
}
