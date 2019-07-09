using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class Loading : Control
    {
        #region Constructor
        static Loading()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Loading), new FrameworkPropertyMetadata(typeof(Loading)));
        }
        #endregion

        #region Property
        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke", typeof(Brush), typeof(Loading));

        public Brush StrokeCover
        {
            get { return (Brush)GetValue(StrokeCoverProperty); }
            set { SetValue(StrokeCoverProperty, value); }
        }

        public static readonly DependencyProperty StrokeCoverProperty =
            DependencyProperty.Register("StrokeCover", typeof(Brush), typeof(Loading));

        /// <summary>
        /// 获取或设置加载控件的状态。默认为False。
        /// </summary>
        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }

        public static readonly DependencyProperty IsRunningProperty =
            DependencyProperty.Register("IsRunning", typeof(bool), typeof(Loading));

        /// <summary>
        /// 获取或设置加载控件的基础样式。默认为Standard。
        /// </summary>
        public LoadingStyle LoadingStyle
        {
            get { return (LoadingStyle)GetValue(LoadingStyleProperty); }
            set { SetValue(LoadingStyleProperty, value); }
        }

        public static readonly DependencyProperty LoadingStyleProperty =
            DependencyProperty.Register("LoadingStyle", typeof(LoadingStyle), typeof(Loading), new PropertyMetadata(LoadingStyle.Standard));
        #endregion
    }
}
