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
    public partial class CarouselView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public CarouselView()
        {
            InitializeComponent();
            Loaded += CarouselView_Loaded;
            UpdateVisualEffect();
            _linearGradientBrush = FindResource("ColorSelectorBrush") as LinearGradientBrush;
        }

        #region Event Handler
        private void CarouselView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTemplate();
            UpdateCode();
        }

        private void BtnInc_Click(object sender, RoutedEventArgs e)
        {
            CrlCustom.Index++;
            UpdateCode();
        }

        private void BtnDec_Click(object sender, RoutedEventArgs e)
        {
            CrlCustom.Index--;
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

        private void ChbRecyclable_CheckChanged(object sender, RoutedEventArgs e)
        {
            CrlCustom.Recyclable = ChbRecyclable.IsChecked == true;
            UpdateCode();
        }

        private void ChbAutoPlay_CheckChanged(object sender, RoutedEventArgs e)
        {
            ChbRecyclable.IsChecked = true;
            CrlCustom.AutoPlayInterval = TimeSpan.FromSeconds(1);
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
        }

        private void UpdateCode()
        {
            var recyclable = CrlCustom.Recyclable;
            var autoPlay = CrlCustom.AutoPlayInterval;
            var index = CrlCustom.Index;

            TbCode.Text = $"<pu:Carousel  Width=\"{CrlCustom.ActualWidth}\"" +
                        $"\nHeight=\"{CrlCustom.ActualHeight}\"" +
                        (recyclable ? $"\nRecyclable=\"{recyclable}\"" : "") +
                        (autoPlay.TotalSeconds == 0 ? "" : $"\nAutoPlayInterval=\"0:0:{autoPlay.TotalSeconds}\"") +
                        $"\nIndex=\"{CrlCustom.Index}\"" +
                        " >" +
                        "\n<Grid Background=\"#F15D26\" />" +
                        "\n<Grid Background=\"#EED225\" />" +
                        "\n<Grid Background=\"#47BBC7\" />" +
                        "\n<Grid Background=\"#306ACF\" />" +
                        "\n</pu:Carousel>";
        }

        #endregion
    }
}
