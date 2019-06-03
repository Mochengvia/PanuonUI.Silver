using Panuon.UI.Silver.Browser.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Panuon.UI.Silver;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Browser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }

        #region Property
        public MainViewModel ViewModel { get; set; }
        #endregion

        #region Event
        private void BtnNormal_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            ButtonHelper.SetIsWaiting(Btn1, false);
            ButtonHelper.SetIsWaiting(Btn2, false);
            ButtonHelper.SetIsWaiting(Btn3, false);
            ButtonHelper.SetIsWaiting(Btn4, false);

            switch (button.Name)
            {
                case "Btn1":
                    ButtonHelper.SetIsWaiting(Btn1, true);
                    break;
                case "Btn2":
                    ButtonHelper.SetIsWaiting(Btn2, true);
                    break;
                case "Btn3":
                    ButtonHelper.SetIsWaiting(Btn3, true);
                    break;
                case "Btn4":
                    ButtonHelper.SetIsWaiting(Btn4, true);
                    break;
            }
        }

        private double _value = 60;
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            _value += 20;
            _value = _value > 100 ? 100 : _value;

            ProgressBarHelper.SetAnimateTo(Pgb1, _value);
            ProgressBarHelper.SetAnimateTo(Pgb2, _value);
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            _value -= 20;
            _value = _value < 0 ? 0 : _value;

            ProgressBarHelper.SetAnimateTo(Pgb1, _value);
            ProgressBarHelper.SetAnimateTo(Pgb2, _value);
        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            Carousel.Index--;
        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            Carousel.Index++;
        }

        private void BtnHelp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnShowPopup_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.ShowPopup(this, "This is a popup message");
        }

        private void BtnShowMessage_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.ShowMessage("Hi !", "Tips", this);
        }

        private void BtnShowConfirm_Click(object sender, RoutedEventArgs e)
        {
            var result = WindowHelper.ShowConfirm("Are you sure ?", "Tips", this);
        }

        private void BtnShowWaiting_Click(object sender, RoutedEventArgs e)
        {
            //close after 2 seconds
            var timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(2) };
            timer.Tick += delegate
            {
                WindowHelper.CloseWaiting();
            };
            timer.Start();

            //show waiting
            WindowHelper.ShowWaiting(this, "please wait ...", "Processing", () =>
            {
                WindowHelper.ShowPopup(this, "Task canceled !");
            });
        }

        #endregion
    }
}
