using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public abstract class FormGroup : Control
    {
        #region Properties

        #region ItemsHeight
        public static double GetItemsHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(ItemsHeightProperty);
        }

        public static void SetItemsHeight(DependencyObject obj, double value)
        {
            obj.SetValue(ItemsHeightProperty, value);
        }

        public static readonly DependencyProperty ItemsHeightProperty =
            DependencyProperty.RegisterAttached("ItemsHeight", typeof(double), typeof(FormGroup), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region Orientation
        public static Orientation GetItemsOrientation(DependencyObject obj)
        {
            return (Orientation)obj.GetValue(OrientationProperty);
        }

        public static void SetItemsOrientation(DependencyObject obj, Orientation value)
        {
            obj.SetValue(OrientationProperty, value);
        }

        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.RegisterAttached("Orientation", typeof(Orientation), typeof(FormGroup), new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region HeaderMargin
        public static Thickness GetItemsHeaderMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(HeaderMarginProperty);
        }

        public static void SetItemsHeaderMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(HeaderMarginProperty, value);
        }

        public Thickness HeaderMargin
        {
            get { return (Thickness)GetValue(HeaderMarginProperty); }
            set { SetValue(HeaderMarginProperty, value); }
        }

        public static readonly DependencyProperty HeaderMarginProperty =
            DependencyProperty.RegisterAttached("HeaderMargin", typeof(Thickness), typeof(FormGroup), new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region Icon

        public object Icon
        {
            get { return (object)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(object), typeof(FormGroup));

        #endregion

        #region HeaderWidth
        public static string GetItemsHeaderWidth(DependencyObject obj)
        {
            return (string)obj.GetValue(HeaderWidthProperty);
        }

        public static void SetItemsHeaderWidth(DependencyObject obj, string value)
        {
            obj.SetValue(HeaderWidthProperty, value);
        }

        public string HeaderWidth
        {
            get { return (string)GetValue(HeaderWidthProperty); }
            set { SetValue(HeaderWidthProperty, value); }
        }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.RegisterAttached("HeaderWidth", typeof(string), typeof(FormGroup), new FrameworkPropertyMetadata("Auto", FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region HeaderHeight

        public static string GetItemsHeaderHeight(DependencyObject obj)
        {
            return (string)obj.GetValue(HeaderHeightProperty);
        }

        public static void SetItemsHeaderHeight(DependencyObject obj, string value)
        {
            obj.SetValue(HeaderHeightProperty, value);
        }

        public string HeaderHeight
        {
            get { return (string)GetValue(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }

        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.RegisterAttached("HeaderHeight", typeof(string), typeof(FormGroup), new FrameworkPropertyMetadata("*", FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region Header
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(FormGroup));
        #endregion

        #region HeaderTemplate


        public static DataTemplate GetHeaderTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(HeaderTemplateProperty);
        }

        public static void SetHeaderTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(HeaderTemplateProperty, value);
        }

        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(FormGroup));
        #endregion

        #region HeaderTemplateSelector
        public static DataTemplateSelector GetHeaderTemplateSelector(DependencyObject obj)
        {
            return (DataTemplateSelector)obj.GetValue(HeaderTemplateSelectorProperty);
        }

        public static void SetHeaderTemplateSelector(DependencyObject obj, DataTemplateSelector value)
        {
            obj.SetValue(HeaderTemplateSelectorProperty, value);
        }

        public DataTemplateSelector HeaderTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(HeaderTemplateSelectorProperty); }
            set { SetValue(HeaderTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateSelectorProperty =
            DependencyProperty.Register("HeaderTemplateSelector", typeof(DataTemplateSelector), typeof(FormGroup));
        #endregion

        #region IsRequired


        public static bool GetItemsIsRequired(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsRequiredProperty);
        }

        public static void SetItemsIsRequired(DependencyObject obj, bool value)
        {
            obj.SetValue(IsRequiredProperty, value);
        }

        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.RegisterAttached("IsRequired", typeof(bool), typeof(FormGroup), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #endregion
    }
}
