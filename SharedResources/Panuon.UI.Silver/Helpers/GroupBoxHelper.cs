using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class GroupBoxHelper
    {

        #region Properties

        #region GroupBoxStyle
        public static GroupBoxStyle GetGroupBoxStyle(GroupBox groupBox)
        {
            return (GroupBoxStyle)groupBox.GetValue(GroupBoxStyleProperty);
        }

        public static void SetGroupBoxStyle(GroupBox groupBox, GroupBoxStyle value)
        {
            groupBox.SetValue(GroupBoxStyleProperty, value);
        }

        public static readonly DependencyProperty GroupBoxStyleProperty =
            DependencyProperty.RegisterAttached("GroupBoxStyle", typeof(GroupBoxStyle), typeof(GroupBoxHelper));
        #endregion

        #region Icon
        public static object GetIcon(GroupBox groupBox)
        {
            return (object)groupBox.GetValue(IconProperty);
        }

        public static void SetIcon(GroupBox groupBox, object value)
        {
            groupBox.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(GroupBoxHelper));
        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(GroupBox groupBox)
        {
            return (CornerRadius)groupBox.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(GroupBox groupBox, CornerRadius value)
        {
            groupBox.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(GroupBoxHelper));
        #endregion

        #region ShadowColor
        public static Color? GetShadowColor(GroupBox groupBox)
        {
            return (Color?)groupBox.GetValue(ShadowColorProperty);
        }

        public static void SetShadowColor(GroupBox groupBox, Color? value)
        {
            groupBox.SetValue(ShadowColorProperty, value);
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.RegisterAttached("ShadowColor", typeof(Color?), typeof(GroupBoxHelper));
        #endregion

        #region ExtendControl
        public static object GetExtendControl(GroupBox groupBox)
        {
            return (object)groupBox.GetValue(ExtendControlProperty);
        }

        public static void SetExtendControl(GroupBox groupBox, object value)
        {
            groupBox.SetValue(ExtendControlProperty, value);
        }

        public static readonly DependencyProperty ExtendControlProperty =
            DependencyProperty.RegisterAttached("ExtendControl", typeof(object), typeof(GroupBoxHelper));
        #endregion

        #endregion

    }
}
