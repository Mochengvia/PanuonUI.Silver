using System;
using System.Windows;
using System.Windows.Input;

namespace UIBrowser.Palette
{
    public static class PaletteHelper
    {
        #region RegistControl
        public static bool GetRegistControl(DependencyObject obj)
        {
            return (bool)obj.GetValue(RegistControlProperty);
        }

        public static void SetRegistControl(DependencyObject obj, bool value)
        {
            obj.SetValue(RegistControlProperty, value);
        }

        public static readonly DependencyProperty RegistControlProperty =
            DependencyProperty.RegisterAttached("RegistControl", typeof(bool), typeof(PaletteHelper), new PropertyMetadata(OnRegistControlChanged));
        #endregion

        #region Event Handlers
        private static void OnRegistControlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as FrameworkElement;
            element.PreviewMouseLeftButtonDown += Element_PreviewMouseLeftButtonDown;
        }


        private static void Element_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                var element = sender as FrameworkElement;
            }
        }
        #endregion
    }
}
