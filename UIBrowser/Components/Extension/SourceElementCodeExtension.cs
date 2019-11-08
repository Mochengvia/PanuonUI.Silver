using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UIBrowser.Models;
using UIBrowser.ViewModels;

namespace UIBrowser
{
    public static class SourceElementCodeExtension
    {
        public static void UpdateViewModelProperties(this SourceElementCore core, ControlViewModelBase viewModel, FrameworkElement element)
        {
            var propertyInfos = viewModel.GetType().GetProperties();
            var elementPropertyInfos = element.GetType().GetProperties();

            var baseStyleProperty = core.AttachedProperties.FirstOrDefault(x => x.PropertyName == core.BaseStylePropertyName);
            if(baseStyleProperty != null)
            {
                var propertyInfo = propertyInfos.FirstOrDefault(x => x.Name == baseStyleProperty.PropertyName);
                if (propertyInfo != null)
                {
                    var fi = (baseStyleProperty.AttachedPropertyClassType.GetMember($"{baseStyleProperty.PropertyName}Property")[0] as FieldInfo);
                    var dependencyProperty = fi.GetValue(element) as DependencyProperty;
                    propertyInfo.SetValue(viewModel, element.GetValue(dependencyProperty));
                }
            }

            foreach (var property in core.DependencyProperties)
            {
                var propertyInfo = propertyInfos.FirstOrDefault(x => x.Name == property.PropertyName);
                if (propertyInfo == null)
                    continue;

                var elementPropertyInfo = elementPropertyInfos.FirstOrDefault(x => x.Name == property.PropertyName);
                if (elementPropertyInfo == null)
                    continue;
                var val = elementPropertyInfo.GetValue(element);
                propertyInfo.SetValue(viewModel, elementPropertyInfo.GetValue(element));
            }

            foreach(var property in core.AttachedProperties)
            {
                if (property.PropertyName == core.BaseStylePropertyName)
                    continue;

                var propertyInfo = propertyInfos.FirstOrDefault(x => x.Name == property.PropertyName);
                if (propertyInfo == null)
                    continue;
                var fi = (property.AttachedPropertyClassType.GetMember($"{property.PropertyName}Property")[0] as FieldInfo);
                var dependencyProperty = fi.GetValue(element) as DependencyProperty;

                var value = element.GetValue(dependencyProperty);

                if (propertyInfo.PropertyType == typeof(double) && dependencyProperty.PropertyType == typeof(CornerRadius))
                    value = ((CornerRadius)value).TopLeft;
                propertyInfo.SetValue(viewModel, value);
            }
        }
    }

}
