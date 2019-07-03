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
    /// CheckBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class CheckBoxView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public CheckBoxView()
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

        private void SliderWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void RdbButtonStyle_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;
            var rdb = sender as RadioButton;

            CheckBoxHelper.SetCheckBoxStyle(ChbCustom, (CheckBoxStyle)Enum.Parse(typeof(CheckBoxStyle), rdb.Content.ToString()));
            UpdateTemplate();
            UpdateCode();
        }

        private void ChbChangeIfChecked_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            if (ChbChangeIfChecked.IsChecked == true)
                CheckBoxHelper.SetCheckedContent(ChbCustom, "Checked !");
            else
                CheckBoxHelper.SetCheckedContent(ChbCustom, null);

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
            CheckBoxHelper.SetCornerRadius(ChbCustom, SliderCornerRadius.Value);

           

            switch (CheckBoxHelper.GetCheckBoxStyle(ChbCustom))
            {
                case CheckBoxStyle.Standard:
                    ChbCustom.Background = new Color() { A = 50, R = color.R, G = color.G, B = color.B }.ToBrush();
                    CheckBoxHelper.SetCheckedBackground(ChbCustom, color.ToBrush());
                    CheckBoxHelper.SetBoxHeight(ChbCustom, SliderSize.Value);
                    CheckBoxHelper.SetBoxWidth(ChbCustom, SliderSize.Value);
                    break;
                case CheckBoxStyle.Switch:
                    ChbCustom.Background = Colors.White.ToBrush();
                    CheckBoxHelper.SetCheckedBackground(ChbCustom, color.ToBrush());
                    CheckBoxHelper.SetBoxHeight(ChbCustom, SliderSize.Value);
                    CheckBoxHelper.SetBoxWidth(ChbCustom, SliderSize.Value * 1.5);
                    break;
                case CheckBoxStyle.Button:
                    ChbCustom.Background = Colors.White.ToBrush();
                    CheckBoxHelper.SetCheckedBackground(ChbCustom, color.ToBrush());
                    break;
            }
        }

        private void UpdateCode()
        {
            var checkBoxStyle = CheckBoxHelper.GetCheckBoxStyle(ChbCustom);
            var cornerRadius = SliderCornerRadius.Value;
            var checkedContent = CheckBoxHelper.GetCheckedContent(ChbCustom);

            TbCode.Text = "<CheckBox  Height=\"30\"" +
                        $"\nContent=\"{ChbCustom.Content}\"" +
                        (checkBoxStyle == CheckBoxStyle.Standard ? "" : $"\npu:CheckBoxHelper.CheckBoxStyle=\"{checkBoxStyle}\"") +
                        (checkBoxStyle == CheckBoxStyle.Standard ? $"\nBackground=\"{ChbCustom.Background.ToColor().ToHexString(true)}\"" : "") +
                        (checkBoxStyle == CheckBoxStyle.Button ? "" : $"\npu:CheckBoxHelper.BoxHeight=\"{CheckBoxHelper.GetBoxHeight(ChbCustom)}\"") +
                        (checkBoxStyle == CheckBoxStyle.Button ? "" : $"\npu:CheckBoxHelper.BoxWidth=\"{CheckBoxHelper.GetBoxWidth(ChbCustom)}\"") +
                        $"\npu:CheckBoxHelper.CheckedBackground=\"{CheckBoxHelper.GetCheckedBackground(ChbCustom).ToColor().ToHexString(false)}\"" +
                        (cornerRadius == 2 ? "" : $"\npu:CheckBoxHelper.CornerRadius=\"{cornerRadius}\"") +
                        (checkedContent == null ? "" : $"\npu:CheckBoxHelper.CheckedContent=\"{checkedContent}\"") +
                        " />";
        }


        #endregion

       
    }
}
