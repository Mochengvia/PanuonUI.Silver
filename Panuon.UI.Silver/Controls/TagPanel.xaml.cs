using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// TagPanel.xaml 的交互逻辑
    /// </summary>
    public partial class TagPanel : UserControl
    {
      
        public TagPanel()
        {
            InitializeComponent();
            Foreground = new SolidColorBrush(Colors.White);
        }

        #region RoutedEvent
        public static readonly RoutedEvent AddButtonClickedEvent = EventManager.RegisterRoutedEvent("AddButtonClicked", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<TagPanel>), typeof(TagPanel));
        public event RoutedPropertyChangedEventHandler<TagPanel> AddButtonClicked
        {
            add { AddHandler(AddButtonClickedEvent, value); }
            remove { RemoveHandler(AddButtonClickedEvent, value); }
        }

        void RaiseAddButtonClicked()
        {
            var arg = new RoutedPropertyChangedEventArgs<TagPanel>(this, this, AddButtonClickedEvent);
            RaiseEvent(arg);
        }

        public static readonly RoutedEvent RemoveButtonClickedEvent = EventManager.RegisterRoutedEvent("RemoveButtonClicked", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(TagPanel));
        public event RoutedPropertyChangedEventHandler<object> RemoveButtonClicked
        {
            add { AddHandler(RemoveButtonClickedEvent, value); }
            remove { RemoveHandler(RemoveButtonClickedEvent, value); }
        }

        void RaiseRemoveButtonClicked(object oldValue, object newValue)
        {
            var arg = new RoutedPropertyChangedEventArgs<object>(oldValue, newValue, RemoveButtonClickedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Property
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(TagPanel));


        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(TagPanel));


        public string RemovableMemberPath
        {
            get { return (string)GetValue(RemovableMemberPathProperty); }
            set { SetValue(RemovableMemberPathProperty, value); }
        }

        public static readonly DependencyProperty RemovableMemberPathProperty =
            DependencyProperty.Register("RemovableMemberPath", typeof(string), typeof(TagPanel));

        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(TagPanel), new PropertyMetadata(30.0));


        public Brush ItemBackground
        {
            get { return (Brush)GetValue(ItemBackgroundProperty); }
            set { SetValue(ItemBackgroundProperty, value); }
        }

        public static readonly DependencyProperty ItemBackgroundProperty =
            DependencyProperty.Register("ItemBackground", typeof(Brush), typeof(TagPanel), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3E3E3E"))));


        public string ItemBackgroundMemberPath
        {
            get { return (string)GetValue(ItemBackgroundMemberPathProperty); }
            set { SetValue(ItemBackgroundMemberPathProperty, value); }
        }

        public static readonly DependencyProperty ItemBackgroundMemberPathProperty =
            DependencyProperty.Register("ItemBackgroundMemberPath", typeof(string), typeof(TagPanel));
        #endregion

        #region Internal Property
        internal ICommand AddCommand
        {
            get { return (ICommand)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }

        internal static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(TagPanel), new PropertyMetadata());


        internal ICommand RemoveCommand
        {
            get { return (ICommand)GetValue(RemoveCommandProperty); }
            set { SetValue(RemoveCommandProperty, value); }
        }

        internal static readonly DependencyProperty RemoveCommandProperty =
            DependencyProperty.Register("RemoveCommand", typeof(ICommand), typeof(TagPanel), new PropertyMetadata());
        #endregion

        private void TxtRemove_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var textblock = sender as TextBlock;
            RaiseRemoveButtonClicked(textblock.Tag, textblock.Tag);
        }
    }
}
