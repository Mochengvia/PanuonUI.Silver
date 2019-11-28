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
    public partial class TreeViewView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public TreeViewView()
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

        private void SliderItemHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
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

            TreeViewHelper.SetTreeViewStyle(TvCustom, (TreeViewStyle)Enum.Parse(typeof(TreeViewStyle), rdb.Content.ToString()));

            UpdateTemplate();
            UpdateCode();
        }

        private void ChbSelectMode_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            TreeViewHelper.SetSelectMode(TvCustom, ChbSelectMode.IsChecked == true ? SelectMode.ChildOnly : SelectMode.Any);

            UpdateCode();
        }

        private void ChbExpandMode_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            TreeViewHelper.SetExpandMode(TvCustom, ChbExpandMode.IsChecked == true ? ExpandMode.SingleClick : ExpandMode.DoubleClick);

            UpdateCode();
        }

        private void ChbExpandBehaviour_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            TreeViewHelper.SetExpandBehaviour(TvCustom, ChbExpandBehaviour.IsChecked == true ? ExpandBehaviour.OnlyOne : ExpandBehaviour.Any);

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

            TreeViewHelper.SetItemHeight(TvCustom, SldItemHeight.Value);


            if (TreeViewHelper.GetTreeViewStyle(TvCustom) == TreeViewStyle.Standard || TreeViewHelper.GetTreeViewStyle(TvCustom) == TreeViewStyle.Chain)
            {
                foreach (TreeViewItem item in TvCustom.Items)
                {
                    foreach (TreeViewItem itemx in item.Items)
                    {
                        itemx.Padding = new Thickness(0);
                    }
                }
            }
            else
            {
                foreach (TreeViewItem item in TvCustom.Items)
                {
                    foreach (TreeViewItem itemx in item.Items)
                    {
                        itemx.Padding = new Thickness(20, 0, 0, 0);
                    }
                }
            }

            switch (TreeViewHelper.GetTreeViewStyle(TvCustom))
            {
                case TreeViewStyle.Standard:
                    TreeViewHelper.SetSelectedForeground(TvCustom, color.ToBrush());
                    TreeViewHelper.SetSelectedBackground(TvCustom, null);
                    break;
                case TreeViewStyle.Classic:
                    TreeViewHelper.SetSelectedForeground(TvCustom, null);
                    TreeViewHelper.SetSelectedBackground(TvCustom, new Color() { A = 34, R = color.R, G = color.G, B = color.B }.ToBrush());
                    break;
                case TreeViewStyle.Modern:
                    TreeViewHelper.SetSelectedForeground(TvCustom, null);
                    TreeViewHelper.SetSelectedBackground(TvCustom, new Color() { A = 34, R = color.R, G = color.G, B = color.B }.ToBrush());
                    TvCustom.BorderBrush = color.ToBrush();
                    break;
                case TreeViewStyle.Chain:
                    TreeViewHelper.SetSelectedForeground(TvCustom, color.ToBrush());
                    TreeViewHelper.SetSelectedBackground(TvCustom, null);
                    break;
            }
        }

        private void UpdateCode()
        {
            var treeStyle = TreeViewHelper.GetTreeViewStyle(TvCustom);
            var selectMode = TreeViewHelper.GetSelectMode(TvCustom);
            var expandMode = TreeViewHelper.GetExpandMode(TvCustom);
            var expandBehaviour = TreeViewHelper.GetExpandBehaviour(TvCustom);
            var itemHeight = TreeViewHelper.GetItemHeight(TvCustom);

            TbCode.Text = $"<TreeView  Height=\"{TvCustom.Height}\"" +
                        $"\nWidth=\"{TvCustom.Width}\"" +
                        (treeStyle == TreeViewStyle.Standard ? "" : $"\npu:TreeViewHelper.TreeViewStyle=\"{treeStyle}\"") +
                        (selectMode == SelectMode.Any ? "" : $"\npu:TreeViewHelper.SelectMode=\"{selectMode}\"") +
                        (expandMode == ExpandMode.DoubleClick ? "" : $"\npu:TreeViewHelper.SelectMode=\"{expandMode}\"") +
                        (expandBehaviour == ExpandBehaviour.Any ? "" : $"\npu:TreeViewHelper.SelectMode=\"{expandBehaviour}\"") +
                        (itemHeight == 40 ? "" : $"\npu:TreeViewHelper.ItemHeight=\"{itemHeight}\"") +
                        ((treeStyle == TreeViewStyle.Standard || treeStyle == TreeViewStyle.Chain) ? "" : $"\npu:TreeViewHelper.SelectedBackground=\"{TreeViewHelper.GetSelectedBackground(TvCustom).ToColor().ToHexString()}\"") + 
                        ((treeStyle == TreeViewStyle.Standard || treeStyle == TreeViewStyle.Chain) ? $"\npu:TreeViewHelper.SelectedForeground=\"{TreeViewHelper.GetSelectedForeground(TvCustom).ToColor().ToHexString()}\"" : "") + 
                        " >" +
                        "\n<TreeViewItem Header=\"Item1\"/>" +
                        "\n<TreeViewItem Header=\"Item2\"/>" +
                        "\n<TreeViewItem Header=\"Item3\"/>" +
                        "\n</TreeView>";
        }


        #endregion


    }
}
