using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class SwitchCheckBox : CheckBox
    {
        #region Fields
        #endregion

        #region Ctor
        static SwitchCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchCheckBox), new FrameworkPropertyMetadata(typeof(SwitchCheckBox)));
        }
        #endregion

        #region Properties

        #region ToggleBrush
        public Brush ToggleBrush
        {
            get { return (Brush)GetValue(ToggleBrushProperty); }
            set { SetValue(ToggleBrushProperty, value); }
        }

        public static readonly DependencyProperty ToggleBrushProperty =
            DependencyProperty.RegisterAttached("ToggleBrush", typeof(Brush), typeof(SwitchCheckBox));
        #endregion

        #region CheckedToggleBrush
        public Brush CheckedToggleBrush
        {
            get { return (Brush)GetValue(CheckedToggleBrushProperty); }
            set { SetValue(CheckedToggleBrushProperty, value); }
        }

        public static readonly DependencyProperty CheckedToggleBrushProperty =
            DependencyProperty.RegisterAttached("CheckedToggleBrush", typeof(Brush), typeof(SwitchCheckBox));
        #endregion

        #region CheckedForeground
        public Brush CheckedForeground
        {
            get { return (Brush)GetValue(CheckedForegroundProperty); }
            set { SetValue(CheckedForegroundProperty, value); }
        }

        public static readonly DependencyProperty CheckedForegroundProperty =
            DependencyProperty.RegisterAttached("CheckedForeground", typeof(Brush), typeof(SwitchCheckBox));
        #endregion

        #region CheckedBackground
        public Brush CheckedBackground
        {
            get { return (Brush)GetValue(CheckedBackgroundProperty); }
            set { SetValue(CheckedBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CheckedBackgroundProperty =
            DependencyProperty.RegisterAttached("CheckedBackground", typeof(Brush), typeof(SwitchCheckBox));
        #endregion

        #region CheckedBorderBrush
        public Brush CheckedBorderBrush
        {
            get { return (Brush)GetValue(CheckedBorderBrushProperty); }
            set { SetValue(CheckedBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty CheckedBorderBrushProperty =
            DependencyProperty.RegisterAttached("CheckedBorderBrush", typeof(Brush), typeof(SwitchCheckBox));
        #endregion

        #region BoxHeight
        public double BoxHeight
        {
            get { return (double)GetValue(BoxHeightProperty); }
            set { SetValue(BoxHeightProperty, value); }
        }

        public static readonly DependencyProperty BoxHeightProperty =
            DependencyProperty.RegisterAttached("BoxHeight", typeof(double), typeof(SwitchCheckBox));
        #endregion

        #region BoxWidth
        public double BoxWidth
        {
            get { return (double)GetValue(BoxWidthProperty); }
            set { SetValue(BoxWidthProperty, value); }
        }

        public static readonly DependencyProperty BoxWidthProperty =
            DependencyProperty.RegisterAttached("BoxWidth", typeof(double), typeof(SwitchCheckBox));
        #endregion

        #region ToggleSize
        public double ToggleSize
        {
            get { return (double)GetValue(ToggleSizeProperty); }
            set { SetValue(ToggleSizeProperty, value); }
        }

        public static readonly DependencyProperty ToggleSizeProperty =
            DependencyProperty.RegisterAttached("ToggleSize", typeof(double), typeof(SwitchCheckBox));
        #endregion

        #region CornerRadius
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(SwitchCheckBox));
        #endregion

        #region CheckedContent
        public object CheckedContent
        {
            get { return (object)GetValue(CheckedContentProperty); }
            set { SetValue(CheckedContentProperty, value); }
        }

        public static readonly DependencyProperty CheckedContentProperty =
            DependencyProperty.RegisterAttached("CheckedContent", typeof(object), typeof(SwitchCheckBox));
        #endregion

        #region ToggleShadowColor
        public Color? ToggleShadowColor
        {
            get { return (Color?)GetValue(ToggleShadowColorProperty); }
            set { SetValue(ToggleShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ToggleShadowColorProperty =
            DependencyProperty.Register("ToggleShadowColor", typeof(Color?), typeof(SwitchCheckBox));
        #endregion

        #endregion

        #region Internal Properties

        #region IsThreeState
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new bool IsThreeState
        {
            get { return (bool)GetValue(IsThreeStateProperty); }
            set { SetValue(IsThreeStateProperty, value); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new static readonly DependencyProperty IsThreeStateProperty =
            DependencyProperty.Register("IsThreeState", typeof(bool), typeof(SwitchCheckBox));
        #endregion

        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        #endregion

        #region Functions
        #endregion
    }
}
