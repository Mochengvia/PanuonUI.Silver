using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class StateIcon : Control
    {
        static StateIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StateIcon), new FrameworkPropertyMetadata(typeof(StateIcon)));
        }

        #region Property
        /// <summary>
        /// Gets or sets icon.
        /// </summary>
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(StateIcon));

        /// <summary>
        /// Gets or sets icon state.
        /// </summary>
        public IconState IconState
        {
            get { return (IconState)GetValue(IconStateProperty); }
            set { SetValue(IconStateProperty, value); }
        }

        public static readonly DependencyProperty IconStateProperty =
            DependencyProperty.Register("IconState", typeof(IconState), typeof(StateIcon));

        /// <summary>
        /// Gets or sets failed brush.
        /// </summary>
        public Brush FailedBrush
        {
            get { return (Brush)GetValue(FailedBrushProperty); }
            set { SetValue(FailedBrushProperty, value); }
        }

        public static readonly DependencyProperty FailedBrushProperty =
            DependencyProperty.Register("FailedBrush", typeof(Brush), typeof(StateIcon));

        /// <summary>
        /// Gets or sets warning brush.
        /// </summary>
        public Brush WarningBrush
        {
            get { return (Brush)GetValue(WarningBrushProperty); }
            set { SetValue(WarningBrushProperty, value); }
        }

        public static readonly DependencyProperty WarningBrushProperty =
            DependencyProperty.Register("WarningBrush", typeof(Brush), typeof(StateIcon));

        /// <summary>
        /// Gets or sets success brush.
        /// </summary>
        public Brush SuccessBrush
        {
            get { return (Brush)GetValue(SuccessBrushProperty); }
            set { SetValue(SuccessBrushProperty, value); }
        }

        public static readonly DependencyProperty SuccessBrushProperty =
            DependencyProperty.Register("SuccessBrush", typeof(Brush), typeof(StateIcon));

        /// <summary>
        /// Gets or sets error brush.
        /// </summary>
        public Brush ErrorBrush
        {
            get { return (Brush)GetValue(ErrorBrushProperty); }
            set { SetValue(ErrorBrushProperty, value); }
        }

        public static readonly DependencyProperty ErrorBrushProperty =
            DependencyProperty.Register("ErrorBrush", typeof(Brush), typeof(StateIcon));

        /// <summary>
        /// Gets or sets tips brush.
        /// </summary>
        public Brush TipsBrush
        {
            get { return (Brush)GetValue(TipsBrushProperty); }
            set { SetValue(TipsBrushProperty, value); }
        }

        public static readonly DependencyProperty TipsBrushProperty =
            DependencyProperty.Register("TipsBrush", typeof(Brush), typeof(StateIcon));

        #endregion
    }
}
