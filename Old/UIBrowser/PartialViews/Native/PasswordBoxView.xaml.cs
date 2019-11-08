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

        private void ChbShowIcon_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            PasswordBoxHelper.SetIcon(PbCustom, ChbShowIcon.IsChecked == true ? "\uf11c" : null);

            UpdateCode();
        }

        private void ChbShowWatermark_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            PasswordBoxHelper.SetWatermark(PbCustom, ChbShowWatermark.IsChecked == true ? "Watermark" : null);

            UpdateCode();
        }

        private void ChbShowPwdButton_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            PasswordBoxHelper.SetIsShowPwdButtonVisible(PbCustom, ChbShowPwdButton.IsChecked == true);

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
            PasswordBoxHelper.SetCornerRadius(PbCustom, new CornerRadius(SldCornerRadius.Value));

            PasswordBoxHelper.SetFocusedBorderBrush(PbCustom, color.ToBrush());
            PasswordBoxHelper.SetFocusedShadowColor(PbCustom, color);
        }

        private void UpdateCode()
        {
            var icon = PasswordBoxHelper.GetIcon(PbCustom);
            var watermark = PasswordBoxHelper.GetWatermark(PbCustom);
            var cornerRadius = SldCornerRadius.Value;
            var isShowPwdButtonVisible = PasswordBoxHelper.GetIsShowPwdButtonVisible(PbCustom);

            TbCode.Text = "<PasswordBox  Height=\"30\"" +
                        $"\nWidth=\"{PbCustom.Width}\"" +
                        (watermark == null ? "" : $"\npu:PasswordBoxHelper.Watermark=\"{watermark}\"") +
                        (icon == null ? "" : $"\npu:PasswordBoxHelper.Icon=\"&#xf11c;\"") +
                        $"\npu:PasswordBoxHelper.FocusedBorderBrush=\"{PasswordBoxHelper.GetFocusedBorderBrush(PbCustom).ToColor().ToHexString(false)}\"" +
                        $"\npu:PasswordBoxHelper.FocusedShadowColor=\"{PasswordBoxHelper.GetFocusedShadowColor(PbCustom).ToHexString(false)}\"" +
                        (cornerRadius == 0 ? "" : $"\npu:PasswordBoxHelper.CornerRadius=\"{cornerRadius}\"") +
                        (isShowPwdButtonVisible ? $"\npu:PasswordBoxHelper.IsShowPwdButtonVisible=\"{isShowPwdButtonVisible}\"" : "") +
                        " />";
        }



        #endregion


    }
}
