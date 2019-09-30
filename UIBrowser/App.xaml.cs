using System.Globalization;
using System.Windows;

namespace UIBrowser
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }
    }
}
