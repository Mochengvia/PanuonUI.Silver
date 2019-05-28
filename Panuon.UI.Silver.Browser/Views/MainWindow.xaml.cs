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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarHelper.SetAnimateTo(Pgb1, Pgb1.Value + 10);
            ProgressBarHelper.SetAnimateTo(Pgb2, Pgb2.Value + 10);
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarHelper.SetAnimateTo(Pgb1, Pgb1.Value - 10);
            ProgressBarHelper.SetAnimateTo(Pgb2, Pgb2.Value - 10);
        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            Carousel.Index--;
        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            Carousel.Index++;
        }

        #endregion

    }
}
