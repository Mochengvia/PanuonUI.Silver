using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

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

        public ColorSelector()
        {
            InitializeComponent();
            Loaded += ColorSelector_Loaded;
        }

        private void ColorSelector_Loaded(object sender, RoutedEventArgs e)
        {
            _actualHeight = GetAvailbleAreaHeight();
        }



        #region RoutedEvent
        public static readonly RoutedEvent SelectedBrushChangedEvent = EventManager.RegisterRoutedEvent("SelectedBrushChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ColorSelector));
        public event RoutedEventHandler SelectedBrushChanged
        {
            add { AddHandler(SelectedBrushChangedEvent, value); }
            remove { RemoveHandler(SelectedBrushChangedEvent, value); }
        }
        void RaiseSelectedBrushChanged()
        {
            var arg = new RoutedEventArgs(SelectedBrushChangedEvent);
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
            DependencyProperty.Register("Hex", typeof(string), typeof(ColorSelector), new PropertyMetadata("#FFFFFFFF"));

      
        public string A
        {
            get { return (string)GetValue(AProperty); }
            set { SetValue(AProperty, value); }
        }

        public static readonly DependencyProperty AProperty =
            DependencyProperty.Register("A", typeof(string), typeof(ColorSelector), new PropertyMetadata("255"));

        
        public string R
        {
            get { return (string)GetValue(RProperty); }
            set { SetValue(RProperty, value); }
        }

        public static readonly DependencyProperty RProperty =
            DependencyProperty.Register("R", typeof(string), typeof(ColorSelector), new PropertyMetadata("255"));

      
        public string G
        {
            get { return (string)GetValue(GProperty); }
            set { SetValue(GProperty, value); }
        }

        public static readonly DependencyProperty GProperty =
            DependencyProperty.Register("G", typeof(string), typeof(ColorSelector), new PropertyMetadata("255"));

      
        public string B
        {
            get { return (string)GetValue(BProperty); }
            set { SetValue(BProperty, value); }
        }

        public static readonly DependencyProperty BProperty =
            DependencyProperty.Register("B", typeof(string), typeof(ColorSelector), new PropertyMetadata("255"));


        #endregion

        #region Event Handler
        private static void OnSelectedBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as ColorSelector;
            selector.RaiseSelectedBrushChanged();
            var brush = e.NewValue as SolidColorBrush;

            var color = brush.ToColor();

            selector._updateSelectedBrush = false;
            selector.Hex = color.ToHexString(selector.IsOpacityEnabled);
            selector.A = color.A.ToString();
            selector.R = color.R.ToString();
            selector.G = color.G.ToString();
            selector.B = color.B.ToString();

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
                selector.SliderOpacity.IsEnabled = true;
                selector.SliderOpacity.Opacity = 1;
            }
            else
            {
                selector.ColumnA.Width = new GridLength(0, GridUnitType.Pixel);
                selector.SliderOpacity.IsEnabled = false;
                selector.SliderOpacity.Opacity = 0.2;
            }
        }

        private static void OnIsMeasuredValueVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as ColorSelector;
            selector._actualHeight = selector.GetAvailbleAreaHeight();
            if(selector.IsMeasuredValueVisible)
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
            if (!IsLoaded)
                return;

            UpdateSelectedBrush();
        }

        private void SliderColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var color = GetColorByOffset(Linear.GradientStops, (double)(6 - SliderColor.Value) / 6);
            BackgroundBrush = color.ToBrush();

            UpdateSelectedBrush();
        }
        #endregion

        #region Function
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
                        SliderColor.Value = (prevBytes[middleIndex] - middleNewValue) / 255.0 + colorIndex - 1 ;
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

        private void TbInfo_LostFocus(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (textbox.Name)
            {
                case "TbHex":
                    if (Regex.IsMatch(TbHex.Text, "^#[0-9A-Za-z]{6}$|^#[0-9A-Za-z]{8}$"))
                    {
                        var color = TbHex.Text.ToColor();
                        if (!IsOpacityEnabled)
                            color.A = 255;
                        SelectedBrush = color.ToBrush();
                    }
                    break;
                case "TbA":
                    byte a = 0;
                    if (byte.TryParse(TbA.Text, out a))
                    {
                        var color = SelectedBrush.ToColor();
                        color.A = a;
                        SelectedBrush = color.ToBrush();
                    }
                    break;
                case "TbR":
                    byte r = 0;
                    if (byte.TryParse(TbR.Text, out r))
                    {
                        var color = SelectedBrush.ToColor();
                        color.R = r;
                        SelectedBrush = color.ToBrush();
                    }
                    break;
                case "TbG":
                    byte g = 0;
                    if (byte.TryParse(TbG.Text, out g))
                    {
                        var color = SelectedBrush.ToColor();
                        color.G = g;
                        SelectedBrush = color.ToBrush();
                    }
                    break;
                case "TbB":
                    byte b = 0;
                    if (byte.TryParse(TbB.Text, out b))
                    {
                        var color = SelectedBrush.ToColor();
                        color.B = b;
                        SelectedBrush = color.ToBrush();
                    }
                    break;
            }
            
        }

        private void TbInfo_Keyup(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                var textbox = sender as TextBox;
                switch (textbox.Name)
                {
                    case "TbHex":
                        if (Regex.IsMatch(TbHex.Text, "^#[0-9A-Za-z]{6}$|^#[0-9A-Za-z]{8}$"))
                        {
                            try
                            {
                                var color = TbHex.Text.ToColor();
                                if (!IsOpacityEnabled)
                                    color.A = 255;
                                SelectedBrush = color.ToBrush();
                            }
                            catch { }
                           
                        }
                        break;
                    case "TbA":
                        byte a = 0;
                        if (byte.TryParse(TbA.Text, out a))
                        {
                            var color = SelectedBrush.ToColor();
                            color.A = a;
                            SelectedBrush = color.ToBrush();
                        }
                        break;
                    case "TbR":
                        byte r = 0;
                        if (byte.TryParse(TbR.Text, out r))
                        {
                            var color = SelectedBrush.ToColor();
                            color.R = r;
                            SelectedBrush = color.ToBrush();
                        }
                        break;
                    case "TbG":
                        byte g = 0;
                        if (byte.TryParse(TbG.Text, out g))
                        {
                            var color = SelectedBrush.ToColor();
                            color.G = g;
                            SelectedBrush = color.ToBrush();
                        }
                        break;
                    case "TbB":
                        byte b = 0;
                        if (byte.TryParse(TbB.Text, out b))
                        {
                            var color = SelectedBrush.ToColor();
                            color.B = b;
                            SelectedBrush = color.ToBrush();
                        }
                        break;
                }

            }
        }

        private void BdrDefaultColor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            SelectedBrush = border.Background.ToColor().ToBrush();
        }

        private double GetAvailbleAreaHeight()
        {
            return Height - 50 - (IsMeasuredValueVisible ? GrdMeasuredValue.Height : 0) - (IsDefaultColorPanelVisible ? GrdDefaultColor.Height : 0);
        }
    }
}
