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
        public SourceElementCore(string elementName, string baseStylePropertyName)
        {
            ElementName = elementName;
            BaseStylePropertyName = baseStylePropertyName;
        }
        #endregion

        #region Property
        public string ElementName { get; set; }

        public string BaseStylePropertyName { get; set; }

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
                if(property.PropertyValue != property.DefaultValue)
                    properties.Add(property.ToSourceCode());
            }
            foreach (var property in AttachedProperties)
            {
                if(property.PropertyValue != property.DefaultValue)
                    properties.Add(property.ToSourceCode());
            }

            result += string.Join("\n", properties);

            result += " />";

            return result;
        }

        public string ToStyleCode()
        {
            var baseStyleAttachedProperty = AttachedProperties.FirstOrDefault(x => x.PropertyName == BaseStylePropertyName);

            var result = $"<Style TargetType=\"{{x:Type {ElementName}}}\"\nBasedOn=\"{{StaticResource {{x:Type {ElementName}}}}}\" >\n";

            var properties = new List<string>();

            foreach (var property in DependencyProperties)
            {
                if(property.PropertyValue != property.DefaultValue)
                    properties.Add(property.ToStyleCode());
            }
            foreach (var property in AttachedProperties)
            {
                if (property.PropertyName == BaseStylePropertyName)
                    continue;
                if(property.PropertyValue != property.DefaultValue)
                    properties.Add(property.ToStyleCode());
            }

            if (baseStyleAttachedProperty != null && baseStyleAttachedProperty.PropertyValue != baseStyleAttachedProperty.DefaultValue)
            {
                result += $"{baseStyleAttachedProperty.ToStyleCode()}\n";
                result += $"<Style.Triggers>\n<DataTrigger Binding=\"{{Binding Path=(pu:{baseStyleAttachedProperty.AttachedPropertyClassType.Name}.{baseStyleAttachedProperty.PropertyName}),RelativeSource={{RelativeSource Self}}, Mode=OneWay}}\"\nValue=\"{baseStyleAttachedProperty.PropertyValue}\">\n";
            }

            result += string.Join("\n", properties);

            if (baseStyleAttachedProperty != null && baseStyleAttachedProperty.PropertyValue != baseStyleAttachedProperty.DefaultValue)
                result += $"\n</DataTrigger>\n</Style.Triggers>\n";

            result += "</Style>";

            return result;
        }
        #endregion
    }


}
