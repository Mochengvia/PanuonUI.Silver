using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// ColorPicker.xaml 的交互逻辑
    /// </summary>
    public partial class ColorPicker : ContentControl
    {
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

        #region RoutedEvent
        public static readonly RoutedEvent SelectedBrushChangedEvent = EventManager.RegisterRoutedEvent("SelectedBrushChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ColorPicker));
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
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ColorPicker));

        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(ColorPicker));

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
            picker.RaiseSelectedBrushChanged();
        }

        public bool IsOpacityEnabled
        {
            get { return (bool)GetValue(IsOpacityEnabledProperty); }
            set { SetValue(IsOpacityEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsOpacityEnabledProperty =
            DependencyProperty.Register("IsOpacityEnabled", typeof(bool), typeof(ColorPicker), new PropertyMetadata(true));


        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ColorPicker));

        public bool IsTextVisible
        {
            get { return (bool)GetValue(IsTextVisibleProperty); }
            set { SetValue(IsTextVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsTextVisibleProperty =
            DependencyProperty.Register("IsTextVisible", typeof(bool), typeof(ColorPicker), new PropertyMetadata(true));


        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(ColorPicker));

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

        public bool StaysOpen
        {
            get { return (bool)GetValue(StaysOpenProperty); }
            set { SetValue(StaysOpenProperty, value); }
        }

        public static readonly DependencyProperty StaysOpenProperty =
            DependencyProperty.Register("StaysOpen", typeof(bool), typeof(ColorPicker), new PropertyMetadata(false));
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
