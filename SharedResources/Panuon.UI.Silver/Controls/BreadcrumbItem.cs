using Panuon.UI.Silver.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Panuon.UI.Silver
{
    public class BreadcrumbItem : ContentControl
    {
        #region Ctor
        static BreadcrumbItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BreadcrumbItem), new FrameworkPropertyMetadata(typeof(BreadcrumbItem)));
        }
        #endregion

        #region Properties

        #region ButtonStyle
        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }
            set { SetValue(ButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(BreadcrumbItem));
        #endregion

        #region SeparatorStyle
        public Style SeparatorStyle
        {
            get { return (Style)GetValue(SeparatorStyleProperty); }
            set { SetValue(SeparatorStyleProperty, value); }
        }

        public static readonly DependencyProperty SeparatorStyleProperty =
            DependencyProperty.Register("SeparatorStyle", typeof(Style), typeof(BreadcrumbItem));
        #endregion

        #endregion


        #region Events

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        public static readonly RoutedEvent ClickEvent =
            EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BreadcrumbItem));

        #endregion

        #region Commands
        public static readonly DependencyProperty ItemClickCommandProperty =
            DependencyProperty.Register("ItemClickCommand", typeof(ICommand), typeof(BreadcrumbItem), new PropertyMetadata(new RelayCommand(OnItemClickCommandExecute)));
        #endregion


        #region EventHandlers
        private static void OnItemClickCommandExecute(object obj)
        {
            var item = obj as BreadcrumbItem;
            item.RaiseEvent(new RoutedEventArgs(ClickEvent, item?.DataContext));
        }
        #endregion
    }
}
