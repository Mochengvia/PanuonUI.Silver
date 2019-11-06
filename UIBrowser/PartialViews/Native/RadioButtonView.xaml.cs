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
    /// RadioButtonView.xaml 的交互逻辑
    /// </summary>
    public partial class RadioButtonView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public RadioButtonView()
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

        private void SldWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void RdbBaseStyle_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;
            var rdb = sender as RadioButton;

            RadioButtonHelper.SetRadioButtonStyle(RdbCustom1, (RadioButtonStyle)Enum.Parse(typeof(RadioButtonStyle), rdb.Content.ToString()));
            RadioButtonHelper.SetRadioButtonStyle(RdbCustom2, (RadioButtonStyle)Enum.Parse(typeof(RadioButtonStyle), rdb.Content.ToString()));
            UpdateTemplate();
            UpdateCode();
        }

        private void ChbChangeIfChecked_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            if (ChbChangeIfChecked.IsChecked == true)
            {
                RadioButtonHelper.SetCheckedContent(RdbCustom1, "Checked !");
                RadioButtonHelper.SetCheckedContent(RdbCustom2, "Checked !");
            }
            else
            {
                RadioButtonHelper.SetCheckedContent(RdbCustom1, null);
                RadioButtonHelper.SetCheckedContent(RdbCustom2, null);
            }

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
            RadioButtonHelper.SetCornerRadius(RdbCustom1, new CornerRadius(SldCornerRadius.Value));
            RadioButtonHelper.SetCornerRadius(RdbCustom2, new CornerRadius(SldCornerRadius.Value));



            switch (RadioButtonHelper.GetRadioButtonStyle(RdbCustom1))
            {
                case RadioButtonStyle.Standard:
                    RdbCustom1.Background = new Color() { A = 50, R = color.R, G = color.G, B = color.B }.ToBrush();
                    RdbCustom2.Background = new Color() { A = 50, R = color.R, G = color.G, B = color.B }.ToBrush();
                    RadioButtonHelper.SetCheckedGlyphBrush(RdbCustom1, Colors.White.ToBrush());
                    RadioButtonHelper.SetCheckedGlyphBrush(RdbCustom2, Colors.White.ToBrush());
                    RadioButtonHelper.SetCheckedBackground(RdbCustom1, color.ToBrush());
                    RadioButtonHelper.SetCheckedBackground(RdbCustom2, color.ToBrush());
                    RadioButtonHelper.SetBoxHeight(RdbCustom1, SldSize.Value);
                    RadioButtonHelper.SetBoxHeight(RdbCustom2, SldSize.Value);
                    RadioButtonHelper.SetBoxWidth(RdbCustom1, SldSize.Value);
                    RadioButtonHelper.SetBoxWidth(RdbCustom2, SldSize.Value);
                    break;
                case RadioButtonStyle.Switch:
                    RdbCustom1.Background = Colors.White.ToBrush();
                    RdbCustom2.Background = Colors.White.ToBrush();
                    RadioButtonHelper.SetCheckedGlyphBrush(RdbCustom1, Colors.Transparent.ToBrush());
                    RadioButtonHelper.SetCheckedGlyphBrush(RdbCustom2, Colors.Transparent.ToBrush());
                    RadioButtonHelper.SetCheckedBackground(RdbCustom1, color.ToBrush());
                    RadioButtonHelper.SetCheckedBackground(RdbCustom2, color.ToBrush());
                    RadioButtonHelper.SetBoxHeight(RdbCustom1, SldSize.Value);
                    RadioButtonHelper.SetBoxHeight(RdbCustom2, SldSize.Value);
                    RadioButtonHelper.SetBoxWidth(RdbCustom1, SldSize.Value * 1.5);
                    RadioButtonHelper.SetBoxWidth(RdbCustom2, SldSize.Value * 1.5);
                    break;
                case RadioButtonStyle.Switch2:
                    RdbCustom1.Background = Colors.White.ToBrush();
                    RdbCustom2.Background = Colors.White.ToBrush();
                    RadioButtonHelper.SetCheckedGlyphBrush(RdbCustom1, Colors.Transparent.ToBrush());
                    RadioButtonHelper.SetCheckedGlyphBrush(RdbCustom2, Colors.Transparent.ToBrush());
                    RadioButtonHelper.SetCheckedBackground(RdbCustom1, color.ToBrush());
                    RadioButtonHelper.SetCheckedBackground(RdbCustom2, color.ToBrush());
                    RadioButtonHelper.SetBoxHeight(RdbCustom1, SldSize.Value);
                    RadioButtonHelper.SetBoxHeight(RdbCustom2, SldSize.Value);
                    RadioButtonHelper.SetBoxWidth(RdbCustom1, SldSize.Value * 2);
                    RadioButtonHelper.SetBoxWidth(RdbCustom2, SldSize.Value * 2);
                    break;
                case RadioButtonStyle.Button:
                    RdbCustom1.Background = Colors.White.ToBrush();
                    RdbCustom2.Background = Colors.White.ToBrush();
                    RadioButtonHelper.SetCheckedGlyphBrush(RdbCustom1, Colors.White.ToBrush());
                    RadioButtonHelper.SetCheckedGlyphBrush(RdbCustom2, Colors.White.ToBrush());
                    RadioButtonHelper.SetCheckedBackground(RdbCustom1, color.ToBrush());
                    RadioButtonHelper.SetCheckedBackground(RdbCustom2, color.ToBrush());
                    break;
            }
        }

        private void UpdateCode()
        {
            var radioButtonStyle = RadioButtonHelper.GetRadioButtonStyle(RdbCustom1);
            var cornerRadius = SldCornerRadius.Value;
            var checkedContent = RadioButtonHelper.GetCheckedContent(RdbCustom1);

            TbCode.Text = "<RadioButton  Height=\"30\"" +
                        $"\nContent=\"{RdbCustom1.Content}\"" +
                        (radioButtonStyle == RadioButtonStyle.Standard ? "" : $"\npu:RadioButtonHelper.RadioButtonStyle=\"{radioButtonStyle}\"") +
                        (radioButtonStyle == RadioButtonStyle.Standard ? $"\nBackground=\"{RdbCustom1.Background.ToColor().ToHexString(true)}\"" : "") +
                        (radioButtonStyle == RadioButtonStyle.Button ? "" : $"\npu:RadioButtonHelper.BoxHeight=\"{RadioButtonHelper.GetBoxHeight(RdbCustom1)}\"") +
                        (radioButtonStyle == RadioButtonStyle.Button ? "" : $"\npu:RadioButtonHelper.BoxWidth=\"{RadioButtonHelper.GetBoxWidth(RdbCustom1)}\"") +
                        $"\npu:RadioButtonHelper.CheckedBackground=\"{RadioButtonHelper.GetCheckedBackground(RdbCustom1).ToColor().ToHexString(false)}\"" +
                        (cornerRadius == 2 ? "" : $"\npu:RadioButtonHelper.CornerRadius=\"{cornerRadius}\"") +
                        (checkedContent == null ? "" : $"\npu:RadioButtonHelper.CheckedContent=\"{checkedContent}\"") +
                        " />";
        }


        #endregion


    }
}
