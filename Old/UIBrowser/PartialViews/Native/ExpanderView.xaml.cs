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
    /// GroupBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class ExpanderView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public ExpanderView()
        {
            InitializeComponent();
            Loaded += ButtonView_Loaded;
            UpdateVisualEffect();
            _linearGradientBrush = FindResource("ColorSelectorBrush") as LinearGradientBrush;
        }

        #region Event Handler

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

        private void SldHeaderPadding_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
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

            ExpanderHelper.SetIcon(EpdCustom, ChbShowIcon.IsChecked == true ? "\uf11c" : null);

            UpdateTemplate();
            UpdateCode();
        }

        private void ChbShowSplitLine_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;


            UpdateCode();
        }

        private void ChbShowClearButton_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;


            UpdateCode();
        }

        private void ChbShowShadow_CheckChanged(object sender, RoutedEventArgs e)
        {
            ExpanderHelper.SetShadowColor(EpdCustom, ChbShowShadow.IsChecked == true ? Colors.LightGray : (Color?)null);
        }

        private void RdbBaseStyle_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;
            var rdb = sender as RadioButton;

            ExpanderHelper.SetExpanderStyle(EpdCustom, (ExpanderStyle)Enum.Parse(typeof(ExpanderStyle), rdb.Content.ToString()));

            UpdateTemplate();
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
                    ExpanderHelper.SetShadowColor(GrpPalette, Colors.LightGray);
                    ExpanderHelper.SetShadowColor(GrpCode, Colors.LightGray);
                    break;
            }
        }
        private void UpdateTemplate()
        {
            if (ExpanderHelper.GetIcon(EpdCustom) == null)
                ExpanderHelper.SetHeaderPadding(EpdCustom, new Thickness(5, SldHeaderPadding.Value, 0, SldHeaderPadding.Value));
            else
                ExpanderHelper.SetHeaderPadding(EpdCustom, new Thickness(0, SldHeaderPadding.Value, 0, SldHeaderPadding.Value));
            ExpanderHelper.SetCornerRadius(EpdCustom, new CornerRadius(SldCornerRadius.Value));
        }

        private void UpdateCode()
        {
            var icon = ExpanderHelper.GetIcon(EpdCustom);
            var cornerRadius = SldCornerRadius.Value;
            var headerPadding = SldHeaderPadding.Value;
            var shadow = ExpanderHelper.GetShadowColor(EpdCustom);

            TbCode.Text = $"<Expander Width=\"{EpdCustom.Width}\"" +
                        $"\nHeader=\"{EpdCustom.Header}\"" +
                        $"\nVerticalAlignment=\"Center\"" +
                        $"\nHorizontalAlignment=\"Center\"" +
                        (icon == null ? "" : $"\npu:ExpanderHelper.Icon=\"&#xf11c;\"") +
                        (cornerRadius == 0 ? "" : $"\npu:ExpanderHelper.CornerRadius=\"{cornerRadius}\"") +
                        (headerPadding == 5 ? "" : $"\npu:ExpanderHelper.HeaderPadding=\"10,{headerPadding}\"") +
                        (shadow == null ? "" : $"\npu:ExpanderHelper.ShadowColor=\"LightGray\"") +
                        " />";
        }
        #endregion

        
    }
}
