using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Panuon.UI.Silver.Browser.Views.Partial
{
    /// <summary>
    /// IntroductionView.xaml 的交互逻辑
    /// </summary>
    public partial class IntroductionView : UserControl
    {
        public IntroductionView()
        {
            InitializeComponent();
            if (LanguageInfo.Current == "zh-CN")
                CmbLanguage.SelectedIndex = 1;
            else
                CmbLanguage.SelectedIndex = 0;
        }

        private void CmbLanguage_Changed(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (CmbLanguage.SelectedItem as ComboBoxItem);
            var Ieft = selectedItem.Content.ToString() == "English" ? "en-US" : "zh-CN";
            if (Ieft == LanguageInfo.Current)
                return;

            var dictionary = new ResourceDictionary();
            if(Ieft == "zh-CN")
                dictionary.Source = new Uri("/Panuon.UI.Silver.Browser;component/Resources/zh-CN.xaml", UriKind.Relative);
            else
                dictionary.Source = new Uri("/Panuon.UI.Silver.Browser;component/Resources/en-US.xaml", UriKind.Relative);

            Application.Current.Resources.MergedDictionaries[0] = dictionary;

            MainWindow.Instance.ResetMenuItemNames();

            LanguageInfo.Current = Ieft;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Ieft);
        }
    }
}
