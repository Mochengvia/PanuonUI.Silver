using Panuon.UI.Silver.Utils;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// Clock.xaml 的交互逻辑
    /// </summary>
    public partial class Clock : UserControl
    {
        #region Identity
        enum HourMinuteSecond
        {
            Hour,
            Minute,
            Second
        }
        #endregion

        #region Constructor
        public Clock()
        {
            InitializeComponent();
            Loaded += Clock_Loaded;
        }
        #endregion

        #region Property
        ///// <summary>
        ///// get or set clock style
        ///// </summary>
        //public ClockStyle ClockStyle
        //{
        //    get { return (ClockStyle)GetValue(ClockStyleProperty); }
        //    set { SetValue(ClockStyleProperty, value); }
        //}

        //public static readonly DependencyProperty ClockStyleProperty =
        //    DependencyProperty.Register("ClockStyle", typeof(ClockStyle), typeof(Clock), new PropertyMetadata(ClockStyle.Standard));

        /// <summary>
        /// get or set theme brush.
        /// </summary>
        public Brush ThemeBrush
        {
            get { return (Brush)GetValue(ThemeBrushProperty); }
            set { SetValue(ThemeBrushProperty, value); }
        }

        public static readonly DependencyProperty ThemeBrushProperty =
            DependencyProperty.Register("ThemeBrush", typeof(Brush), typeof(Clock), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3E3E3E"))));

        /// <summary>
        /// get or set selected time
        /// </summary>
        public DateTime SelectedTime
        {
            get { return (DateTime)GetValue(SelectedTimeProperty); }
            set { SetValue(SelectedTimeProperty, value); }
        }

        public static readonly DependencyProperty SelectedTimeProperty =
            DependencyProperty.Register("SelectedTime", typeof(DateTime), typeof(Clock));

        #endregion

        #region Event

        private void Clock_Loaded(object sender, RoutedEventArgs e)
        {
            //if(ClockStyle == ClockStyle.Standard)
            //{
                InitTimeTitle();
                InitHourPanel();
                InitMinutePanel();
                InitSecondPanel();
            //}
            //else
            //{
            //    InitDialHour();
            //}
        }

        private void RdbHour_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            var hour = (int)radioButton.Tag;
            SelectedTime = new DateTime(SelectedTime.Year, SelectedTime.Month, SelectedTime.Day, hour, SelectedTime.Minute, SelectedTime.Second);
            ScrollHour.ScrollToVerticalOffset((hour - 3) * radioButton.ActualHeight);
        }

        private void RdbMinute_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            var minute = (int)radioButton.Tag;
            SelectedTime = new DateTime(SelectedTime.Year, SelectedTime.Month, SelectedTime.Day, SelectedTime.Hour, minute, SelectedTime.Second);
            ScrollMinute.ScrollToVerticalOffset((minute - 3) * radioButton.ActualHeight);
        }

        private void RdbSecond_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            var second = (int)radioButton.Tag;
            SelectedTime = new DateTime(SelectedTime.Year, SelectedTime.Month, SelectedTime.Day, SelectedTime.Hour, SelectedTime.Minute, second);
            ScrollSecond.ScrollToVerticalOffset((second - 3) * radioButton.ActualHeight);
        }

        #endregion

        #region Function
        private void InitTimeTitle()
        {
            GrdTime.Children.Clear();
            int count = 0;

            var isChinese = System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag == "zh-CN";
            GrdTime.Children.Add(GetWeekTitleTextBlock(isChinese ? "时" : "Hour", count++));
            GrdTime.Children.Add(GetWeekTitleTextBlock(isChinese ? "分" : "Minute", count++));
            GrdTime.Children.Add(GetWeekTitleTextBlock(isChinese ? "秒" : "Second", count++));
        }

        private void InitHourPanel()
        {
            var count = StkHour.Children.Count;
            for (int i = 0; i < 24 - count; i++)
            {
                var border = new Border() { Height = 35 };

                Grid.SetRow(border, (int)(i / 7));
                Grid.SetColumn(border, i % 7);

                var radioButton = new RadioButton()
                {
                    GroupName = "CLOCK_HOUR",
                };
                RadioButtonHelper.SetRadioButtonStyle(radioButton, RadioButtonStyle.Button);
                RadioButtonHelper.SetCornerRadius(radioButton, new CornerRadius(0));
                radioButton.Click += RdbHour_Click;

                SetBinding("Foreground", radioButton, ForegroundProperty);
                SetBinding("FontSize", radioButton, FontSizeProperty);
                SetBinding("ThemeBrush", radioButton, RadioButtonHelper.CheckedBackgroundProperty);
                border.Child = radioButton;
                StkHour.Children.Add(border);
            }

            for (int i = 0; i < 24; i++)
            {
                var radioButton = (StkHour.Children[i] as Border).Child as RadioButton;

                radioButton.IsChecked = SelectedTime.Hour == i;
                radioButton.Content = i.ToString("00");
                radioButton.Tag = i;
            }

            ScrollHour.ScrollToVerticalOffset((SelectedTime.Hour - 3) * 35);

        }

        private void InitMinutePanel()
        {
            var count = StkMinute.Children.Count;
            for (int i = 0; i < 60 - count; i++)
            {
                var border = new Border() { Height = 35 };
                Grid.SetRow(border, (int)(i / 7));
                Grid.SetColumn(border, i % 7);

                var radioButton = new RadioButton()
                {
                    GroupName = "CLOCK_MINUTE",
                };
                RadioButtonHelper.SetRadioButtonStyle(radioButton, RadioButtonStyle.Button);
                RadioButtonHelper.SetCornerRadius(radioButton, new CornerRadius(0));
                radioButton.Click += RdbMinute_Click;

                SetBinding("Foreground", radioButton, ForegroundProperty);
                SetBinding("FontSize", radioButton, FontSizeProperty);
                SetBinding("ThemeBrush", radioButton, RadioButtonHelper.CheckedBackgroundProperty);
                border.Child = radioButton;
                StkMinute.Children.Add(border);
            }

            for (int i = 0; i < 60; i++)
            {
                var radioButton = (StkMinute.Children[i] as Border).Child as RadioButton;

                radioButton.IsChecked = SelectedTime.Minute == i;
                radioButton.Content = i.ToString("00");
                radioButton.Tag = i;
            }

            ScrollMinute.ScrollToVerticalOffset((SelectedTime.Minute - 3) * 35);
        }

        private void InitSecondPanel()
        {
            var count = StkSecond.Children.Count;
            for (int i = 0; i < 60 - count; i++)
            {
                var border = new Border() { Height = 35 };
                Grid.SetRow(border, (int)(i / 7));
                Grid.SetColumn(border, i % 7);

                var radioButton = new RadioButton()
                {
                    GroupName = "CLOCK_SECOND",
                };
                RadioButtonHelper.SetRadioButtonStyle(radioButton, RadioButtonStyle.Button);
                RadioButtonHelper.SetCornerRadius(radioButton, new CornerRadius(0));
                radioButton.Click += RdbSecond_Click;

                SetBinding("Foreground", radioButton, ForegroundProperty);
                SetBinding("FontSize", radioButton, FontSizeProperty);
                SetBinding("ThemeBrush", radioButton, RadioButtonHelper.CheckedBackgroundProperty);
                border.Child = radioButton;
                StkSecond.Children.Add(border);
            }

            for (int i = 0; i < 60; i++)
            {
                var radioButton = (StkSecond.Children[i] as Border).Child as RadioButton;

                radioButton.IsChecked = SelectedTime.Second == i;
                radioButton.Content = i.ToString("00");
                radioButton.Tag = i;
            }

            ScrollSecond.ScrollToVerticalOffset((SelectedTime.Second - 3) * 35);

        }

        private void InitDialHour()
        {
            var count = CvaDial.Children.Count;
            for (int i = 0; i < 24 - count; i++)
            {
                var border = new Border() { Height = 30 ,Width = 30};
                var point = GetPointOnEllipse(360.0 * i / 24);
                Canvas.SetLeft(border,point.X - 15);
                Canvas.SetTop(border,point.Y - 15);


                var radioButton = new RadioButton()
                {
                    GroupName = "CLOCK_HOUR",
                };
                RadioButtonHelper.SetRadioButtonStyle(radioButton, RadioButtonStyle.Button);
                RadioButtonHelper.SetCornerRadius(radioButton, new CornerRadius(15));
                radioButton.Click += RdbHour_Click;

                SetBinding("Foreground", radioButton, ForegroundProperty);
                SetBinding("FontSize", radioButton, FontSizeProperty);
                SetBinding("ThemeBrush", radioButton, RadioButtonHelper.CheckedBackgroundProperty);
                border.Child = radioButton;
                CvaDial.Children.Add(border);
            }

            for (int i = 0; i < 24; i++)
            {
                var radioButton = (CvaDial.Children[i] as Border).Child as RadioButton;

                radioButton.IsChecked = SelectedTime.Hour == i;
                radioButton.Content = i.ToString("00");
                radioButton.Tag = i;
            }

        }

        private void SetBinding(string propertyName, DependencyObject target, DependencyProperty targetProperty)
        {
            var binding = new Binding { Path = new PropertyPath(propertyName), Source = this, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            BindingOperations.SetBinding(target, targetProperty, binding);
        }

        private System.Windows.Controls.TextBlock GetWeekTitleTextBlock(string time, int column)
        {
            var textBlock = new System.Windows.Controls.TextBlock()
            {
                Text = time,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            SetBinding("Foreground", textBlock, ForegroundProperty);
            Grid.SetColumn(textBlock, column);
            return textBlock;
        }

        private Point GetPointOnEllipse(double angle)
        {
            var radius = CvaDial.ActualHeight / 2 - 20 ;
            var x = CvaDial.ActualWidth / 2 + radius * Math.Cos(angle * Math.PI / 180);
            var y = CvaDial.ActualHeight / 2 + radius * Math.Sin(angle * Math.PI / 180);
            return new Point(x, y);
        }
        #endregion
    }
}
