using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;

namespace UIBrowser.Examples
{
    /// <summary>
    /// NeteaseMusicWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NeteaseMusicWindow : WindowX
    {
        public NeteaseMusicWindow()
        {
            InitializeComponent();
        }

        private void WfvMusics_ComputedSizeChanged(object sender, ComputedSizeChangedEventArgs e)
        {
            var s = e.Size;
        }
    }
}
