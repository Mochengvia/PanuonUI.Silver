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
    public partial class SliderView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public SliderView()
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

        private void RdbBaseStyle_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;
            var rdb = sender as RadioButton;

            SliderHelper.SetSliderStyle(SldCustom, (SliderStyle)Enum.Parse(typeof(SliderStyle), rdb.Content.ToString()));
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

        private void SldTrackThickness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void SldThumbSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
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

        private void ChbShowValue_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            SliderHelper.SetIsTickValueVisible(SldCustom, ChbShowValue.IsChecked == true);

            UpdateCode();
        }

        private void ChbShowTickBar_CheckChanged(object sender, RoutedEventArgs e)
        {

            if (!IsLoaded)
                return;

            SldCustom.TickPlacement = ChbShowTickBar.IsChecked == true ? System.Windows.Controls.Primitives.TickPlacement.Both : System.Windows.Controls.Primitives.TickPlacement.None;

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

            SliderHelper.SetTrackThickness(SldCustom, SldTrackThickness.Value);

            SliderHelper.SetThumbSize(SldCustom, SldThumbSize.Value);

            SliderHelper.SetThemeBrush(SldCustom, color.ToBrush());
            SldCustom.Background = new Color() { A = 30, R = color.R, G = color.G, B = color.B }.ToBrush();
        }

        private void UpdateCode()
        {
            var style = SliderHelper.GetSliderStyle(SldCustom);
            var thumbSize = SliderHelper.GetThumbSize(SldCustom);
            var trackThickness = SliderHelper.GetTrackThickness(SldCustom);
            var valueVisible = SliderHelper.GetIsTickValueVisible(SldCustom);
            var tickBarVisible = SldCustom.TickPlacement == System.Windows.Controls.Primitives.TickPlacement.Both;

            TbCode.Text = $"<Slider  Width=\"{SldCustom.Width}\"" +
                        (style == SliderStyle.Standard ? "" : $"\npu:SliderHelper.SliderStyle=\"{style}\"") +
                        (thumbSize == 18 ? "" : $"\npu:SliderHelper.ThumbSize=\"{thumbSize}\"") +
                        (trackThickness == 3 ? "" : $"\npu:SliderHelper.TrackThickness=\"{trackThickness}\"") +
                        $"\npu:SliderHelper.ThemeBrush=\"{SliderHelper.GetThemeBrush(SldCustom).ToColor().ToHexString(false)}\"" +
                        $"\nBackground=\"{SldCustom.Background.ToColor().ToHexString()}\"" +
                        (valueVisible ? "" : "\npu:SliderHelper.IsTickValueVisible=\"True\"") +
                        (tickBarVisible ? "\nTickPlacement=\"Both\"" : "") +

                        " />";
        }


        #endregion


    }
}
