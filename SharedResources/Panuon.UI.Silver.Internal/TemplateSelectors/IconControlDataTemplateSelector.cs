using Panuon.UI.Silver.Internal.Converters;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver.Internal.TemplateSelectors
{
    internal class IconControlDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                if (item is ImageSource)
                {
                    return CreateImageDataTemplate(item);
                }
                else if (item is System.Drawing.Icon)
                {
                    return CreateIconImageDataTemplate(item);
                }
                else if (item is string)
                {
                    var iconString = (string)item;
                    if (Uri.IsWellFormedUriString(iconString, UriKind.RelativeOrAbsolute))
                    {
                        return CreateImageDataTemplate(item);
                    }
                }

            }

            return CreateContentDataTemplate(item);
        }

        #region Function
        private DataTemplate CreateImageDataTemplate(object item)
        {
            var factory = new FrameworkElementFactory(typeof(Image));
            var imageSource = new Binding() { Source = item };
            factory.SetBinding(Image.SourceProperty, imageSource);
            factory.SetValue(RenderOptions.BitmapScalingModeProperty, BitmapScalingMode.HighQuality);
            var dataTemplate = new DataTemplate
            {
                VisualTree = factory
            };
            dataTemplate.Seal();
            return dataTemplate;
        }

        private DataTemplate CreateContentDataTemplate(object item)
        {
            var factory = new FrameworkElementFactory(typeof(ContentControl));
            var content = new Binding() { Source = item };
            factory.SetBinding(ContentControl.ContentProperty, content);
            var dataTemplate = new DataTemplate
            {
                VisualTree = factory
            };
            dataTemplate.Seal();
            return dataTemplate;
        }

        private DataTemplate CreateIconImageDataTemplate(object item)
        {
            var factory = new FrameworkElementFactory(typeof(Image));
            var imageSource = new Binding() { Source = item, Converter = new IconToImageSourceConverter() };
            factory.SetBinding(Image.SourceProperty, imageSource);
            factory.SetValue(RenderOptions.BitmapScalingModeProperty, BitmapScalingMode.HighQuality);
            var dataTemplate = new DataTemplate
            {
                VisualTree = factory
            };
            dataTemplate.Seal();
            return dataTemplate;
        }


        #endregion
    }
}
