using Panuon.UI.Silver.Core;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
namespace Panuon.UI.Silver.Internal.Converters
{
    internal class MsgBoxIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var icon = value as MessageBoxIcon? ?? MessageBoxIcon.None;
            switch (icon) 
            {
                case MessageBoxIcon.Info:
                    return "\ue92f";
                case MessageBoxIcon.Question:
                    return "\ue937";
                case MessageBoxIcon.Success:
                    return "\ue935";
                case MessageBoxIcon.Error:
                    return "\ue933";
                case MessageBoxIcon.Warning:
                    return "\ue931";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class MsgBoxIconForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var icon = value as MessageBoxIcon? ?? MessageBoxIcon.None;
            switch (icon)
            {
                case MessageBoxIcon.Info:
                    return "#80BEE8".ToColor().ToBrush();
                case MessageBoxIcon.Question:
                    return "#80BEE8".ToColor().ToBrush();
                case MessageBoxIcon.Success:
                    return "#75CD43".ToColor().ToBrush();
                case MessageBoxIcon.Error:
                    return "#FF5656".ToColor().ToBrush();
                case MessageBoxIcon.Warning:
                    return "#F9D01A".ToColor().ToBrush();
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class MsgBoxButtonVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var button = value as MessageBoxButton? ?? MessageBoxButton.OK;
            var buttonTag = parameter.ToString();
            switch (button)
            {
                case MessageBoxButton.OKCancel:
                    return buttonTag == "OK" || buttonTag == "Cancel" ? Visibility.Visible : Visibility.Collapsed;
                case MessageBoxButton.YesNo:
                    return buttonTag == "Yes" || buttonTag == "No" ? Visibility.Visible : Visibility.Collapsed;
                case MessageBoxButton.YesNoCancel:
                    return buttonTag == "Yes" || buttonTag == "No" || buttonTag == "Cancel" ? Visibility.Visible : Visibility.Collapsed;
                default:
                    return buttonTag == "OK" ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class MsgBoxButtonIsDefaultConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var button = values[0] as MessageBoxButton? ?? MessageBoxButton.OK;
            var defaultButton = values[1] as DefaultButton? ?? DefaultButton.Unset;
            var buttonTag = parameter.ToString();
            switch (defaultButton)
            {
                case DefaultButton.YesOK:
                    switch (button) 
                    {
                        case MessageBoxButton.OK:
                        case MessageBoxButton.OKCancel:
                            return buttonTag == "OK";
                        default:
                            return buttonTag == "Yes";
                    }
                case DefaultButton.NoCancel:
                    switch (button)
                    {
                        case MessageBoxButton.YesNo:
                        case MessageBoxButton.YesNoCancel:
                            return buttonTag == "No";
                        case MessageBoxButton.OKCancel:
                            return buttonTag == "Cancel";
                        default:
                            return false;
                    }
                case DefaultButton.CancelNo:
                    switch (button)
                    {
                        case MessageBoxButton.YesNoCancel:
                        case MessageBoxButton.OKCancel:
                            return buttonTag == "Cancel";
                            case MessageBoxButton.YesNo:
                            return buttonTag == "No";
                        default:
                            return false;
                    }
                default:
                    return false;
            }
        }

        public object[] ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class MsgBoxStackPanelFlowDirectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var reverse = value as bool? ?? false;
            return reverse ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
