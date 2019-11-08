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

            foreach (var property in core.DependencyProperties)
            {
                var propertyInfo = propertyInfos.FirstOrDefault(x => x.Name == property.PropertyName);
                if (propertyInfo == null)
                    continue;

                var elementPropertyInfo = elementPropertyInfos.FirstOrDefault(x => x.Name == property.PropertyName);
                if (elementPropertyInfo == null)
                    continue;

                propertyInfo.SetValue(viewModel, elementPropertyInfo.GetValue(element));
            }

            foreach(var property in core.AttachedProperties)
            {
                var propertyInfo = propertyInfos.FirstOrDefault(x => x.Name == property.PropertyName);
                if (propertyInfo == null)
                    continue;
                var fi = (property.AttachedPropertyClassType.GetMember($"{property.PropertyName}Property")[0] as FieldInfo);
                var dependencyProperty = fi.GetValue(element) as DependencyProperty;
                propertyInfo.SetValue(viewModel, element.GetValue(dependencyProperty));
            }
        }
    }

}
