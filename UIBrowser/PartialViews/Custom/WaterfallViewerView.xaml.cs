using Panuon.UI.Silver;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using UIBrowser.Helpers;

namespace UIBrowser.PartialViews.Custom
{
    /// <summary>
    /// WaterfallViewerView.xaml 的交互逻辑
    /// </summary>
    public partial class WaterfallViewerView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public WaterfallViewerView()
        {
            InitializeComponent();
            Loaded += ButtonView_Loaded;
            UpdateVisualEffect();
            _linearGradientBrush = FindResource("ColorSelectorBrush") as LinearGradientBrush;

            AppendItems(false);
        }

        #region Event

        private void ButtonView_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void ChbHorizontal_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            WfvCustom.Children.Clear();
            WfvCustom.Orientation = ChbHorizontal.IsChecked == true ? Orientation.Horizontal : Orientation.Vertical;
            AppendItems(false);

            UpdateCode();
        }

        private void ChbLazyLoading_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            WfvCustom.IsLazyLoadingEnabled = ChbLazyLoading.IsChecked == true;
            UpdateCode();
        }

        private void SldVerticalSpacing_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void SldHorizontalSpacing_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }


        private void SldGroups_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }


        private void WfvCustom_LazyLoading(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            AppendItems();
        }
        #endregion

        #region Function
        private async void AppendItems(bool wait = true)
        {
            if (wait)
                await Task.Delay(2000);

            var random = new Random(DateTime.Now.Millisecond);

            if (WfvCustom.Orientation == Orientation.Vertical)
            {
                for (int i = 0; i < 10; i++)
                {
                    WfvCustom.Children.Add(new Rectangle()
                    {
                        Fill = Brushes.LightSkyBlue,
                        Height = i % 2 == 0 ? 150 : 100,
                        RadiusX = 3,
                        RadiusY = 3,
                        Effect = FindResource("DropShadow") as Effect,
                    });
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    WfvCustom.Children.Add(new Rectangle()
                    {
                        Fill = Brushes.LightSkyBlue,
                        Width = i % 2 == 0 ? 150 : 100,
                        RadiusX = 3,
                        RadiusY = 3,
                        Effect = FindResource("DropShadow") as Effect,
                    });
                }
            }

        }

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
            WfvCustom.HorizontalSpacing = SldHorizontalSpacing.Value;
            WfvCustom.VerticalSpacing = SldVerticalSpacing.Value;
            WfvCustom.Groups = (int)SldGroups.Value;
        }

        private void UpdateCode()
        {
            var isLazyLoadingEnabled = WfvCustom.IsLazyLoadingEnabled;
            var groups = WfvCustom.Groups;
            var vertical = WfvCustom.VerticalSpacing;
            var horizontal = WfvCustom.HorizontalSpacing;

            TbCode.Text = $"<pu:WaterfallViewer  Width=\"{WfvCustom.ActualWidth}\"" +
                        $"\nHeight=\"{WfvCustom.ActualHeight}\"" +
                        (isLazyLoadingEnabled ? $"\nIsLazyLoadingEnabled=\"{isLazyLoadingEnabled}\"" : "") +
                        (isLazyLoadingEnabled ? $"\nLazyLoading=\"WaterfallViewer_LazyLoading\"" : "") +
                        (groups == 1 ? "" : $"\nGroups=\"{groups}\"") +
                        (vertical == 10 ? "" : $"\nVerticalSpacing=\"{vertical}\"") +
                        (horizontal == 10 ? "" : $"\nHorizontalSpacing=\"{horizontal}\"") +
                        " />";
        }





        #endregion

    }
}
