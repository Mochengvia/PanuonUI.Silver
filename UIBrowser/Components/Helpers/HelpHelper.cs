using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UIBrowser.ViewModels;

namespace UIBrowser
{
    public class HelpHelper
    {
        #region DataContext
        public static object GetDataContext(DependencyObject obj)
        {
            return (object)obj.GetValue(DataContextProperty);
        }

        public static void SetDataContext(DependencyObject obj, object value)
        {
            obj.SetValue(DataContextProperty, value);
        }

        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.RegisterAttached("DataContext", typeof(object), typeof(HelpHelper), new PropertyMetadata(OnDataContextChanged));
        #endregion

        #region Event Handler
        private static void OnDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as FrameworkElement;
            element.PreviewMouseDown += Element_PreviewMouseDown;
        }

        private static void Element_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Keyboard.GetKeyStates(Key.LeftCtrl) != KeyStates.None || Keyboard.GetKeyStates(Key.RightCtrl) != KeyStates.None)
            {
                var element = sender as FrameworkElement;
                var viewModel = GetDataContext(element) as ControlViewModelBase;
                viewModel.SourceElementCore.UpdateViewModelProperties(viewModel, element);
                viewModel.CarouselIndex ++;
            }
        }
        #endregion
    }
}
