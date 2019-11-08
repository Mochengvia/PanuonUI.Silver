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
    public partial class LoadingView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public LoadingView()
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

        private void RdbBaseStyle_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;
            var rdb = sender as RadioButton;

            LdCustom.LoadingStyle = (LoadingStyle)Enum.Parse(typeof(LoadingStyle), rdb.Content.ToString());

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



        private void ChbIsRunning_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            LdCustom.IsRunning = ChbIsRunning.IsChecked == true;
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
            switch (LdCustom.LoadingStyle)
            {
                case LoadingStyle.Standard:
                    LdCustom.Foreground = color.ToBrush();
                    break;
                case LoadingStyle.Wave:
                    LdCustom.Foreground = color.ToBrush();
                    break;
                case LoadingStyle.Classic:
                    LdCustom.Foreground = color.ToBrush();
                    break;
                case LoadingStyle.Ring:
                    LdCustom.Background = new Color() { A = 50, R = color.R, G = color.G, B = color.B }.ToBrush();
                    LdCustom.Foreground = color.ToBrush();
                    break;
                case LoadingStyle.Ring2:
                    LdCustom.Background = new Color() { A = 50, R = color.R, G = color.G, B = color.B }.ToBrush();
                    LdCustom.Foreground = color.ToBrush();
                    break;
            }
        }

        private void UpdateCode()
        {
            var loadingStyle = LdCustom.LoadingStyle;
            var isRunning = LdCustom.IsRunning;

            TbCode.Text = $"<pu:Loading  Width=\"{LdCustom.ActualWidth}\"" +
                        $"\nHeight=\"{LdCustom.ActualHeight}\"" +
                        (loadingStyle == LoadingStyle.Standard ? "" : $"\nLoadingStyle=\"{loadingStyle}\"") +
                        $"\nForeground=\"{LdCustom.Foreground.ToColor().ToHexString(false)}\"" +
                        ((loadingStyle == LoadingStyle.Ring || loadingStyle == LoadingStyle.Ring2) ? $"\nBackground=\"{LdCustom.Background.ToColor().ToHexString(true)}\"" : "") +
                        (isRunning ? "\nIsRunning=\"True\"" : "") +
                        " />";
        }

        #endregion

    }
}
