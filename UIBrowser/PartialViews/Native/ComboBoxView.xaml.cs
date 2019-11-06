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
    public partial class ComboBoxView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public ComboBoxView()
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

            ComboBoxHelper.SetIcon(CmbCustom, ChbShowIcon.IsChecked == true ? "\uf11c" : null);

            UpdateCode();
        }

        private void ChbShowWatermark_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            ComboBoxHelper.SetWatermark(CmbCustom, ChbShowWatermark.IsChecked == true ? "Watermark" : null);

            UpdateCode();
        }

        private void ChbShowSearchBox_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            ComboBoxHelper.SetIsSearchTextBoxVisible(CmbCustom, ChbShowSearchBox.IsChecked == true);

            UpdateCode();
        }

        private void CmbCustom_SearchTextChanged(object sender, Panuon.UI.Silver.Core.SearchTextChangedEventArgs e)
        {
            if (!IsLoaded)
                return;

            foreach (ComboBoxItem item in CmbCustom.Items)
            {
                item.Visibility = item.Content.ToString().Contains(e.Text) ? Visibility.Visible : Visibility.Collapsed;
            }

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
            ComboBoxHelper.SetCornerRadius(CmbCustom, new CornerRadius(SldCornerRadius.Value));


            ComboBoxHelper.SetSelectedBackground(CmbCustom, new Color() { A = 50, R = color.R, G = color.G, B = color.B }.ToBrush());
            ComboBoxHelper.SetHoverBackground(CmbCustom, new Color() { A = 30, R = color.R, G = color.G, B = color.B }.ToBrush());
        }

        private void UpdateCode()
        {
            var icon = ComboBoxHelper.GetIcon(CmbCustom);
            var watermark = ComboBoxHelper.GetWatermark(CmbCustom);
            var cornerRadius = SldCornerRadius.Value;
            var searchBoxVisible = ComboBoxHelper.GetIsSearchTextBoxVisible(CmbCustom);

            TbCode.Text = "<ComboBox  Height=\"30\"" +
                        $"\nWidth=\"{CmbCustom.Width}\"" +
                        (watermark == null ? "" : $"\npu:ComboBoxHelper.Watermark=\"{watermark}\"") +
                        (icon == null ? "" : $"\npu:ComboBoxHelper.Icon=\"&#xf11c;\"") +
                        $"\npu:ComboBoxHelper.HoverBackground=\"{ComboBoxHelper.GetHoverBackground(CmbCustom).ToColor().ToHexString()}\"" +
                        $"\npu:ComboBoxHelper.SelectedBackground=\"{ComboBoxHelper.GetSelectedBackground(CmbCustom).ToColor().ToHexString()}\"" +
                        (cornerRadius == 0 ? "" : $"\npu:ComboBoxHelper.CornerRadius=\"{cornerRadius}\"") +
                        (searchBoxVisible ? "\npu:ComboBoxHelper.IsSearchTextBoxVisible=\"True\"" : "") +
                        (searchBoxVisible ? "\npu:ComboBoxHelper.SearchTextChanged=\"...\"" : "") +
                        " />";
        }
        #endregion

       
    }
}
