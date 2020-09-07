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
            DependencyProperty sourceProperty,
            BindingMode mode = BindingMode.OneWay)
        {
            var binding = new Binding()
            {
                Path = new PropertyPath(sourceProperty),
                Source = source,
                Mode = mode,
            };
            element.SetBinding(targetProperty, binding);
        }

        public static void BindingProperty(FrameworkElement element,
            DependencyProperty targetProperty,
            object source,
            DependencyProperty sourceProperty,
            BindingMode mode,
            UpdateSourceTrigger trigger = UpdateSourceTrigger.Default)
        {
            var binding = new Binding()
            {
                Path = new PropertyPath(sourceProperty),
                Source = source,
                Mode = mode,
                UpdateSourceTrigger = trigger
            };
            element.SetBinding(targetProperty, binding);
        }

        public static void BindingPropertyIfNonDefault(FrameworkElement element,
         DependencyProperty targetProperty,
         DependencyObject source,
         DependencyProperty sourceProperty,
            BindingMode mode = BindingMode.OneWay)
        {
            if(DependencyObjectUtils.IsDefaultValue(source, sourceProperty))
            {
                var binding = new Binding()
                {
                    Path = new PropertyPath(sourceProperty),
                    Source = source,
                    Mode = mode,
                };
                element.SetBinding(targetProperty, binding);
            }
        }


        public static void BindingProperty(FrameworkElement element,
            DependencyProperty targetProperty,
            object source, 
            DependencyProperty sourceProperty,
            IValueConverter converter,
            BindingMode mode = BindingMode.OneWay)
        {
            var binding = new Binding()
            {
                Path = new PropertyPath(sourceProperty),
                Source = source,
                Mode = mode,
                Converter = converter,
            };
            element.SetBinding(targetProperty, binding);
        }

        public static void BindingProperty(FrameworkElement element,
           DependencyProperty targetProperty,
           object source,
           DependencyProperty sourceProperty,
           string stringFormat,
           BindingMode mode = BindingMode.OneWay)
        {
            var binding = new Binding()
            {
                Path = new PropertyPath(sourceProperty),
                Source = source,
                Mode = mode,
                StringFormat = stringFormat,
            };
            element.SetBinding(targetProperty, binding);
        }


        public static void BindingProperty(FrameworkElementFactory factory, 
            DependencyProperty targetProperty,
            object source,
            DependencyProperty sourceProperty,
            BindingMode mode = BindingMode.OneWay)
        {
            var binding = new Binding()
            {
                Path = new PropertyPath(sourceProperty),
                Source = source,
                Mode = mode,
            };
            factory.SetBinding(targetProperty, binding);
        }

        public static void BindingPropertyIfNonDefault(FrameworkElementFactory factory,
        DependencyProperty targetProperty,
        DependencyObject source,
        DependencyProperty sourceProperty,
            BindingMode mode = BindingMode.OneWay)
        {
            if (!DependencyObjectUtils.IsDefaultValue(source, sourceProperty))
            {
                var binding = new Binding()
                {
                    Path = new PropertyPath(sourceProperty),
                    Source = source,
                    Mode = mode,
                };
                factory.SetBinding(targetProperty, binding);
            }
        }
        public static void BindingPropertyIfNonDefault(FrameworkElement element,
            DependencyProperty targetProperty,
            DependencyObject source,
            DependencyProperty sourceProperty,
            IValueConverter converter,
            BindingMode mode = BindingMode.OneWay)
        {
            if (DependencyObjectUtils.IsDefaultValue(source, sourceProperty))
            {
                var binding = new Binding()
                {
                    Path = new PropertyPath(sourceProperty),
                    Source = source,
                    Mode = mode,
                    Converter = converter,
                };
                element.SetBinding(targetProperty, binding);
            }
        }

        public static void BindingProperty(FrameworkElementFactory factory,
            DependencyProperty targetProperty, 
            object source,
            DependencyProperty sourceProperty,
            IValueConverter converter,
            BindingMode mode = BindingMode.OneWay)
        {
            var binding = new Binding()
            {
                Path = new PropertyPath(sourceProperty),
                Source = source,
                Mode = mode,
                Converter = converter,
            };
            factory.SetBinding(targetProperty, binding);
        }

        public static void BindingPropertyIfNonDefault(FrameworkElementFactory factory,
            DependencyProperty targetProperty,
            DependencyObject source,
            DependencyProperty sourceProperty,
            IValueConverter converter,
            BindingMode mode = BindingMode.OneWay)
        {
            if (!DependencyObjectUtils.IsDefaultValue(source, sourceProperty))
            {
                var binding = new Binding()
                {
                    Path = new PropertyPath(sourceProperty),
                    Source = source,
                    Mode = mode,
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
