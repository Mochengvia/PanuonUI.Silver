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
using System.Windows.Shapes;

namespace Panuon.UI.Silver.Controls.Internal
{
    /// <summary>
    /// NoticeWindow.xaml 的交互逻辑
    /// </summary>
    internal partial class NoticeWindow : Window
    {
        public NoticeWindow()
        {
            InitializeComponent();
            Instance = this;

            Closing += NoticeWindow_Closing;
        }

        
        #region Property
        public static NoticeWindow Instance { get; set; }
        #endregion

        #region EventHandler
        private void NoticeWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Instance = null;
        }
        #endregion

        #region Calling Method
        public void AddNotice()
        {

        }
        #endregion
    }
}
