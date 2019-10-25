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
    /// ButtonView.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public ButtonView()
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

        private void SldWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void RdbBaseStyle_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;
            var rdb = sender as RadioButton;

            ButtonHelper.SetButtonStyle(BtnCustom, (ButtonStyle)Enum.Parse(typeof(ButtonStyle), rdb.Content.ToString()));

            UpdateTemplate();
            UpdateCode();
        }

        private void ChbSink_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            ButtonHelper.SetClickStyle(BtnCustom, ChbSink.IsChecked == true ? ClickStyle.Sink : ClickStyle.None);
            UpdateCode();
        }

        private void ChbWaiting_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            ButtonHelper.SetIsWaiting(BtnCustom, ChbWaiting.IsChecked == true);
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
            ButtonHelper.SetCornerRadius(BtnCustom, new CornerRadius(SldCornerRadius.Value));
            BtnCustom.Width = SldWidth.Value;

            if (BtnCustom.Width < 60)
            {
                BtnCustom.Content = "";
                ButtonHelper.SetWaitingContent(BtnCustom, null);
            }
            else
            {
                BtnCustom.Content = " Button";
                ButtonHelper.SetWaitingContent(BtnCustom, "Please wait...");
            }


            switch (ButtonHelper.GetButtonStyle(BtnCustom))
            {
                case ButtonStyle.Standard:
                    BtnCustom.Foreground = Colors.White.ToBrush();
                    BtnCustom.Background = new Color() { A = 200, R = color.R, G = color.G, B = color.B }.ToBrush();
                    ButtonHelper.SetHoverBrush(BtnCustom, color.ToBrush());
                    break;
                case ButtonStyle.Hollow:
                    BtnCustom.Background = Colors.Transparent.ToBrush();
                    BtnCustom.Foreground = color.ToBrush();
                    BtnCustom.BorderBrush = color.ToBrush();
                    ButtonHelper.SetHoverBrush(BtnCustom, color.ToBrush());
                    break;
                case ButtonStyle.Outline:
                    BtnCustom.Background = Colors.Transparent.ToBrush();
                    BtnCustom.Foreground = new Color() { A = 150, R = color.R, G = color.G, B = color.B }.ToBrush();
                    BtnCustom.BorderBrush = new Color() { A = 150, R = color.R, G = color.G, B = color.B }.ToBrush();
                    ButtonHelper.SetHoverBrush(BtnCustom, color.ToBrush());
                    break;
                case ButtonStyle.Link:
                    BtnCustom.Background = Colors.Transparent.ToBrush();
                    BtnCustom.Foreground = new Color() { A = 150, R = color.R, G = color.G, B = color.B }.ToBrush();
                    ButtonHelper.SetHoverBrush(BtnCustom, color.ToBrush());
                    break;
            }
        }

        private void UpdateCode()
        {
            var buttonStyle = ButtonHelper.GetButtonStyle(BtnCustom);
            var cornerRadius = SldCornerRadius.Value;
            var isWaiting = ButtonHelper.GetIsWaiting(BtnCustom);
            var isSink = ButtonHelper.GetClickStyle(BtnCustom);

            TbCode.Text = "<Button  Height=\"30\"" +
                        $"\nWidth=\"{BtnCustom.Width}\"" +
                        $"\nContent=\"{BtnCustom.Content}\"" +
                        (BtnCustom.Width < 60 ? $"\npu:ButtonHelper.WaitingContent=\"{{x:Null}}\"" : "") +
                        (isSink == ClickStyle.Sink ? $"\npu:ButtonHelper.ClickStyle=\"Sink\"" : "") +
                        (isWaiting ? $"\npu:ButtonHelper.IsWaiting=\"True\"" : "") +
                        "\nFontFamily=\"{StaticResource FontAwesome}\"" +
                        (buttonStyle == ButtonStyle.Standard ? "" : $"\npu:ButtonHelper.ButtonStyle=\"{buttonStyle}\"") +
                        (buttonStyle == ButtonStyle.Standard ? $"\nBackground=\"{BtnCustom.Background.ToColor().ToHexString()}\"" : "") +
                        (buttonStyle == ButtonStyle.Standard ? "" : $"\nBorderBrush=\"{BtnCustom.BorderBrush.ToColor().ToHexString()}\"") +
                        (buttonStyle == ButtonStyle.Standard ? "" : $"\nForeground=\"{BtnCustom.Foreground.ToColor().ToHexString()}\"") +
                        $"\npu:ButtonHelper.HoverBrush=\"{ButtonHelper.GetHoverBrush(BtnCustom).ToColor().ToHexString(false)}\"" +
                        (cornerRadius == 0 ? "" : $"\npu:ButtonHelper.CornerRadius=\"{cornerRadius}\"") +
                        " />";
        }

        #endregion


    }
}
