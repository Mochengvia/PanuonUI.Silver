using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Panuon.UI.Silver
{
    public abstract class FormGroup : DependencyObject
    {
        #region Properties

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
        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(FormGroup));
        #endregion

        #region HeaderTemplateSelector
        public DataTemplateSelector HeaderTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(HeaderTemplateSelectorProperty); }
            set { SetValue(HeaderTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateSelectorProperty =
            DependencyProperty.Register("HeaderTemplateSelector", typeof(DataTemplateSelector), typeof(FormGroup));
        #endregion

        #region HeaderPadding
        public Thickness HeaderPadding
        {
            get { return (Thickness)GetValue(HeaderPaddingProperty); }
            set { SetValue(HeaderPaddingProperty, value); }
        }

        public static readonly DependencyProperty HeaderPaddingProperty =
            DependencyProperty.Register("HeaderPadding", typeof(Thickness), typeof(FormGroup));
        #endregion

        #region HeaderHeight
        public GridLength HeaderHeight
        {
            get { return (GridLength)GetValue(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }

        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.Register("HeaderHeight", typeof(GridLength), typeof(FormGroup));
        #endregion

        #region HeaderWidth
        public GridLength HeaderWidth
        {
            get { return (GridLength)GetValue(HeaderWidthProperty); }
            set { SetValue(HeaderWidthProperty, value); }
        }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.Register("HeaderWidth", typeof(GridLength), typeof(FormGroup));
        #endregion

        #region Height
        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(double), typeof(FormGroup));
        #endregion


        #endregion

        #region Internal Properties
        internal double ActualHeaderWidth
        {
            get { return (double)GetValue(ActualHeaderWidthProperty); }
            set { SetValue(ActualHeaderWidthProperty, value); }
        }

        internal static readonly DependencyProperty ActualHeaderWidthProperty =
            DependencyProperty.Register("ActualHeaderWidth", typeof(double), typeof(FormGroup));
        #endregion
    }
}
