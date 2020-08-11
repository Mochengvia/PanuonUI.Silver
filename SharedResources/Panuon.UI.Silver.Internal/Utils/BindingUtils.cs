using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Utils
{
    static class BindingUtils
    {
        #region Binding
        public static void BindingProperty(FrameworkElement element,
            DependencyProperty targetProperty,
            object source,
            DependencyProperty sourceProperty)
        {
            var binding = new Binding()
            {
                Path = new PropertyPath(sourceProperty),
                Source = source,
                Mode = BindingMode.OneWay,
            };
            element.SetBinding(targetProperty, binding);
        }

        public static void BindingPropertyIfNonDefault(FrameworkElement element,
         DependencyProperty targetProperty,
         DependencyObject source,
         DependencyProperty sourceProperty)
        {
            if(DependencyObjectUtils.IsDefaultValue(source, sourceProperty))
            {
                var binding = new Binding()
                {
                    Path = new PropertyPath(sourceProperty),
                    Source = source,
                    Mode = BindingMode.OneWay,
                };
                element.SetBinding(targetProperty, binding);
            }
        }


        public static void BindingProperty(FrameworkElement element,
            DependencyProperty targetProperty,
            object source, 
            DependencyProperty sourceProperty,
            IValueConverter converter)
        {
            var binding = new Binding()
            {
                Path = new PropertyPath(sourceProperty),
                Source = source,
                Mode = BindingMode.OneWay,
                Converter = converter,
            };
            element.SetBinding(targetProperty, binding);
        }

        public static void BindingProperty(FrameworkElementFactory factory, 
            DependencyProperty targetProperty,
            object source,
            DependencyProperty sourceProperty)
        {
            var binding = new Binding()
            {
                Path = new PropertyPath(sourceProperty),
                Source = source,
                Mode = BindingMode.OneWay,
            };
            factory.SetBinding(targetProperty, binding);
        }

        public static void BindingPropertyIfNonDefault(FrameworkElementFactory factory,
        DependencyProperty targetProperty,
        DependencyObject source,
        DependencyProperty sourceProperty)
        {
            if (!DependencyObjectUtils.IsDefaultValue(source, sourceProperty))
            {
                var binding = new Binding()
                {
                    Path = new PropertyPath(sourceProperty),
                    Source = source,
                    Mode = BindingMode.OneWay,
                };
                factory.SetBinding(targetProperty, binding);
            }
        }
        public static void BindingPropertyIfNonDefault(FrameworkElement element,
    DependencyProperty targetProperty,
    DependencyObject source,
    DependencyProperty sourceProperty,
    IValueConverter converter)
        {
            if (DependencyObjectUtils.IsDefaultValue(source, sourceProperty))
            {
                var binding = new Binding()
                {
                    Path = new PropertyPath(sourceProperty),
                    Source = source,
                    Mode = BindingMode.OneWay,
                    Converter = converter,
                };
                element.SetBinding(targetProperty, binding);
            }
        }

        public static void BindingProperty(FrameworkElementFactory factory,
            DependencyProperty targetProperty, 
            object source,
            DependencyProperty sourceProperty,
            IValueConverter converter)
        {
            var binding = new Binding()
            {
                Path = new PropertyPath(sourceProperty),
                Source = source,
                Mode = BindingMode.OneWay,
                Converter = converter,
            };
            factory.SetBinding(targetProperty, binding);
        }

        public static void BindingPropertyIfNonDefault(FrameworkElementFactory factory,
            DependencyProperty targetProperty,
            DependencyObject source,
            DependencyProperty sourceProperty,
            IValueConverter converter)
        {
            if (!DependencyObjectUtils.IsDefaultValue(source, sourceProperty))
            {
                var binding = new Binding()
                {
                    Path = new PropertyPath(sourceProperty),
                    Source = source,
                    Mode = BindingMode.OneWay,
                    Converter = converter,
                };
                factory.SetBinding(targetProperty, binding);
            }
        }

        public static void BindingProperty(FrameworkElement targetElement,
            DependencyProperty targetProperty, 
            DependencyObject source,
            DependencyProperty childObjProperty,
            FrameworkElement defaultSource,
            DependencyProperty defaultSourceProperty)
        {

            var isDefault = DependencyObjectUtils.IsDefaultValue(source, childObjProperty);
            var bindingProperty = isDefault ? defaultSourceProperty : childObjProperty;
            var actualSource = isDefault ? defaultSource : source;
            BindingProperty(targetElement, targetProperty, actualSource, bindingProperty);
        }
        #endregion


    }
}
