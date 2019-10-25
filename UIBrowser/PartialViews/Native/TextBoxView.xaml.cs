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
    /// TextBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class TextBoxView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public TextBoxView()
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

            TextBoxHelper.SetIcon(TbCustom, ChbShowIcon.IsChecked == true ? "\uf11c" : null);

            UpdateCode();
        }

        private void ChbShowWatermark_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            TextBoxHelper.SetWatermark(TbCustom, ChbShowWatermark.IsChecked == true ? "Watermark" : null);

            UpdateCode();
        }

        private void ChbShowClearButton_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            TextBoxHelper.SetIsClearButtonVisible(TbCustom, ChbShowClearButton.IsChecked == true);

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
            TextBoxHelper.SetCornerRadius(TbCustom, new CornerRadius(SldCornerRadius.Value));

            TextBoxHelper.SetFocusedBorderBrush(TbCustom, color.ToBrush());
            TextBoxHelper.SetFocusedShadowColor(TbCustom, color);
        }

        private void UpdateCode()
        {
            var icon = TextBoxHelper.GetIcon(TbCustom);
            var watermark = TextBoxHelper.GetWatermark(TbCustom);
            var cornerRadius = SldCornerRadius.Value;
            var isClearButtonVisible = TextBoxHelper.GetIsClearButtonVisible(TbCustom);

            TbCode.Text = "<TextBox  Height=\"30\"" +
                        $"\nWidth=\"{TbCustom.Width}\"" +
                        (watermark == null ? "" : $"\npu:TextBoxHelper.Watermark=\"{watermark}\"") +
                        (icon == null ? "" : $"\npu:TextBoxHelper.Icon=\"&#xf11c;\"") +
                        $"\npu:TextBoxHelper.FocusedBorderBrush=\"{TextBoxHelper.GetFocusedBorderBrush(TbCustom).ToColor().ToHexString(false)}\"" +
                        $"\npu:TextBoxHelper.FocusedShadowColor=\"{TextBoxHelper.GetFocusedShadowColor(TbCustom).ToHexString(false)}\"" +
                        (cornerRadius == 0 ? "" : $"\npu:TextBoxHelper.CornerRadius=\"{cornerRadius}\"") +
                        (isClearButtonVisible ? $"\npu:TextBoxHelper.IsClearButtonVisible=\"{isClearButtonVisible}\"" : "") +
                        " />";
        }



        #endregion


    }
}
