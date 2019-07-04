using Caliburn.Micro;
using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIBrowser.Helpers;

namespace UIBrowser.PartialViews
{
    /// <summary>
    /// OverviewView.xaml 的交互逻辑
    /// </summary>
    public partial class OverviewView : UserControl
    {
        private LinearGradientBrush _linearGradientBrush;

        public OverviewView()
        {
            InitializeComponent();
            _linearGradientBrush = FindResource("ColorSelectorBrush") as LinearGradientBrush;

            ViewModel = new OverviewViewModel("#3E3E3E".ToColor());
            DataContext = ViewModel;
        }

        public OverviewViewModel ViewModel { get; set; }

        private void SliderTheme_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            var color = Helper.GetColorByOffset(_linearGradientBrush.GradientStops, SliderTheme.Value / 70);

            ViewModel.Update(color);

        }
    }

    public class OverviewViewModel : PropertyChangedBase
    {
        public OverviewViewModel(Color color)
        {
            Update(color);
        }

        public void Update(Color color)
        {
            Brush = color.ToBrush();
            LightBrush = new Color() { A = 200, R = color.R, G = color.G, B = color.B }.ToBrush();
            BrushTran1 = new Color() { A = 34, R = color.R, G = color.G, B = color.B }.ToBrush();
            BrushTran2 = new Color() { A = 51, R = color.R, G = color.G, B = color.B }.ToBrush();
        }

        public Brush Brush
        {
            get { return _brush; }
            set { _brush = value; NotifyOfPropertyChange(); }
        }
        private Brush _brush;


        public Brush LightBrush
        {
            get { return _lightBrush; }
            set { _lightBrush = value; NotifyOfPropertyChange(); }
        }
        private Brush _lightBrush;

        public Brush BrushTran1
        {
            get { return _brushTran1; }
            set { _brushTran1 = value; NotifyOfPropertyChange(); }
        }
        private Brush _brushTran1;


        public Brush BrushTran2
        {
            get { return _brushTran2; }
            set { _brushTran2 = value; NotifyOfPropertyChange(); }
        }
        private Brush _brushTran2;

    }
}
