using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class DataGridView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;

        #endregion

        public DataGridView()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += ButtonView_Loaded;
            UpdateVisualEffect();
            _linearGradientBrush = FindResource("ColorSelectorBrush") as LinearGradientBrush;
            TestDataList = new List<DataGridTestModel>()
            {
                new DataGridTestModel(){ Name = "Chris", IsEnabled = true, Score = 98, Sex = DataGridTestEnum.Girl  },
                new DataGridTestModel(){ Name = "Judy", Score = 100, Sex = DataGridTestEnum.Girl  },
                new DataGridTestModel(){ Name = "Jack", IsEnabled = true, Score = 100,  },
                new DataGridTestModel(){ Name = "Mario", IsEnabled = true, Score = 100,  },
                new DataGridTestModel(){ Name = "Chris", IsEnabled = true, Score = 98,  Sex = DataGridTestEnum.Girl },
                new DataGridTestModel(){ Name = "Judy", Score = 100, Sex = DataGridTestEnum.Girl  },
                new DataGridTestModel(){ Name = "Jack", IsEnabled = true, Score = 100,  },
                new DataGridTestModel(){ Name = "Mario", IsEnabled = true, Score = 100,  },
                new DataGridTestModel(){ Name = "Chris", IsEnabled = true, Score = 98,  Sex = DataGridTestEnum.Girl },
                new DataGridTestModel(){ Name = "Judy", Score = 100, Sex = DataGridTestEnum.Girl  },
                new DataGridTestModel(){ Name = "Jack", IsEnabled = true, Score = 100,  },
                new DataGridTestModel(){ Name = "Mario", IsEnabled = true, Score = 100,  },
            };
        }

        #region Property
        public IList<DataGridTestModel> TestDataList { get; set; }
        #endregion

        #region Event

        private void ButtonView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTemplate();
            UpdateCode();

           
        }

        private void SldHeaderMinHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            DataGridHelper.SetHeaderMinHeight(DgCustom, SldHeaderMinHeight.Value);

            UpdateCode();
        }

        private void SldRowMinHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            DataGridHelper.SetRowMinHeight(DgCustom, SldRowMinHeight.Value);
            UpdateCode();
        }

        private void ChbCenterColumn_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            DataGridHelper.SetColumnHorizontalContentAlignment(DgCustom, ChbCenterColumn.IsChecked == true ? HorizontalAlignment.Center : HorizontalAlignment.Stretch);
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

            DataGridHelper.SetHoverBackground(DgCustom, new Color() { A = 34, R = color.R, G = color.G, B = color.B }.ToBrush());
            DataGridHelper.SetSelectedBackground(DgCustom, new Color() { A = 68, R = color.R, G = color.G, B = color.B }.ToBrush());
        }

        private void UpdateCode()
        {
            var headerMinHeight = DataGridHelper.GetHeaderMinHeight(DgCustom);
            var rowMinHeight = DataGridHelper.GetRowMinHeight(DgCustom);


            TbCode.Text = $"<DataGrid  Width=\"{DgCustom.ActualWidth}\"" +
                        $"\nHeight=\"{DgCustom.ActualHeight}\"" +
                        (headerMinHeight == 40 ? "" : $"\npu:DataGridHelper.HeaderMinHeight=\"{headerMinHeight}\"") +
                        (rowMinHeight == 35 ? "" : $"\npu:DataGridHelper.RowMinHeight=\"{rowMinHeight}\"") +
                        (ChbCenterColumn.IsChecked == true ? $"\npu:DataGridHelper.ColumnHorizontalContentAlignment=\"Center\"" : "") +
                        $"\npu:DataGridHelper.SelectedBackground=\"{DataGridHelper.GetSelectedBackground(DgCustom).ToColor().ToHexString()}\"" +
                        $"\npu:DataGridHelper.HoverBackground=\"{DataGridHelper.GetHoverBackground(DgCustom).ToColor().ToHexString()}\"" +
                        $"\nCanUserAddRows=\"False\"" +
                        " >" +
                        "\n<pu:DataGridHelper.AutoGenerateCheckBoxStyle>" +
                            "\n<Style TargetType=\"CheckBox\"" +
                                   "\nBasedOn=\"{StaticResource {x:Type CheckBox}}\">" +
                                "\n<Setter Property=\"pu:CheckBoxHelper.CheckBoxStyle\"" +
                                        "\nValue=\"Switch\" />" +
                                "\n<Style.Triggers>" +
                                    "\n<DataTrigger Binding=\"{Binding Path=(pu:CheckBoxHelper.CheckBoxStyle),RelativeSource={RelativeSource Self}}\"" +
                                                 "\nValue=\"Switch\">" +
                                        "\n<Setter Property=\"pu:CheckBoxHelper.CheckedBackground\"" +
                                                "\nValue=\"#72C81F\" />" +
                                    "\n</DataTrigger> " +
                                "\n</Style.Triggers> " +
                            "\n</Style> " +
                        "\n</pu:DataGridHelper.AutoGenerateCheckBoxStyle>" +
                        "\n</DataGrid>";
        }
        #endregion
    }

    public class DataGridTestModel
    {
        [DisplayName("Name (Read Only) ")]
        [ReadOnlyColumn]
        [ColumnWidth("*")]
        public string Name { get; set; }

        [DisplayName("Score")]
        public int Score { get; set; }

        [DisplayName("IsEnabled")]
        public bool IsEnabled { get; set; }

        [DisplayName("Sex")]
        [ColumnWidth("0.5*")]
        public DataGridTestEnum Sex { get; set; }

        [IgnoreColumn]
        public object CustomData { get; set; }

    }

    public enum DataGridTestEnum
    {
        Boy,
        Girl,
    }

}
