using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Controls.Internal
{
    internal class ResizeContainer : ContentControl
    {
        static ResizeContainer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResizeContainer), new FrameworkPropertyMetadata(typeof(ResizeContainer)));
        }

        #region Property
        public bool IsSquare
        {
            get { return (bool)GetValue(IsSquareProperty); }
            set { SetValue(IsSquareProperty, value); }
        }

        public static readonly DependencyProperty IsSquareProperty =
            DependencyProperty.Register("IsSquare", typeof(bool), typeof(ResizeContainer));

        public bool LimitInParent
        {
            get { return (bool)GetValue(LimitInParentProperty); }
            set { SetValue(LimitInParentProperty, value); }
        }

        public static readonly DependencyProperty LimitInParentProperty =
            DependencyProperty.Register("LimitInParent", typeof(bool), typeof(ResizeContainer));

        public bool CanResize
        {
            get { return (bool)GetValue(CanResizeProperty); }
            set { SetValue(CanResizeProperty, value); }
        }

        public static readonly DependencyProperty CanResizeProperty =
            DependencyProperty.Register("CanResize", typeof(bool), typeof(ResizeContainer), new PropertyMetadata(true));

        #endregion
    }
}
