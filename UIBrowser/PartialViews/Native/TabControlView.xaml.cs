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
    /// TabControlView.xaml 的交互逻辑
    /// </summary>
    public partial class TabControlView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public TabControlView()
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

        private void SldWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void ChbCanRemove_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            TabControlHelper.SetCanRemove(TabCustom, ChbCanRemove.IsChecked == true);

            UpdateTemplate();
            UpdateCode();
        }

        private void RdbBaseStyle_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;
            var rdb = sender as RadioButton;

            TabControlHelper.SetTabControlStyle(TabCustom, (TabControlStyle)Enum.Parse(typeof(TabControlStyle), rdb.Content.ToString()));

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

            TabCustom.Width = SldWidth.Value;

            switch (TabControlHelper.GetTabControlStyle(TabCustom))
            {
                case TabControlStyle.Standard:
                    TabControlHelper.SetSelectedForeground(TabCustom, color.ToBrush());
                    TabControlHelper.SetSelectedBackground(TabCustom, null);
                    break;
                case TabControlStyle.Classic:
                    TabCustom.Background = Brushes.Transparent;
                    TabControlHelper.SetSelectedForeground(TabCustom, color.ToBrush());
                    TabControlHelper.SetSelectedBackground(TabCustom, null);
                    break;
                case TabControlStyle.Card:

                    TabControlHelper.SetSelectedForeground(TabCustom, Brushes.White);
                    TabControlHelper.SetSelectedBackground(TabCustom, color.ToBrush());
                    break;
            }
        }

        private void UpdateCode()
        {
            var tabStyle = TabControlHelper.GetTabControlStyle(TabCustom);
            var canRemove = TabControlHelper.GetCanRemove(TabCustom);

            TbCode.Text = "<TabControl  Width=\"{TabCustom.Width}\"" +
                        (tabStyle == TabControlStyle.Standard ? "" : $"\npu:TabControlHelper.TabControlStyle=\"{tabStyle}\"") +
                        $"\npu:TabControlHelper.SelectedForeground=\"{TabControlHelper.GetSelectedForeground(TabCustom).ToColor().ToHexString(false)}\"" +
                        (tabStyle != TabControlStyle.Card ? "" : $"\npu:TabControlHelper.SelectedBackground=\"{TabControlHelper.GetSelectedBackground(TabCustom).ToColor().ToHexString(false)}\"") +
                        (tabStyle != TabControlStyle.Card ? "" : $"\nBackground=\"{TabCustom.Background.ToColor().ToHexString(false)}\"") +
                        (canRemove ? $"\npu:TabControlHelper.CanRemove=\"True\"" : "") +
                        " >" +
                        "\n<TabItem Header=\"Item1\"" +
                        (canRemove ? $"\npu:TabControlHelper.CanRemove=\"False\"" : "") +
                        "/>" +
                        "\n<TabItem Header=\"Item2\"/>" +
                        "\n<TabItem Header=\"Item3\"/>" +
                        "\n</TabControl>";
        }
        #endregion


    }
}
