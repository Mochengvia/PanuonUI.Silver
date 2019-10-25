using Panuon.UI.Silver;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using UIBrowser.Helpers;

namespace UIBrowser.PartialViews.Custom
{
    /// <summary>
    /// ComboBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class CalendarView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public CalendarView()
        {
            InitializeComponent();
            Loaded += ButtonView_Loaded;
            UpdateVisualEffect();
            _linearGradientBrush = FindResource("ColorSelectorBrush") as LinearGradientBrush;

        }

        #region Event

        private void ButtonView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTemplate();
            UpdateCode();
        }

        private void RdbCalendarMode_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;
            var rdb = sender as RadioButton;

            CdrCustom.CalendarMode = (Panuon.UI.Silver.CalendarMode)Enum.Parse(typeof(Panuon.UI.Silver.CalendarMode), rdb.Content.ToString());

            UpdateCode();
        }

        private void SldTheme_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void BtnViewCode_Click(object sender, RoutedEventArgs e)
        {
            if (_isCodeViewing)
            {
                if (Helper.Tier == 2)
                {
                    AnimationHelper.SetEasingFunction(GrpPalette, new CubicEase() { EasingMode = EasingMode.EaseOut });
                    AnimationHelper.SetMarginTo(GrpPalette, new Thickness(0, 0, 0, 0));
                    AnimationHelper.SetEasingFunction(GrpCode, new CubicEase() { EasingMode = EasingMode.EaseOut });
                    AnimationHelper.SetMarginTo(GrpCode, new Thickness(0, 0, 0, 0));
                }
                else
                {
                    GrpPalette.Margin = new Thickness(0, 0, 0, 0);
                    GrpCode.Margin = new Thickness(0, 0, 0, 0);
                }
                BtnViewCode.Content = Properties.Resource.ViewCode;
            }
            else
            {
                if (Helper.Tier == 2)
                {
                    AnimationHelper.SetEasingFunction(GrpPalette, new CubicEase() { EasingMode = EasingMode.EaseOut });
                    AnimationHelper.SetMarginTo(GrpPalette, new Thickness(0, -120, 0, 0));
                    AnimationHelper.SetEasingFunction(GrpCode, new CubicEase() { EasingMode = EasingMode.EaseOut });
                    AnimationHelper.SetMarginTo(GrpCode, new Thickness(0, 0, 0, -120));
                }
                else
                {
                    GrpPalette.Margin = new Thickness(0, -120, 0, 0);
                    GrpCode.Margin = new Thickness(0, 0, 0, -120);
                }
                BtnViewCode.Content = Properties.Resource.CloseCodeViewer;
            }
            _isCodeViewing = !_isCodeViewing;
        }

        private void MenuItem_CopyCode(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TbCode.Text);
        }

        private void ChbSundayFirst_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            CdrCustom.IsSundayFirst = ChbSundayFirst.IsChecked == true;

            UpdateCode();
        }

        private void ChbLimitMax_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            CdrCustom.MaxDate = ChbLimitMax.IsChecked == true ? DateTime.Now.Date.AddMonths(1) : (DateTime?)null;
            UpdateCode();
        }

        private void ChbLimitMin_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            CdrCustom.MinDate = ChbLimitMin.IsChecked == true ? DateTime.Now.Date.AddMonths(-1) : (DateTime?)null;
            UpdateCode();
        }

        #endregion

        #region Function
        private void UpdateVisualEffect()
        {
            switch (Helper.Tier)
            {
                case 1:
                case 2:
                    AnimationHelper.SetSlideInFromBottom(GrpPalette, true);
                    RectBackground.Fill = FindResource("GridBrush") as Brush;
                    GroupBoxHelper.SetShadowColor(GrpPalette, Colors.LightGray);
                    GroupBoxHelper.SetShadowColor(GrpCode, Colors.LightGray);
                    break;
            }
        }
        private void UpdateTemplate()
        {
            var color = Helper.GetColorByOffset(_linearGradientBrush.GradientStops, SldTheme.Value / 7);
            CdrCustom.ThemeBrush = color.ToBrush();
        }

        private void UpdateCode()
        {
            var calendarMode = CdrCustom.CalendarMode;
            var maxDate = CdrCustom.MaxDate;
            var minDate = CdrCustom.MinDate;
            var isSundayFirst = CdrCustom.IsSundayFirst;

            TbCode.Text = $"<pu:Calendar  Width=\"{CdrCustom.ActualWidth}\"" +
                        $"\nHeight=\"{CdrCustom.ActualHeight}\"" +
                        (calendarMode == Panuon.UI.Silver.CalendarMode.Date ? "" : $"\nCalendarMode=\"{calendarMode}\"") +
                        (maxDate == null ? "" : $"\nMaxDate=\"{((DateTime)maxDate).ToString("yyyy-MM-dd")}\"") +
                        (minDate == null ? "" : $"\nMaxDate=\"{((DateTime)minDate).ToString("yyyy-MM-dd")}\"") +
                        $"\nThemeBrush=\"{CdrCustom.ThemeBrush.ToColor().ToHexString(false)}\"" +
                        (isSundayFirst ? "" : "\nIsSundayFirst=\"False\"") +
                        " />";
        }




        #endregion

    }
}
