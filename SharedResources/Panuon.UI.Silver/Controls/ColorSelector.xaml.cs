using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// ColorSelector.xaml 的交互逻辑
    /// </summary>
    public partial class ColorSelector : UserControl
    {
        #region Identity
        private bool _updateSelector;

        private bool _updateSelectedBrush = true;

        private double _actualHeight;

        private IList<Color> _colors = new List<Color>()
        {
            Color.FromRgb(255, 0, 0),
            Color.FromRgb(255, 0, 255),
            Color.FromRgb(0, 0, 255),
            Color.FromRgb(0, 255, 255),
            Color.FromRgb(0, 255, 0),
            Color.FromRgb(255, 255, 0)
        };

        #endregion

        #region Constructor
        public ColorSelector()
        {
            InitializeComponent();
            Loaded += ColorSelector_Loaded;
        }

        private void ColorSelector_Loaded(object sender, RoutedEventArgs e)
        {
            _actualHeight = GetAvailbleAreaHeight();
        }
        #endregion

        #region RoutedEvent
        public static readonly RoutedEvent SelectedBrushChangedEvent = EventManager.RegisterRoutedEvent("SelectedBrushChanged", RoutingStrategy.Bubble, typeof(SelectedBrushChangedEventHandler), typeof(ColorSelector));
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
        public SolidColorBrush SelectedBrush
        {
            get { return (SolidColorBrush)GetValue(SelectedBrushProperty); }
            set { SetValue(SelectedBrushProperty, value); }
        }

        public static readonly DependencyProperty SelectedBrushProperty =
            DependencyProperty.Register("SelectedBrush", typeof(SolidColorBrush), typeof(ColorSelector), new PropertyMetadata(Colors.White.ToBrush(), OnSelectedBrushChanged));

        public bool IsOpacityEnabled
        {
            get { return (bool)GetValue(IsOpacityEnabledProperty); }
            set { SetValue(IsOpacityEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsOpacityEnabledProperty =
            DependencyProperty.Register("IsOpacityEnabled", typeof(bool), typeof(ColorSelector), new PropertyMetadata(true, OnIsOpacityVisible));

        public bool IsMeasuredValueVisible
        {
            get { return (bool)GetValue(IsMeasuredValueVisibleProperty); }
            set { SetValue(IsMeasuredValueVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsMeasuredValueVisibleProperty =
            DependencyProperty.Register("IsMeasuredValueVisible", typeof(bool), typeof(ColorSelector), new PropertyMetadata(true, OnIsMeasuredValueVisibleChanged));


        public bool IsDefaultColorPanelVisible
        {
            get { return (bool)GetValue(IsDefaultColorPanelVisibleProperty); }
            set { SetValue(IsDefaultColorPanelVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsDefaultColorPanelVisibleProperty =
            DependencyProperty.Register("IsDefaultColorPanelVisible", typeof(bool), typeof(ColorSelector), new PropertyMetadata(true, OnIsDefaultColorPanelVisibleChanged));
        #endregion

        #region Internal Property
        internal Brush BackgroundBrush
        {
            get { return (Brush)GetValue(BackgroundBrushProperty); }
            set { SetValue(BackgroundBrushProperty, value); }
        }

        internal static readonly DependencyProperty BackgroundBrushProperty =
            DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(ColorSelector), new PropertyMetadata(new SolidColorBrush(Colors.Red)));

        public string Hex
        {
            get { return (string)GetValue(HexProperty); }
            set { SetValue(HexProperty, value); }
        }

        public static readonly DependencyProperty HexProperty =
            DependencyProperty.Register("Hex", typeof(string), typeof(ColorSelector), new PropertyMetadata("#FFFFFFFF", OnHexChanged));

        public byte A
        {
            get { return (byte)GetValue(AProperty); }
            set { SetValue(AProperty, value); }
        }

        public static readonly DependencyProperty AProperty =
            DependencyProperty.Register("A", typeof(byte), typeof(ColorSelector), new PropertyMetadata((byte)255, OnAChanged));


        public byte R
        {
            get { return (byte)GetValue(RProperty); }
            set { SetValue(RProperty, value); }
        }

        public static readonly DependencyProperty RProperty =
            DependencyProperty.Register("R", typeof(byte), typeof(ColorSelector), new PropertyMetadata((byte)255, OnRChanged));



        public byte G
        {
            get { return (byte)GetValue(GProperty); }
            set { SetValue(GProperty, value); }
        }

        public static readonly DependencyProperty GProperty =
            DependencyProperty.Register("G", typeof(byte), typeof(ColorSelector), new PropertyMetadata((byte)255, OnGChanged));

       

        public byte B
        {
            get { return (byte)GetValue(BProperty); }
            set { SetValue(BProperty, value); }
        }

        public static readonly DependencyProperty BProperty =
            DependencyProperty.Register("B", typeof(byte), typeof(ColorSelector), new PropertyMetadata((byte)255, OnBChanged));



        #endregion

        #region Event Handler
        private void BdrDefaultColor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            SelectedBrush = border.Background.ToColor().ToBrush();
        }

        private static void OnHexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as ColorSelector;
            if (Regex.IsMatch(selector.Hex, "^#[0-9A-Za-z]{6}$|^#[0-9A-Za-z]{8}$"))
            {
                try
                {
                    var oldColor = selector.SelectedBrush.Color;
                    var color = selector.Hex.ToColor();
                    if (!selector.IsOpacityEnabled)
                        color.A = 255;

                    if (color.IsEqual(selector.SelectedBrush.Color))
                        return;

                    selector.SelectedBrush = color.ToBrush();
                }
                catch { }
            }
        }

        private static void OnAChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as ColorSelector;
            var color = selector.SelectedBrush.ToColor();
            color.A = (byte)selector.A;
            selector.SelectedBrush = color.ToBrush();
        }

        private static void OnRChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as ColorSelector;
            var color = selector.SelectedBrush.ToColor();
            color.R = (byte)selector.R;
            selector.SelectedBrush = color.ToBrush();
        }

        private static void OnGChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as ColorSelector;
            var color = selector.SelectedBrush.ToColor();
            color.G = (byte)selector.G;
            selector.SelectedBrush = color.ToBrush();
        }

        private static void OnBChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as ColorSelector;
            var color = selector.SelectedBrush.ToColor();
            color.B = (byte)selector.B;
            selector.SelectedBrush = color.ToBrush();
        }

        private static void OnSelectedBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as ColorSelector;
            selector.RaiseSelectedBrushChanged(selector.SelectedBrush);
            var brush = e.NewValue as SolidColorBrush;

            if (brush == null)
                return;

            var color = brush.ToColor();

            selector._updateSelectedBrush = false;
            selector.Hex = color.ToHexString(selector.IsOpacityEnabled);
            selector.A = color.A;
            selector.R = color.R;
            selector.G = color.G;
            selector.B = color.B;

            selector._updateSelectedBrush = true;


            if (selector._updateSelector)
            {
                selector._updateSelector = false;

                return;
            }

            selector.UpdateSelector(brush.Color);
        }

        private static void OnIsOpacityVisible(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as ColorSelector;
            selector.Hex = selector.SelectedBrush.Color.ToHexString(selector.IsOpacityEnabled);
            if (selector.IsOpacityEnabled)
            {
                selector.ColumnA.Width = new GridLength(1, GridUnitType.Star);
                selector.RowOpacity.Height = new GridLength(1, GridUnitType.Star);
                selector.SliderOpacity.Value = 255;
            }
            else
            {
                selector.ColumnA.Width = new GridLength(0, GridUnitType.Pixel);
                selector.RowOpacity.Height = new GridLength(0);
                selector.SliderOpacity.Value = 255;
            }
        }

        private static void OnIsMeasuredValueVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as ColorSelector;
            selector._actualHeight = selector.GetAvailbleAreaHeight();
            if (selector.IsMeasuredValueVisible)
                selector.GrdMeasuredValue.Visibility = Visibility.Visible;
            else
                selector.GrdMeasuredValue.Visibility = Visibility.Collapsed;
        }

        private static void OnIsDefaultColorPanelVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as ColorSelector;
            selector._actualHeight = selector.GetAvailbleAreaHeight();

            if (selector.IsDefaultColorPanelVisible)
                selector.GrdDefaultColor.Visibility = Visibility.Visible;
            else
                selector.GrdDefaultColor.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region Event
        private void CvaOuter_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var postion = Mouse.GetPosition(CvaMain);
            var targetLeft = postion.X - 10;
            var targetTop = postion.Y - 10;

            if (targetLeft < 0)
                targetLeft = 0;
            else if (targetLeft > Width)
                targetLeft = Width;

            if (targetTop < 0)
                targetTop = 0;
            else if (targetTop > _actualHeight)
                targetTop = _actualHeight;

            Canvas.SetLeft(DragToggle, targetLeft);
            Canvas.SetTop(DragToggle, targetTop);

            UpdateSelectedBrush();

            var window = Window.GetWindow(this);
            window.PreviewMouseMove -= Window_PreviewMouseMove;
            window.PreviewMouseMove += Window_PreviewMouseMove;
            window.MouseUp -= Window_PreviewMouseUp;
            window.PreviewMouseUp -= Window_PreviewMouseUp;
            window.PreviewMouseUp += Window_PreviewMouseUp;
        }

        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var window = sender as Window;
            window.PreviewMouseMove -= Window_PreviewMouseMove;
        }

        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var postion = Mouse.GetPosition(CvaMain);
                var targetLeft = postion.X - 10;
                var targetTop = postion.Y - 10;

                if (targetLeft < 0)
                    targetLeft = 0;
                else if (targetLeft > Width)
                    targetLeft = Width;

                if (targetTop < 0)
                    targetTop = 0;
                else if (targetTop > _actualHeight)
                    targetTop = _actualHeight;

                Canvas.SetLeft(DragToggle, targetLeft);
                Canvas.SetTop(DragToggle, targetTop);
                UpdateSelectedBrush();
            }
        }

        private void CvaOuter_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CvaMain.Height = GetAvailbleAreaHeight() + 20;
            CvaMain.Width = Width + 20;
        }

        private void SliderOpacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_actualHeight == 0)
                return;

            UpdateSelectedBrush();
        }

        private void SliderColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_actualHeight == 0)
                return;

            var color = GetColorByOffset(Linear.GradientStops, (double)(6 - SliderColor.Value) / 6);
            BackgroundBrush = color.ToBrush();

            UpdateSelectedBrush();
        }
        #endregion

        #region Function
        private double GetAvailbleAreaHeight()
        {
            return Height - 50 - (IsMeasuredValueVisible ? GrdMeasuredValue.Height : 0) - (IsDefaultColorPanelVisible ? GrdDefaultColor.Height : 0);
        }

        private void UpdateSelectedBrush()
        {
            if (!_updateSelectedBrush)
            {
                return;
            }

            var backgroundColor = (BackgroundBrush as SolidColorBrush).Color;

            var position = new Point(Canvas.GetLeft(DragToggle), Canvas.GetTop(DragToggle));
            var scaleX = position.X / Width;
            var scaleY = 1 - position.Y / (_actualHeight);

            scaleX = double.IsNaN(scaleX) ? 0 : scaleX;
            scaleY = double.IsNaN(scaleY) ? 0 : scaleY;


            var colorYLeft = Color.FromRgb((byte)(255 * scaleY), (byte)(255 * scaleY), (byte)(255 * scaleY));
            var colorYRight = Color.FromRgb((byte)(backgroundColor.R * scaleY), (byte)(backgroundColor.G * scaleY), (byte)(backgroundColor.B * scaleY));

            var subR = colorYLeft.R - colorYRight.R;
            var subG = colorYLeft.G - colorYRight.G;
            var subB = colorYLeft.B - colorYRight.B;

            var color = Color.FromArgb((byte)SliderOpacity.Value, (byte)(colorYLeft.R - subR * scaleX),
                (byte)(colorYLeft.G - subG * scaleX), (byte)(colorYLeft.B - subB * scaleX));


            _updateSelector = true;
            SelectedBrush = color.ToBrush();
        }

        private void UpdateSelector(Color color)
        {
            color = color == null ? Colors.White : color;

            SliderOpacity.Value = color.A;

            var list = new List<byte>() { color.R, color.G, color.B };
            var minValue = list.Min();
            var maxValue = list.Max();
            var minIndex = list.IndexOf(minValue);
            var maxIndex = list.IndexOf(maxValue);

            _updateSelectedBrush = false;
            if (minIndex == 0 && maxIndex == 0)
            {
                SliderColor.Value = 0;
            }
            else
            {
                var middleIndex = 3 - minIndex - maxIndex;
                var middleValue = list[middleIndex];
                var middleNewValue = (byte)(255 * (minValue - middleValue) / (double)(minValue - maxValue));

                list[maxIndex] = 255;
                list[minIndex] = 0;
                list[middleIndex] = 0;

                var colorIndex = _colors.IndexOf(Color.FromRgb(list[0], list[1], list[2]));


                if (colorIndex < 5 && colorIndex > 0)
                {
                    var nextColor = _colors[colorIndex + 1];
                    var prevColor = _colors[colorIndex - 1];

                    var nextBytes = new List<byte>() { nextColor.R, nextColor.G, nextColor.B };
                    var prevBytes = new List<byte>() { prevColor.R, prevColor.G, prevColor.B };

                    if (nextBytes[minIndex] > 0)
                    {
                        SliderColor.Value = (prevBytes[middleIndex] - middleNewValue) / 255.0 + colorIndex - 1;
                    }
                    else
                    {
                        SliderColor.Value = middleNewValue / 255.0 + colorIndex;
                    }
                }
                else if (colorIndex == 0)
                {
                    if (minIndex == 2)
                    {
                        SliderColor.Value = colorIndex + (255 - middleNewValue) / 255.0 + 5;
                    }
                    else
                    {
                        SliderColor.Value = middleNewValue / 255.0;
                    }
                }
                else
                {
                    SliderColor.Value = (255 - middleNewValue) / 255.0;
                }
            }

            var pointX = maxValue == 0 ? 0 : (1 - minValue / (double)maxValue) * (Width);
            var pointY = (1 - maxValue / 255.0) * GetAvailbleAreaHeight();
            Canvas.SetLeft(DragToggle, pointX);
            Canvas.SetTop(DragToggle, pointY);
            _updateSelectedBrush = true;
        }

        private static Color GetColorByOffset(GradientStopCollection collection, double offset)
        {
            var stops = collection.OrderBy(x => x.Offset).ToArray();
            if (offset <= 0) return stops[0].Color;
            if (offset >= 1) return stops[stops.Length - 1].Color;
            var left = stops.Where(s => s.Offset <= offset).Last();
            var right = stops.Where(s => s.Offset > offset).First();
            offset = Math.Round((offset - left.Offset) / (right.Offset - left.Offset), 2);
            var a = (byte)((right.Color.A - left.Color.A) * offset + left.Color.A);
            var r = (byte)((right.Color.R - left.Color.R) * offset + left.Color.R);
            var g = (byte)((right.Color.G - left.Color.G) * offset + left.Color.G);
            var b = (byte)((right.Color.B - left.Color.B) * offset + left.Color.B);
            return Color.FromArgb(a, r, g, b);
        }
        #endregion
       
    }
}
