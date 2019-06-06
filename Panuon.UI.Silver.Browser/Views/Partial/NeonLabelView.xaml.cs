using Panuon.UI.Silver.Browser.Models;
using Panuon.UI.Silver.Browser.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Browser.Views.Partial
{
    /// <summary>
    /// ComboBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class NeonLabelView : UserControl
    {
        private DispatcherTimer _dispatcherTimer;
        private int count = 0;

        public NeonLabelView()
        {
            InitializeComponent();
            ViewModel = new SIMViewModel()
            {
                
            };
            DataContext = ViewModel;
            _dispatcherTimer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
            _dispatcherTimer.Start();

        }

        public SIMViewModel ViewModel { get; set; }

        private void BtnDocument_Click(object sender, RoutedEventArgs e)
        {
            Carousel.Index++;
        }

        private void BtnExample_Click(object sender, RoutedEventArgs e)
        {
            Carousel.Index--;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Brush brush = null;
            count++;
            switch (count)
            {
                case 1:
                    brush = FindResource("LightOrange") as Brush;
                    break;
                case 2:
                    brush = FindResource("LightGreen") as Brush;
                    break;
                case 3:
                    brush = FindResource("LightPink") as Brush;
                    break;
                case 4:
                    brush = FindResource("LightRed") as Brush;
                    break;
                case 5:
                    count = 0;
                    brush = FindResource("LightBlue") as Brush;
                    break;
            }
            neon.Next(NeonLabelType.FadeForeground, brush);
            neon1.Next(NeonLabelType.FadeBackground, brush);
            neon2.Next(NeonLabelType.FadeNext, Guid.NewGuid().ToString());
            neon3.Next(NeonLabelType.SlideNext, Guid.NewGuid().ToString());
            if (count == 1)
                neon4.Next(NeonLabelType.ScrollToEnd, null, 4);
        }

    }
}
