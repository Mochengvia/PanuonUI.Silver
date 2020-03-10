using Panuon.UI.Silver.Core;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class StateControlTemplateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var state = values[0];
            var states = values[1] as ObservableCollection<StateItem>;
            if(state == null || states == null)
            {
                return null;
            }
            var targetState = states.FirstOrDefault(x => x.State.ToString().ToLower().Equals(state.ToString().ToLower()));
            if(targetState == null)
            {
                targetState = states.FirstOrDefault(x => x.State == null);
            }
            return targetState?.Template;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var propertyValues = new object[targetTypes.Length];
            propertyValues.Init(DependencyProperty.UnsetValue);
            return propertyValues;
        }
    }
}
