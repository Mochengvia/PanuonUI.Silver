using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace UIBrowser
{
    public static class ThemeResources
    {
        public static Brush GetPresetThemeBrush(PresetTheme presetTheme)
        {
            switch (presetTheme)
            {
                case PresetTheme.CandyBlue:
                    return Application.Current.MainWindow.FindResource("CandyBlue") as SolidColorBrush;
                case PresetTheme.CandyGreen:
                    return Application.Current.MainWindow.FindResource("CandyGreen") as SolidColorBrush;
                case PresetTheme.CandyOrange:
                    return Application.Current.MainWindow.FindResource("CandyOrange") as SolidColorBrush;
                case PresetTheme.CandyPink:
                    return Application.Current.MainWindow.FindResource("CandyPink") as SolidColorBrush;
                case PresetTheme.CandyYellow:
                    return Application.Current.MainWindow.FindResource("CandyYellow") as SolidColorBrush;
                default:
                    return Brushes.Transparent;
            }
        }

        public static Brush GetLightPresetThemeBrush(PresetTheme presetTheme)
        {
            switch (presetTheme)
            {
                case PresetTheme.CandyBlue:
                    return Application.Current.MainWindow.FindResource("LightCandyBlue") as SolidColorBrush;
                case PresetTheme.CandyGreen:
                    return Application.Current.MainWindow.FindResource("LightCandyGreen") as SolidColorBrush;
                case PresetTheme.CandyOrange:
                    return Application.Current.MainWindow.FindResource("LightCandyOrange") as SolidColorBrush;
                case PresetTheme.CandyPink:
                    return Application.Current.MainWindow.FindResource("LightCandyPink") as SolidColorBrush;
                case PresetTheme.CandyYellow:
                    return Application.Current.MainWindow.FindResource("LightCandyYellow") as SolidColorBrush;
                default:
                    return Brushes.Transparent;
            }
        }
    }
}
