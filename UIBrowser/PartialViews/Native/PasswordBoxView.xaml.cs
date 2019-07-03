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
    /// PasswordBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class PasswordBoxView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public PasswordBoxView()
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

        private void SliderTheme_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void SliderCornerRadius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void SliderWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
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
                    AnimationHelper.SetEasingFunction(GroupPalette, new CubicEase() { EasingMode = EasingMode.EaseOut });
                    AnimationHelper.SetMarginTo(GroupPalette, new Thickness(0, 0, 0, 0));
                    AnimationHelper.SetEasingFunction(GroupCode, new CubicEase() { EasingMode = EasingMode.EaseOut });
                    AnimationHelper.SetMarginTo(GroupCode, new Thickness(0, 0, 0, 0));
                }
                else
                {
                    GroupPalette.Margin = new Thickness(0, 0, 0, 0);
                    GroupCode.Margin = new Thickness(0, 0, 0, 0);
                }
                BtnViewCode.Content = Properties.Resource.ViewCode;
            }
            else
            {
                if (Helper.Tier == 2)
                {
                    AnimationHelper.SetEasingFunction(GroupPalette, new CubicEase() { EasingMode = EasingMode.EaseOut });
                    AnimationHelper.SetMarginTo(GroupPalette, new Thickness(0, -120, 0, 0));
                    AnimationHelper.SetEasingFunction(GroupCode, new CubicEase() { EasingMode = EasingMode.EaseOut });
                    AnimationHelper.SetMarginTo(GroupCode, new Thickness(0, 0, 0, -120));
                }
                else
                {
                    GroupPalette.Margin = new Thickness(0, -120, 0, 0);
                    GroupCode.Margin = new Thickness(0, 0, 0, -120);
                }
                BtnViewCode.Content = Properties.Resource.CloseCodeViewer;
            }
            _isCodeViewing = !_isCodeViewing;
        }

        private void MenuItem_CopyCode(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TbCode.Text);
        }

        private void ChbShowIcon_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            PasswordBoxHelper.SetIcon(PbCustom, ChbShowIcon.IsChecked == true ? "" : null);

            UpdateCode();
        }

        private void ChbShowWatermark_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            PasswordBoxHelper.SetWatermark(PbCustom, ChbShowWatermark.IsChecked == true ? "Watermark" : null);

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
                    AnimationHelper.SetSlideInFromBottom(GroupPalette, true);
                    RectBackground.Fill = FindResource("GridBrush") as Brush;
                    GroupBoxHelper.SetEffect(GroupPalette, FindResource("DropShadow") as Effect);
                    GroupBoxHelper.SetEffect(GroupCode, FindResource("DropShadow") as Effect);
                    break;
            }
        }
        private void UpdateTemplate()
        {
            var color = Helper.GetColorByOffset(_linearGradientBrush.GradientStops, SliderTheme.Value / 7);
            PasswordBoxHelper.SetCornerRadius(PbCustom, new CornerRadius(SliderCornerRadius.Value));

            PasswordBoxHelper.SetFocusedBorderBrush(PbCustom, color.ToBrush());
            PasswordBoxHelper.SetFocusedShadowColor(PbCustom, color);
        }

        private void UpdateCode()
        {
            var icon = PasswordBoxHelper.GetIcon(PbCustom);
            var watermark = PasswordBoxHelper.GetWatermark(PbCustom);
            var cornerRadius = SliderCornerRadius.Value;

            TbCode.Text = "<PasswordBox  Height=\"30\"" +
                        $"\nWidth=\"{PbCustom.Width}\"" +
                        (watermark == null ? "" : $"\npu:PasswordBoxHelper.Watermark=\"{watermark}\"") +
                        (icon == null ? "" : $"\npu:PasswordBoxHelper.Icon=\"{icon}\"") +
                        $"\npu:PasswordBoxHelper.FocusedBorderBrush=\"{PasswordBoxHelper.GetFocusedBorderBrush(PbCustom).ToColor().ToHexString(false)}\"" +
                        $"\npu:PasswordBoxHelper.FocusedShadowColor=\"{PasswordBoxHelper.GetFocusedShadowColor(PbCustom).ToHexString(false)}\"" +
                        (cornerRadius == 0 ? "" : $"\npu:ButtonHelper.CornerRadius=\"{cornerRadius}\"") +
                        " />";
        }


        #endregion

       
    }
}
