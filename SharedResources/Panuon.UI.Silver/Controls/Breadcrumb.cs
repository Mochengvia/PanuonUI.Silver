using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Panuon.UI.Silver
{
    public class Breadcrumb : ItemsControl
    {
        #region Fields
        #endregion

        #region Ctor
        static Breadcrumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Breadcrumb), new FrameworkPropertyMetadata(typeof(Breadcrumb)));
        }

        public Breadcrumb()
        {
            AddHandler(BreadcrumbItem.ClickEvent, new RoutedEventHandler(OnBreadcrumbItemClick));
        }

        #endregion

        #region Event
        public event RoutedEventHandler ItemClick
        {
            add { AddHandler(ItemClickEvent, value); }
            remove { RemoveHandler(ItemClickEvent, value); }
        }

        public static readonly RoutedEvent ItemClickEvent =
            EventManager.RegisterRoutedEvent("ItemClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Breadcrumb));
        #endregion

        #region Overrides
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new BreadcrumbItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is BreadcrumbItem || item is Separator;
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var breadcrumbItem = element as BreadcrumbItem;
            if(breadcrumbItem == null || item is BreadcrumbItem)
            {
                if(breadcrumbItem != null)
                {
                    breadcrumbItem.DataContext = item;
                }
                return;
            }

            var contentBinding = new Binding()
            {
                Path = new PropertyPath(DisplayMemberPath),
                Source = item,
                Mode = BindingMode.OneWay,
            };
            breadcrumbItem.SetBinding(BreadcrumbItem.ContentProperty, contentBinding);
        }
        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        private void OnBreadcrumbItemClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ItemClickEvent, e.OriginalSource));
        }
        #endregion

        #region Functions
        #endregion
    }
}
