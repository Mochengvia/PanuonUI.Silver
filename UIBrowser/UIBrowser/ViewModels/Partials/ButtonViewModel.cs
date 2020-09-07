using Caliburn.Micro;
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

        #region Items
        public BindableCollection<string> Items { get => _items; set => Set(ref _items, value); }
        private BindableCollection<string> _items;
        #endregion 

        #endregion

        public ButtonViewModel()
        {
            Items = new BindableCollection<string>();
            for(int i =0;i < 60; i++)
            {
                Items.Add(i.ToString());
            }
        }
        public void Test()
        {
            NoticeX.Show("未预料的错误。", "Error", MessageBoxIcon.Error, 2000);
        }
    }
}
