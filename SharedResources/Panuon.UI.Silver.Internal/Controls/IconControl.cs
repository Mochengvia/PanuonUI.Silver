using Panuon.UI.Silver.Internal.Converters;
using Panuon.UI.Silver.Internal.Selectors;
using Panuon.UI.Silver.Internal.Utils;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Controls
{
    class IconControl : ContentControl
    {
        #region Ctor
        public IconControl()
        {
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;
            ContentTemplateSelector = new IconControlContentTemplateSelector();
        }

        static IconControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconControl), new FrameworkPropertyMetadata(typeof(IconControl)));
        }
        #endregion

        #region Properties

        #region Source
        public UIElement Source
        {
            get { return (UIElement)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(UIElement), typeof(IconControl), new PropertyMetadata(OnSourceChanged));

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var iconControl = d as IconControl;
            iconControl.UpdateBinding();
        }
        #endregion

        #endregion

        #region Overrides
        protected override void OnContentTemplateChanged(DataTemplate oldContentTemplate, DataTemplate newContentTemplate)
        {
            base.OnContentTemplateChanged(oldContentTemplate, newContentTemplate);

        }
        #endregion

        #region Function
        private void UpdateBinding()
        {
            if (Source != null)
            {
                BindingUtils.BindingProperty(this, HeightProperty, Source, IconHelper.HeightProperty);
                BindingUtils.BindingProperty(this, WidthProperty, Source, IconHelper.WidthProperty);
                BindingUtils.BindingProperty(this, MinWidthProperty, Source, IconHelper.MinWidthProperty);
                BindingUtils.BindingProperty(this, MinHeightProperty, Source, IconHelper.MinHeightProperty);
                BindingUtils.BindingProperty(this, MaxWidthProperty, Source, IconHelper.MaxWidthProperty);
                BindingUtils.BindingProperty(this, MaxHeightProperty, Source, IconHelper.MaxHeightProperty);
                BindingUtils.BindingProperty(this, MarginProperty, Source, IconHelper.MarginProperty);
                BindingUtils.BindingProperty(this, PaddingProperty, Source, IconHelper.PaddingProperty);
                BindingUtils.BindingProperty(this, FontFamilyProperty, Source, IconHelper.FontFamilyProperty);
                BindingUtils.BindingProperty(this, ForegroundProperty, Source, IconHelper.ForegroundProperty);
                BindingUtils.BindingProperty(this, FontSizeProperty, Source, IconHelper.FontSizeProperty);
                BindingUtils.BindingProperty(this, VisibilityProperty, this, ContentProperty, new NullToCollapseConverter());
            }
        }
        #endregion
    }
}
