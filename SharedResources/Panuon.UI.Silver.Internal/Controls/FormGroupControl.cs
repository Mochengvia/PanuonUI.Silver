using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Internal.Controls
{
    class FormGroupControl : ContentControl
    {
        #region Fields
        private Border _border;
        #endregion

        #region Events
        internal event EventHandler ActualHeaderWidthChanged;
        #endregion

        #region Ctor
        static FormGroupControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FormGroupControl), new FrameworkPropertyMetadata(typeof(FormGroupControl)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Dispatcher.BeginInvoke(new Action(() =>
            {
                _border = Template?.FindName("PART_HeaderBorder", this) as Border;
                ActualHeaderWidthChanged(this, new EventArgs());
            }), DispatcherPriority.Loaded);
        }
        #endregion

        #region Header
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(FormGroupControl));
        #endregion

        #region HeaderTemplate
        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(FormGroupControl));
        #endregion

        #region HeaderTemplateSelector
        public DataTemplateSelector HeaderTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(HeaderTemplateSelectorProperty); }
            set { SetValue(HeaderTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateSelectorProperty =
            DependencyProperty.Register("HeaderTemplateSelector", typeof(DataTemplateSelector), typeof(FormGroupControl));
        #endregion

        #region HeaderPadding
        public Thickness HeaderPadding
        {
            get { return (Thickness)GetValue(HeaderPaddingProperty); }
            set { SetValue(HeaderPaddingProperty, value); }
        }

        public static readonly DependencyProperty HeaderPaddingProperty =
            DependencyProperty.Register("HeaderPadding", typeof(Thickness), typeof(FormGroupControl));
        #endregion

        #region HeaderHeight
        public GridLength HeaderHeight
        {
            get { return (GridLength)GetValue(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }

        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.Register("HeaderHeight", typeof(GridLength), typeof(FormGroupControl));
        #endregion

        #region HeaderWidth
        public GridLength HeaderWidth
        {
            get { return (GridLength)GetValue(HeaderWidthProperty); }
            set { SetValue(HeaderWidthProperty, value); }
        }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.Register("HeaderWidth", typeof(GridLength), typeof(FormGroupControl));
        #endregion

        #region RowSpacing
        public double RowSpacing
        {
            get { return (double)GetValue(RowSpacingProperty); }
            set { SetValue(RowSpacingProperty, value); }
        }

        public static readonly DependencyProperty RowSpacingProperty =
            DependencyProperty.Register("RowSpacing", typeof(double), typeof(FormGroupControl));
        #endregion

        #region ActualHeaderWidth
        public double ActualHeaderWidth => _border.ActualWidth;
        #endregion
    }
}
