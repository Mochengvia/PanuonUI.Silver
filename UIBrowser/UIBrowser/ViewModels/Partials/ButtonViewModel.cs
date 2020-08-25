using Panuon.UI.Silver;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UIBrowser.Core;
using UIBrowser.Core.Properties;

namespace UIBrowser.ViewModels.Partials
{
    public class ButtonViewModel : ViewModelBase, IPaletteView
    {
        #region Properties
        public string Caption => Resources.Button;

        public string[] LabelLevels => new string[] { Resources.NativeControls };

        public IDictionary<string, DependencyProperty> PaletteProperties => new Dictionary<string, DependencyProperty>
        {
            { Resources.Foreground, Button.ForegroundProperty },
            { Resources.Background, Button.BackgroundProperty },
            { Resources.Width, Button.WidthProperty },
            { Resources.CornerRadius, ButtonHelper.CornerRadiusProperty },
        };

        public IList<DependencyProperty> GeneralProperties => new List<DependencyProperty>
        {
            Button.ForegroundProperty ,
            Button.BackgroundProperty ,
            Button.BorderBrushProperty ,
            Button.BorderThicknessProperty ,
            Button.WidthProperty ,
            Button.HeightProperty ,
            Button.ContentProperty ,
            ButtonHelper.CornerRadiusProperty ,
            ButtonHelper.HoverForegroundProperty ,
            ButtonHelper.HoverBackgroundProperty ,
            ButtonHelper.HoverBorderBrushProperty ,
            ButtonHelper.IconProperty ,
            ButtonHelper.IconPlacementProperty ,
            ButtonHelper.IsWaitingProperty,
        };
        #endregion

        public void Test()
        {
            NoticeX.Show("未预料的错误。", "Error", MessageBoxIcon.Error, 2000);
        }
    }
}
