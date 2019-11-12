using Panuon.UI.Silver.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// ColorPicker.xaml 的交互逻辑
    /// </summary>
    public partial class ColorPicker : ContentControl
    {
        #region Constructor
        public ColorPicker()
        {
            InitializeComponent();
            Foreground = "#3E3E3E".ToColor().ToBrush();
            Background = "#FFFFFF".ToColor().ToBrush();
            Padding = new Thickness(5, 0, 0, 0);
            ShadowColor = "#888888".ToColor();
            CornerRadius = new CornerRadius(2);
            VerticalContentAlignment = VerticalAlignment.Center;

            Loaded += delegate
            {
                UpdateText();
            };
        }
        #endregion

        #region RoutedEvent
        public static readonly RoutedEvent SelectedBrushChangedEvent = EventManager.RegisterRoutedEvent("SelectedBrushChanged", RoutingStrategy.Bubble, typeof(SelectedBrushChangedEventHandler), typeof(ColorPicker));
        public event SelectedBrushChangedEventHandler SelectedBrushChanged
        {
            add { AddHandler(SelectedBrushChangedEvent, value); }
            remove { RemoveHandler(SelectedBrushChangedEvent, value); }
        }
        void RaiseSelectedBrushChanged(Brush brush)
        {
            var arg = new SelectedBrushChangedEventArgs(brush, SelectedBrushChangedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets text.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ColorPicker));

        /// <summary>
        /// Gets or sets shadow color.
        /// </summary>
        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(ColorPicker));

        /// <summary>
        /// Gets or sets selected brush.
        /// </summary>
        public SolidColorBrush SelectedBrush
        {
            get { return (SolidColorBrush)GetValue(SelectedBrushProperty); }
            set { SetValue(SelectedBrushProperty, value); }
        }

        public static readonly DependencyProperty SelectedBrushProperty =
            DependencyProperty.Register("SelectedBrush", typeof(SolidColorBrush), typeof(ColorPicker), new PropertyMetadata(Colors.White.ToBrush(), OnSelectedBrushChanged));

        private static void OnSelectedBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as ColorPicker;
            picker.UpdateText();
            picker.RaiseSelectedBrushChanged(picker.SelectedBrush);
        }

        /// <summary>
        /// Gets or sets is opacity enabled.
        /// </summary>
        public bool IsOpacityEnabled
        {
            get { return (bool)GetValue(IsOpacityEnabledProperty); }
            set { SetValue(IsOpacityEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsOpacityEnabledProperty =
            DependencyProperty.Register("IsOpacityEnabled", typeof(bool), typeof(ColorPicker), new PropertyMetadata(true, OnIsOpacityEnabled));

        private static void OnIsOpacityEnabled(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as ColorPicker;
            picker.UpdateText();
        }

        /// <summary>
        /// Gets or sets corner radius.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ColorPicker));

        /// <summary>
        /// Gets or sets is text visible.
        /// </summary>
        public bool IsTextVisible
        {
            get { return (bool)GetValue(IsTextVisibleProperty); }
            set { SetValue(IsTextVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsTextVisibleProperty =
            DependencyProperty.Register("IsTextVisible", typeof(bool), typeof(ColorPicker), new PropertyMetadata(true));

        /// <summary>
        /// Gets or sets header.
        /// </summary>
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(ColorPicker));

        /// <summary>
        /// Gets or sets header width.
        /// </summary>
        public string HeaderWidth
        {
            get { return (string)GetValue(HeaderWidthProperty); }
            set { SetValue(HeaderWidthProperty, value); }
        }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.Register("HeaderWidth", typeof(string), typeof(ColorPicker));

        /// <summary>
        /// Gets or sets is measured value visible.
        /// </summary>
        public bool IsMeasuredValueVisible
        {
            get { return (bool)GetValue(IsMeasuredValueVisibleProperty); }
            set { SetValue(IsMeasuredValueVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsMeasuredValueVisibleProperty =
            DependencyProperty.Register("IsMeasuredValueVisible", typeof(bool), typeof(ColorPicker), new PropertyMetadata(true, OnIsMeasuredValueVisibleChanged));

        private static void OnIsMeasuredValueVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as ColorPicker;
            picker.ColorSelector.Height = 340 - (picker.IsMeasuredValueVisible ? 0 : 50) - (picker.IsDefaultColorPanelVisible ? 0 : 70);
        }

        /// <summary>
        /// Gets or sets is default color panel visible.
        /// </summary>
        public bool IsDefaultColorPanelVisible
        {
            get { return (bool)GetValue(IsDefaultColorPanelVisibleProperty); }
            set { SetValue(IsDefaultColorPanelVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsDefaultColorPanelVisibleProperty =
            DependencyProperty.Register("IsDefaultColorPanelVisible", typeof(bool), typeof(ColorPicker), new PropertyMetadata(true, OnIsDefaultColorPanelVisibleChanged));

        private static void OnIsDefaultColorPanelVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as ColorPicker;
            picker.ColorSelector.Height = 340 - (picker.IsMeasuredValueVisible ? 0 : 50) - (picker.IsDefaultColorPanelVisible ? 0 : 70);
        }
        #endregion

        #region Function
        private void UpdateText()
        {
            var color = SelectedBrush.ToColor();
            if (IsOpacityEnabled)
                Text = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", color.A, color.R, color.G, color.B);
            else
                Text = string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }
        #endregion
    }
}
