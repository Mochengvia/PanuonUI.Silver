using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UIBrowser.ViewModels;

namespace UIBrowser.Models
{
    public class SourceElementCore
    {
        #region Ctor
        public SourceElementCore(string elementName)
        {
            ElementName = elementName;
        }
        #endregion

        #region Property
        public string ElementName { get; set; }

        public IList<DependencyPropertyItem> DependencyProperties { get; } = new List<DependencyPropertyItem>();

        public IList<AttachedPropertyItem> AttachedProperties { get; } = new List<AttachedPropertyItem>();
        #endregion

        #region Methods
        public string ToSourceCode()
        {
            var result = $"<{ElementName} ";

            var properties = new List<string>();

            foreach (var property in DependencyProperties)
            {
                properties.Add(property.ToSourceCode());
            }
            foreach (var property in AttachedProperties)
            {
                properties.Add(property.ToSourceCode());
            }

            result += string.Join("\n", properties);

            result += " />";

            return result;
        }

        public string ToStyleCode(string baseStylePropertyName = null)
        {
            var baseStyleAttachedProperty = AttachedProperties.FirstOrDefault(x => x.PropertyName == baseStylePropertyName);

            var result = $"<Style TargetType=\"{{x:Type {ElementName}}}\"\nBasedOn=\"{{StaticResource {{x:Type {ElementName}}}}}\" >\n";

            var properties = new List<string>();

            foreach (var property in DependencyProperties)
            {
                properties.Add(property.ToStyleCode());
            }
            foreach (var property in AttachedProperties)
            {
                if (property.PropertyName == baseStylePropertyName)
                    continue;
                properties.Add(property.ToStyleCode());
            }

            if (baseStyleAttachedProperty != null)
            {
                result += $"{baseStyleAttachedProperty.ToStyleCode()}\n";
                result += $"<Style.Triggers>\n<DataTrigger Binding=\"{{Binding Path=(pu:{baseStyleAttachedProperty.AttachedPropertyClassType.Name}.{baseStyleAttachedProperty.PropertyName}),RelativeSource={{RelativeSource Self}}, Mode=OneWay}}\"\nValue=\"{baseStyleAttachedProperty.PropertyValue}\">\n";
            }

            result += string.Join("\n", properties);

            if (baseStyleAttachedProperty != null)
                result += $"\n</DataTrigger>\n</Style.Triggers>\n";

            result += "</Style>";

            return result;
        }

       
        #endregion
    }


}
