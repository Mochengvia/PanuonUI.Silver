using Panuon.UI.Silver;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using UIBrowser.Helpers;

namespace UIBrowser.PartialViews.Native
{
    /// <summary>
    /// ProgressBarView.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressBarView : UserControl
    {
        #region Identity
        private bool _usingAnimation;

        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public ProgressBarView()
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

        private void SldTheme_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void SldCornerRadius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void SliderProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void RdbProgressBarStyle_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;
            var rdb = sender as RadioButton;
            var pgbStyle = (ProgressBarStyle)Enum.Parse(typeof(ProgressBarStyle), rdb.Content.ToString());
            ProgressBarHelper.SetProgressBarStyle(PgbCustom, pgbStyle);

            PgbCustom.Height = pgbStyle == ProgressBarStyle.Standard ? 30 : 80;
            PgbCustom.Width = pgbStyle == ProgressBarStyle.Standard ? 200 : 80;

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


        private void ChbIndeterminate_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            PgbCustom.IsIndeterminate = ChbIndeterminate.IsChecked == true;

            UpdateCode();
        }

        private void ChbUsingAnimation_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            PgbCustom.BeginAnimation(ProgressBar.ValueProperty, null);

            _usingAnimation = ChbUsingAnimation.IsChecked == true;

            UpdateCode();
        }

        private void ChbShowPercent_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            ProgressBarHelper.SetIsPercentVisible(PgbCustom, ChbShowPercent.IsChecked == true);

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
            ProgressBarHelper.SetCornerRadius(PgbCustom, SldCornerRadius.Value);

            if (_usingAnimation)
                ProgressBarHelper.SetAnimateTo(PgbCustom, SldProgress.Value);
            else
                PgbCustom.Value = SldProgress.Value;

            switch (ProgressBarHelper.GetProgressBarStyle(PgbCustom))
            {
                case ProgressBarStyle.Standard:
                    PgbCustom.Background = new Color() { A = 30, R = color.R, G = color.G, B = color.B }.ToBrush();
                    PgbCustom.BorderBrush = Colors.Transparent.ToBrush();
                    PgbCustom.Foreground = color.ToBrush();
                    break;
                case ProgressBarStyle.Ring:
                    PgbCustom.Background = Colors.White.ToBrush();
                    PgbCustom.BorderBrush = new Color() { A = 30, R = color.R, G = color.G, B = color.B }.ToBrush();
                    PgbCustom.Foreground = color.ToBrush();
                    break;
            }
        }

        private void UpdateCode()
        {
            var pgStyle = ProgressBarHelper.GetProgressBarStyle(PgbCustom);
            var value = _usingAnimation ? ProgressBarHelper.GetAnimateTo(PgbCustom) : PgbCustom.Value;
            var isIndeterminate = PgbCustom.IsIndeterminate;
            var cornerRadius = SldCornerRadius.Value;
            var percentVisible = ProgressBarHelper.GetIsPercentVisible(PgbCustom);

            TbCode.Text = $"<ProgressBar  Height=\"{PgbCustom.Height}\"" +
                        $"\nWidth=\"{PgbCustom.Width}\"" +
                        (pgStyle == ProgressBarStyle.Standard ? "" : $"\npu:ProgressBarHelper.ProgressBarStyle=\"{pgStyle}\"") +
                        (pgStyle == ProgressBarStyle.Standard ? $"\nBackground=\"{PgbCustom.Background}\"" : $"\nBorderBrush=\"{PgbCustom.BorderBrush}\"") +
                        $"\nForeground=\"{PgbCustom.Foreground}\"" +
                        (value == 0 ? "" : _usingAnimation ? $"\npu:ProgressBarHelper.AnimateTo=\"{value}\"" : $"\nValue=\"{value}\"") +
                        (cornerRadius == 0 ? "" : $"\npu:ProgressBarHelper.CornerRadius=\"{cornerRadius}\"") +
                        (isIndeterminate ? "\nIsIndeterminate=\"True\"" : "") +
                        (percentVisible ? "\npu:ProgressBarHelper.IsPercentVisible=\"True\"" : "") +
                        " />";
        }



        #endregion


    }
}
