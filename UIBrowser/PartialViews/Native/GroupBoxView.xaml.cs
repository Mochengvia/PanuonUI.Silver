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
    /// GroupBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class GroupBoxView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public GroupBoxView()
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

            GroupBoxHelper.SetIcon(GrpCustom, ChbShowIcon.IsChecked == true ? "\uf11c" : null);

            UpdateTemplate();
            UpdateCode();
        }

        private void ChbShowSplitLine_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            GroupBoxHelper.SetIsSplitLineVisible(GrpCustom, ChbShowSplitLine.IsChecked == true);

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
            GroupBoxHelper.SetShadowColor(GrpCustom, ChbShowShadow.IsChecked == true ? Colors.LightGray : (Color?)null);
        }

        private void ChbExtendControl_CheckChanged(object sender, RoutedEventArgs e)
        {
            if(ChbExtendControl.IsChecked != true)
                GroupBoxHelper.SetExtendControl(GrpCustom, null);
            else
            {
                var button = new Button()
                {
                    Content = "details >",
                    Margin = new Thickness(0,0,5,0),
                    Foreground = "#AA57A2E0".ToColor().ToBrush()
                };
                ButtonHelper.SetButtonStyle(button, ButtonStyle.Link);
                ButtonHelper.SetHoverBrush(button, "#57A2E0".ToColor().ToBrush());
                GroupBoxHelper.SetExtendControl(GrpCustom, button);
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
                    AnimationHelper.SetSlideInFromBottom(GrpPalette, true);
                    RectBackground.Fill = FindResource("GridBrush") as Brush;
                    GroupBoxHelper.SetShadowColor(GrpPalette, Colors.LightGray);
                    GroupBoxHelper.SetShadowColor(GrpCode, Colors.LightGray);
                    break;
            }
        }
        private void UpdateTemplate()
        {
            if(GroupBoxHelper.GetIcon(GrpCustom) == null)
                GroupBoxHelper.SetHeaderPadding(GrpCustom, new Thickness(5, SldHeaderPadding.Value, 0, SldHeaderPadding.Value));
            else
                GroupBoxHelper.SetHeaderPadding(GrpCustom, new Thickness(0, SldHeaderPadding.Value, 0, SldHeaderPadding.Value));

            GroupBoxHelper.SetCornerRadius(GrpCustom, new CornerRadius(SldCornerRadius.Value));
        }

        private void UpdateCode()
        {
            var icon = GroupBoxHelper.GetIcon(GrpCustom);
            var cornerRadius = SldCornerRadius.Value;
            var headerPadding = SldHeaderPadding.Value;
            var splitLine = GroupBoxHelper.GetIsSplitLineVisible(GrpCustom);
            var shadow = GroupBoxHelper.GetShadowColor(GrpCustom);

            TbCode.Text = $"<GroupBox Width=\"{GrpCustom.Width}\"" +
                        $"\nHeader=\"{GrpCustom.Header}\"" +
                        $"\nVerticalAlignment=\"Center\"" +
                        $"\nHorizontalAlignment=\"Center\"" +
                        (icon == null ? "" : $"\npu:GroupBoxHelper.Icon=\"&#xf11c;\"") +
                        (cornerRadius == 0 ? "" : $"\npu:GroupBoxHelper.CornerRadius=\"{cornerRadius}\"") +
                        (headerPadding == 5 ? "" : $"\npu:GroupBoxHelper.HeaderPadding=\"{GroupBoxHelper.GetHeaderPadding(GrpCustom)}\"") +
                        (splitLine ? $"\npu:GroupBoxHelper.IsSplitLineVisible=\"True\"" : "") +
                        (shadow == null ? "" : $"\npu:GroupBoxHelper.ShadowColor=\"LightGray\"") +
                        " />";
        }






        #endregion


    }
}
