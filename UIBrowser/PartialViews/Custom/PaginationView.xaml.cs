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
    /// PaginationView.xaml 的交互逻辑
    /// </summary>
    public partial class PaginationView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public PaginationView()
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

            PgnCustom.PaginationStyle = (PaginationStyle)Enum.Parse(typeof(PaginationStyle), rdb.Content.ToString());

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

        private void SldCornerRadius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;
            PgnCustom.CornerRadius = new CornerRadius(SldCornerRadius.Value);
        }

        private void SldSpacing_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;
            PgnCustom.Spacing = SldSpacing.Value;
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
            PgnCustom.HoverBrush = color.ToBrush();

            switch (PgnCustom.PaginationStyle)
            {
                case PaginationStyle.Standard:
                    var backColor = new Color() { A = 150, R = color.R, G = color.G, B = color.B };
                    PgnCustom.Background = backColor.ToBrush();
                    break;
                default:
                    PgnCustom.Background = Brushes.Transparent;
                    break;
            }
        }

        private void UpdateCode()
        {
            var paginationStyle = PgnCustom.PaginationStyle;
            var spacing = PgnCustom.Spacing;
            var cornerRadius = PgnCustom.CornerRadius;
            var currentIndex = PgnCustom.CurrentIndex;
            var totalIndex = PgnCustom.TotalIndex;

            TbCode.Text = $"<pu:Pagination Height=\"{PgnCustom.ActualHeight}\"" +
                        (paginationStyle == PaginationStyle.Standard ? $"\nBackground=\"{PgnCustom.Background.ToColor().ToHexString()}\"" : "") +
                        $"\nHoverBrush=\"{PgnCustom.HoverBrush.ToColor().ToHexString()}\"" +
                        (cornerRadius.TopLeft == 2 ? "" : $"\nCornerRadius=\"{cornerRadius.TopLeft}\"") +
                        (spacing == 5 ? "" : $"\nSpacing=\"{spacing}\"") +
                        (currentIndex == 1 ? "" : $"\nCurrentIndex=\"{currentIndex}\"") +
                        (totalIndex == 1 ? "" : $"\nTotalIndex=\"{totalIndex}\"") +
                        " />";
        }




        #endregion


    }
}
