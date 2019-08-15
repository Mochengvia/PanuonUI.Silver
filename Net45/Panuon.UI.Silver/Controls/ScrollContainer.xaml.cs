using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// ScrollContainer.xaml 的交互逻辑
    /// </summary>
    [ContentProperty(nameof(Children))]
    public partial class ScrollContainer : UserControl
    {
        public ScrollContainer()
        {
            InitializeComponent();
            Children = WrapMain.Children;
        }

        #region Property
        public double VerticalOffset
        {
            get { return SvMain.VerticalOffset; }
            set { SvMain.ScrollToVerticalOffset(value); }
        }

        private static void OnVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var container = d as ScrollContainer;
            container.SvMain.ScrollToVerticalOffset((double)e.NewValue);
        }

        public ScrollBarVisibility VerticalScrollBarVisibility
        {
            get { return (ScrollBarVisibility)GetValue(VerticalScrollBarVisibilityProperty); }
            set { SetValue(VerticalScrollBarVisibilityProperty, value); }
        }

        public static readonly DependencyProperty VerticalScrollBarVisibilityProperty =
            DependencyProperty.Register("VerticalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(ScrollContainer), new PropertyMetadata(ScrollBarVisibility.Auto));

        public UIElementCollection Children
        {
            get { return (UIElementCollection)GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }

        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register("Children", typeof(UIElementCollection), typeof(ScrollContainer));
        #endregion

        #region EventHandler
        private void SvMain_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            
        }
        #endregion

        #region Function
        
            
        #endregion
    }
}
