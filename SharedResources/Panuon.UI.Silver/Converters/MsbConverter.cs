using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Converters
{
    internal class MsbButtonVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tag = parameter.ToString();
            var msbButton = (MessageBoxButton)Enum.Parse(typeof(MessageBoxButton), value.ToString());
            if (tag == "Yes")
            {
                switch (msbButton)
                {
                    case MessageBoxButton.YesNo:
                    case MessageBoxButton.YesNoCancel:
                        return Visibility.Visible;
                    default:
                        return Visibility.Collapsed;
                }
            }
            else if (tag == "No")
            {
                switch (msbButton)
                {
                    case MessageBoxButton.YesNo:
                    case MessageBoxButton.YesNoCancel:
                        return Visibility.Visible;
                    default:
                        return Visibility.Collapsed;
                }
            }
            else if (tag == "Cancel")
            {
                switch (msbButton)
                {
                    case MessageBoxButton.YesNoCancel:
                    case MessageBoxButton.OKCancel:
                        return Visibility.Visible;
                    default:
                        return Visibility.Collapsed;
                }
            }
            else if (tag == "OK")
            {
                switch (msbButton)
                {
                    case MessageBoxButton.OK:
                    case MessageBoxButton.OKCancel:
                        return Visibility.Visible;
                    default:
                        return Visibility.Collapsed;
                }
            }
            else
            {
                return Visibility.Collapsed;
            }

        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class MsbButtonIsDefaultConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var defaultButton = (DefaultButton)values[0];
            var msbButtons = (MessageBoxButton)values[1];

            var tag = parameter.ToString();

            if (tag == "Yes")
            {
                switch (msbButtons)
                {
                    case MessageBoxButton.YesNo:
                    case MessageBoxButton.YesNoCancel:
                        switch (defaultButton)
                        {
                            case DefaultButton.YesOK:
                                return true;
                        }
                        break;
                }
            }
            else if (tag == "No")
            {
                switch (msbButtons)
                {
                    case MessageBoxButton.YesNo:
                        if (defaultButton == DefaultButton.NoOrCancel)
                            return true;
                        break;
                }
            }
            else if (tag == "Cancel")
            {
                switch (msbButtons)
                {
                    case MessageBoxButton.OKCancel:
                        switch (defaultButton)
                        {
                            case DefaultButton.NoOrCancel:
                            case DefaultButton.CancelOrNo:
                                return true;
                        }
                        break;
                    case MessageBoxButton.YesNoCancel:
                        if (defaultButton == DefaultButton.CancelOrNo)
                            return true;
                        break;
                }
            }
            else if (tag == "OK")
            {
                switch (msbButtons)
                {
                    case MessageBoxButton.OK:
                    case MessageBoxButton.OKCancel:
                        if (defaultButton == DefaultButton.YesOK)
                            return true;
                        break;
                }
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class MsbCheckIconVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var icon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), value.ToString());

            switch (icon)
            {
                case MessageBoxIcon.None:
                    return Visibility.Collapsed;
                default:
                    return Visibility.Visible;
            }


        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }


    internal class MsbCheckIconWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var icon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), value.ToString());

            switch (icon)
            {
                case MessageBoxIcon.None:
                    return new GridLength(20);
                default:
                    return new GridLength(140);
            }
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

}
