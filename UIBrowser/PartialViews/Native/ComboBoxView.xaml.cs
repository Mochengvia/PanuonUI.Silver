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

            ComboBoxHelper.SetIcon(CmbCustom, ChbShowIcon.IsChecked == true ? "" : null);

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

        private void CmbCustom_SearchTextChanged(object sender, RoutedPropertyChangedEventArgs<string> e)
        {
            if (!IsLoaded)
                return;

            var value = e.NewValue as string;
            foreach (ComboBoxItem item in CmbCustom.Items)
            {
                item.Visibility = item.Content.ToString().Contains(value) ? Visibility.Visible : Visibility.Collapsed;
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
            ComboBoxHelper.SetCornerRadius(CmbCustom, new CornerRadius(SliderCornerRadius.Value));


            ComboBoxHelper.SetSelectedBrush(CmbCustom, new Color() { A = 50, R = color.R, G = color.G, B = color.B }.ToBrush());
            ComboBoxHelper.SetHoverBrush(CmbCustom, new Color() { A = 30, R = color.R, G = color.G, B = color.B }.ToBrush());
        }

        private void UpdateCode()
        {
            var icon = ComboBoxHelper.GetIcon(CmbCustom);
            var watermark = ComboBoxHelper.GetWatermark(CmbCustom);
            var cornerRadius = SliderCornerRadius.Value;
            var searchBoxVisible = ComboBoxHelper.GetIsSearchTextBoxVisible(CmbCustom);

            TbCode.Text = "<ComboBox  Height=\"30\"" +
                        $"\nWidth=\"{CmbCustom.Width}\"" +
                        (watermark == null ? "" : $"\npu:ComboBoxHelper.Watermark=\"{watermark}\"") +
                        (icon == null ? "" : $"\npu:ComboBoxHelper.Icon=\"{icon}\"") +
                        $"\npu:ComboBoxHelper.HoverBrush=\"{ComboBoxHelper.GetHoverBrush(CmbCustom).ToColor().ToHexString()}\"" +
                        $"\npu:ComboBoxHelper.SelectedBrush=\"{ComboBoxHelper.GetSelectedBrush(CmbCustom).ToColor().ToHexString()}\"" +
                        (cornerRadius == 0 ? "" : $"\npu:ComboBoxHelper.CornerRadius=\"{cornerRadius}\"") +
                        (searchBoxVisible ? "pu:ComboBoxHelper.IsSearchTextBoxVisible=\"True\"" : "") +
                        (searchBoxVisible ? "pu:ComboBoxHelper.SearchTextChanged=\"...\"" : "") +
                        " />";
        }
        #endregion

    }
}
