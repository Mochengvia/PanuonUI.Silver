using Panuon.UI.Silver;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using UIBrowser.Helpers;

namespace UIBrowser.PartialViews.Native
{
    /// <summary>
    /// ComboBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class AnimationHelperView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public AnimationHelperView()
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

        private void SldBeginTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateCode();
        }

        private void SldDuration_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateCode();
        }

        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            var button = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 35,
                Width = 150,
                Content = "Button"
            };

            GrdContainer.Children.Clear();
            GrdContainer.Children.Add(button);

            AnimationHelper.SetBeginTimeSeconds(button, SldBeginTime.Value);
            AnimationHelper.SetDurationSeconds(button, SldDuration.Value);

            if (ChbFadeIn.IsChecked == true)
            {
                AnimationHelper.SetFadeIn(button, true);
            }
            if (ChbFadeOut.IsChecked == true)
            {
                AnimationHelper.SetFadeOut(button, true);
            }
            if (ChbSlideFromLeft.IsChecked == true)
            {
                AnimationHelper.SetSlideInFromLeft(button, true);
            }
            if (ChbSlideFromTop.IsChecked == true)
            {
                AnimationHelper.SetSlideInFromTop(button, true);
            }
            if (ChbSlideFromRight.IsChecked == true)
            {
                AnimationHelper.SetSlideInFromRight(button, true);
            }
            if (ChbSlideFromBottom.IsChecked == true)
            {
                AnimationHelper.SetSlideInFromBottom(button, true);
            }

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
        }

        private void UpdateCode()
        {
            //var calendarMode = CdrCustom.CalendarMode;
            //var maxDate = CdrCustom.MaxDate;
            //var minDate = CdrCustom.MinDate;
            //var isSundayFirst = CdrCustom.IsSundayFirst;

            //TbCode.Text = $"<pu:Calendar  Width=\"{CdrCustom.ActualWidth}\"" +
            //            $"\nHeight=\"{CdrCustom.ActualHeight}\"" +
            //            (calendarMode == Panuon.UI.Silver.CalendarMode.Date ? "" : $"\nCalendarMode=\"{calendarMode}\"") +
            //            (maxDate == null ? "" : $"\nMaxDate=\"{((DateTime)maxDate).ToString("yyyy-MM-dd")}\"") +
            //            (minDate == null ? "" : $"\nMaxDate=\"{((DateTime)minDate).ToString("yyyy-MM-dd")}\"") +
            //            $"\nThemeBrush=\"{CdrCustom.ThemeBrush.ToColor().ToHexString(false)}\"" +
            //            (isSundayFirst ? "" : "\nIsSundayFirst=\"False\"") +
            //            " />";
        }




        #endregion


    }
}
