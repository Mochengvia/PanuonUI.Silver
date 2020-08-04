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
            ContentTemplateSelector = new IconControlContentTemplateSelector();
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
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
            if(Source != null)
            {
                UIElementUtils.BindingProperty(this, HeightProperty, IconHelper.HeightProperty, Source);
                UIElementUtils.BindingProperty(this, WidthProperty, IconHelper.WidthProperty, Source);
                UIElementUtils.BindingProperty(this, MinWidthProperty, IconHelper.MinWidthProperty, Source);
                UIElementUtils.BindingProperty(this, MinHeightProperty, IconHelper.MinHeightProperty, Source);
                UIElementUtils.BindingProperty(this, MaxWidthProperty, IconHelper.MaxWidthProperty, Source);
                UIElementUtils.BindingProperty(this, MaxHeightProperty, IconHelper.MaxHeightProperty, Source);
                UIElementUtils.BindingProperty(this, MarginProperty, IconHelper.MarginProperty, Source);
                UIElementUtils.BindingProperty(this, FontFamilyProperty, IconHelper.FontFamilyProperty, Source);
                UIElementUtils.BindingProperty(this, ForegroundProperty, IconHelper.ForegroundProperty, Source);
                UIElementUtils.BindingProperty(this, FontSizeProperty, IconHelper.FontSizeProperty, Source);
                UIElementUtils.BindingProperty(this, VisibilityProperty, ContentProperty, this, new NullToCollapseConverter());
            }
        }
        #endregion
    }
}
