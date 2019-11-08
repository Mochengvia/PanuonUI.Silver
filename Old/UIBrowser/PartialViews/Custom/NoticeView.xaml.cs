using Panuon.UI.Silver;
using System.Windows;
using System.Windows.Controls;

namespace UIBrowser.PartialViews.Custom
{
    /// <summary>
    /// NoticeView.xaml 的交互逻辑
    /// </summary>
    public partial class NoticeView : UserControl
    {
        #region Identity
        private string _message = "This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.";
        private string _message2 = "This is a test message.";
        #endregion

        public NoticeView()
        {
            InitializeComponent();
        }

        private void BtnNonIcon_Click(object sender, RoutedEventArgs e)
        {
            Notice.Show("This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.", "Notice", 3);
        }

        private void BtnError_Click(object sender, RoutedEventArgs e)
        {
            Notice.Show("This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.", "Notice", 3, MessageBoxIcon.Error);

        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            Notice.Show("This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.", "Notice", 3, MessageBoxIcon.Info);

        }

        private void BtnSuccess_Click(object sender, RoutedEventArgs e)
        {
            Notice.Show("This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.", "Notice", 3, MessageBoxIcon.Success);
        }

        private void BtnWarning_Click(object sender, RoutedEventArgs e)
        {
            Notice.Show("This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.", "Notice", 3, MessageBoxIcon.Warning);
        }
    }

}
