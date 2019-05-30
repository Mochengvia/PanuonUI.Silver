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
using System.Windows.Shapes;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// MsgBox.xaml 的交互逻辑
    /// </summary>
    internal partial class MsgBox : Window
    {
        delegate void CancelDelegate(Action action);

        #region Identity
        private Action _cancelAction;
        private string _cancelContent;
        #endregion

        public enum MsgType
        {
            Message,
            Confirm,
        }

        public MsgBox(string content, string title, MsgType msgTyle = MsgType.Message, string cancelContent = null, Action cancelAction = null)
        {
            InitializeComponent();
            Title = title;
            TxtContent.Text = content;
            _cancelAction = cancelAction;
            _cancelContent = cancelContent;

            var culture = Thread.CurrentThread.CurrentCulture;

            switch (culture.IetfLanguageTag)
            {
                case "zh-CN":
                    BtnOK.Content = "好";
                    BtnYes.Content = "是";
                    BtnNo.Content = "否";
                    break;
            }
            switch (msgTyle)
            {
                case MsgType.Message:
                    GrdMessage.Visibility = Visibility.Visible;
                    break;
                case MsgType.Confirm:
                    GrdConfirm.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void BtnYes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


        private void MsgBox_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ExecuteAction(Action action)
        {
            action.Invoke();
        }
    }
}
