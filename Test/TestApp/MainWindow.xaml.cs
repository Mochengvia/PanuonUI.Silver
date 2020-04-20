using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TestApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        double value;
        public MainWindow()
        {
            InitializeComponent();
            value = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Set(true);
            if (value < 100)
            {
                value += 20;
                ProgressBarHelper.SetAnimateTo(Pgb1, value);
                ProgressBarHelper.SetAnimateTo(Pgb2, value);
                ProgressBarHelper.SetAnimateTo(Pgb3, value);
                ProgressBarHelper.SetAnimateTo(Pgb4, value);
            }
        }

        private void BtnDec_Click(object sender, RoutedEventArgs e)
        {
            Set(true);
            if (value >= 0)
            {
                value -= 20;
                ProgressBarHelper.SetAnimateTo(Pgb1, value);
                ProgressBarHelper.SetAnimateTo(Pgb2, value);
                ProgressBarHelper.SetAnimateTo(Pgb3, value);
                ProgressBarHelper.SetAnimateTo(Pgb4, value);
            }
        }

        private void BtnGO_Click(object sender, RoutedEventArgs e)
        {
            Set(false);
            if (value < 100)
            {
                value = 100;
                ProgressBarHelper.SetAnimateTo(Pgb1, value);
                ProgressBarHelper.SetAnimateTo(Pgb2, value);
                ProgressBarHelper.SetAnimateTo(Pgb3, value);
                ProgressBarHelper.SetAnimateTo(Pgb4, value);

            }
        }

        private void Set(bool reset)
        {
            if (reset)
            {
                ProgressBarHelper.SetAnimationEase(Pgb1, AnimationEase.CubicOut);
                ProgressBarHelper.SetAnimationEase(Pgb2, AnimationEase.CubicOut);
                ProgressBarHelper.SetAnimationEase(Pgb3, AnimationEase.CubicOut);
                ProgressBarHelper.SetAnimationEase(Pgb4, AnimationEase.CubicOut);
                ProgressBarHelper.SetAnimationDuration(Pgb1, TimeSpan.FromSeconds(0.5));
                ProgressBarHelper.SetAnimationDuration(Pgb2, TimeSpan.FromSeconds(0.5));
                ProgressBarHelper.SetAnimationDuration(Pgb3, TimeSpan.FromSeconds(0.5));
                ProgressBarHelper.SetAnimationDuration(Pgb4, TimeSpan.FromSeconds(0.5));

            }
            else
            {
                ProgressBarHelper.SetAnimationEase(Pgb1, AnimationEase.None);
                ProgressBarHelper.SetAnimationEase(Pgb2, AnimationEase.None);
                ProgressBarHelper.SetAnimationEase(Pgb3, AnimationEase.None);
                ProgressBarHelper.SetAnimationEase(Pgb4, AnimationEase.None);
                ProgressBarHelper.SetAnimationDuration(Pgb1, TimeSpan.FromSeconds(5));
                ProgressBarHelper.SetAnimationDuration(Pgb2, TimeSpan.FromSeconds(5));
                ProgressBarHelper.SetAnimationDuration(Pgb3, TimeSpan.FromSeconds(5));
                ProgressBarHelper.SetAnimationDuration(Pgb4, TimeSpan.FromSeconds(5));
            }
        }
    }
}
