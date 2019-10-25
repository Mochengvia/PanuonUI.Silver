using Panuon.UI.Silver;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using UIBrowser.Helpers;

namespace UIBrowser.PartialViews.Custom
{
    /// <summary>
    /// DropDownView.xaml 的交互逻辑
    /// </summary>
    public partial class DropDownView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public DropDownView()
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
        }

        private void UpdateCode()
        {
            TbCode.Text = "<pu:DropDown HorizontalAlignment=\"Left\"" +
                          "\nVerticalAlignment=\"Top\"> " +
                          "\n<Grid Width=\"40\">" +
                          "\n<Ellipse Height=\"40\"" +
                          "\nWidth=\"40\"" +
                          "\n HorizontalAlignment=\"Center\"" +
                          "\nStroke=\"LightGray\"" +
                          "\nStrokeThickness=\"1\"" +
                          "\npu:LayoutHelper.ColumnDefinition=\"0.5*\">" +
                          "\n<Ellipse.Fill>" +
                          "\n<ImageBrush RenderOptions.BitmapScalingMode=\"HighQuality\"" +
                          "\nImageSource=\"/UIBrowser;component/Resources/head.jpg\" />" +
                          "\n</Ellipse.Fill>" +
                          "\n</Ellipse>" +
                          "\n</Grid>" +
                          "\n<pu:DropDown.Child>" +
                          "\n<Grid Height=\"170\"" +
                          "\nWidth =\"200\">" +
                          "\n<Grid.RowDefinitions>" +
                          "\n<RowDefinition Height=\"55\" />" +
                          "\n<RowDefinition />" +
                          "\n<RowDefinition />" +
                          "\n<RowDefinition />" +
                          "\n</Grid.RowDefinitions>" +
                          "\n<Grid Margin=\"15,0\">" +
                          "\n<Ellipse Height=\"35\"" +
                          "\nWidth=\"35\"" +
                          "\nStroke=\"LightGray\"" +
                          "\nVerticalAlignment=\"Center\"" +
                          "\nStrokeThickness=\"1\"" +
                          "\nHorizontalAlignment=\"Left\"" +
                          "\npu:LayoutHelper.ColumnDefinition=\"0.5*\">" +
                          "\n<Ellipse.Fill>" +
                          "\n<ImageBrush RenderOptions.BitmapScalingMode=\"HighQuality\"" +
                          "\nImageSource=\"/UIBrowser;component/Resources/head.jpg\" />" +
                          "\n</Ellipse.Fill>" +
                          "\n</Ellipse>" +
                          "\n<TextBlock Margin=\"0,0,0,0\"" +
                          "\nText=\"Zeoun\"" +
                          "\nForeground=\"Gray\"" +
                          "\nFontSize=\"15\"" +
                          "\nVerticalAlignment=\"Center\"" +
                          "\nHorizontalAlignment=\"Right\" />" +
                          "\n</Grid>" +
                          "\n<Border VerticalAlignment=\"Bottom\"" +
                          "\nBorderBrush =\"#EEEEEE\"" +
                          "\nBorderThickness=\"0,0,0,1\" />" +
                          "\n<Grid Grid.Row=\"1\"" +
                          "\nMargin=\"15,0\">" +
                          "\n<TextBlock VerticalAlignment=\"Center\"" +
                          "\nForeground=\"Gray\"" +
                          "\nText=\"Enabled\" />" +
                          "\n<CheckBox pu:CheckBoxHelper.CheckBoxStyle=\"Switch\"" +
                          "\npu:CheckBoxHelper.CheckedBackground=\"#74C178\"" +
                          "\npu:CheckBoxHelper.CornerRadius=\"2\"" +
                          "\npu:CheckBoxHelper.BoxHeight=\"25\"" +
                          "\npu:CheckBoxHelper.BoxWidth=\"35\"" +
                          "\nForeground =\"Gray\"" +
                          "\nVerticalAlignment=\"Center\"" +
                          "\nIsChecked=\"True\"" +
                          "\nFontFamily=\"/Panuon.UI.Silver;component/Resources/#fontawesome\"" +
                          "\nHorizontalAlignment =\"Right\" />" +
                          "\n</Grid>" +
                          "\n<Border Grid.Row=\"1\"" +
                          "\nVerticalAlignment=\"Bottom\"" +
                          "\nBorderBrush=\"#EEEEEE\"" +
                          "\nBorderThickness=\"0,0,0,1\" />" +
                          "\n<Grid Grid.Row=\"2\"" +
                          "\nMargin=\"15,0\">" +
                          "\n<TextBlock VerticalAlignment=\"Center\"" +
                          "\nForeground=\"Gray\"" +
                          "\nText=\"Notifycation\" />" +
                          "\n<CheckBox pu:CheckBoxHelper.CheckBoxStyle=\"Switch\"" +
                          "\n pu:CheckBoxHelper.CheckedBackground=\"#74C178\"" +
                          "\npu:CheckBoxHelper.CornerRadius=\"2\"" +
                          "\npu:CheckBoxHelper.BoxHeight=\"25\"" +
                          "\npu:CheckBoxHelper.BoxWidth=\"35\"" +
                          "\nForeground=\"Gray\"" +
                          "\nVerticalAlignment=\"Center\"" +
                          "\nFontFamily=\"/Panuon.UI.Silver;component/Resources/#fontawesome\"" +
                          "\nHorizontalAlignment=\"Right\" />" +
                          "\n</Grid>" +
                          "\n<Border Grid.Row=\"2\"" +
                          "\nVerticalAlignment=\"Bottom\"" +
                          "\nBorderBrush=\"#EEEEEE\"" +
                          "\nBorderThickness=\"0,0,0,1\" />" +
                          "\n<Grid Grid.Row=\"3\">" +
                          "\n<Button pu:ButtonHelper.ButtonStyle=\"Link\"" +
                          "\nHeight=\"30\"" +
                          "\nVerticalAlignment=\"Center\"" +
                          "\nFontFamily=\"/Panuon.UI.Silver;component/Resources/#fontawesome\"" +
                          "\nContent=\"&#xf08b; Sign out\" />" +
                          "\n</Grid>" +
                          "\n</Grid>" +
                          "\n</pu:DropDown.Child>" +
                          "\n</pu:DropDown>";


        }




        #endregion

    }
}
