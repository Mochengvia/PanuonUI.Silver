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

        internal static IDictionary<Window, MsgBox> InstanceDictionarty { get; set; }

        #region Identity
        private Action _cancelAction;

        private MsgType _msgType;
        #endregion

        public enum MsgType
        {
            Message,
            Confirm,
            Await,
        }

        public MsgBox(string content, string title, MsgType msgTyle = MsgType.Message, Window owner = null, bool showInTaskbar = true, bool autoCoverMask = false, bool topMost = true, Action cancelAction = null)
        {
            InitializeComponent();
            _msgType = msgTyle;
            Title = title;
            Topmost = topMost;
            ShowInTaskbar = showInTaskbar;
            if (owner != null)
            {
                if (autoCoverMask)
                    WindowHelper.SetOpenCoverMask(owner, true);
                msgBox.Owner = owner;
                msgBox.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }

            var culture = Thread.CurrentThread.CurrentCulture;

            switch (culture.IetfLanguageTag)
            {
                case "zh-CN":
                    BtnOK.Content = "好";
                    BtnYes.Content = "是";
                    BtnNo.Content = "否";
                    BtnCancel.Content = "取消";
                    break;
            }

            switch (msgTyle)
            {
                case MsgType.Message:
                    TxtContent.Text = content;
                    GrdMessage.Visibility = Visibility.Visible;
                    break;
                case MsgType.Confirm:
                    TxtContent.Text = content;
                    GrdConfirm.Visibility = Visibility.Visible;
                    break;
                case MsgType.Await:
                    if (InstanceDictionarty == null)
                        InstanceDictionarty = new Dictionary<Window, MsgBox>();
                    InstanceDictionarty.Add(owner, this);
                    WindowHelper.SetDisableCloseButton(this, true);
                    _cancelAction = cancelAction;
                    TxtCancelContent.Text = content;
                    StkCancel.Visibility = Visibility.Visible;
                    GrdCancel.Visibility = Visibility.Visible;
                    Loading.IsRunning = true;
                    if (cancelAction == null)
                    {
                        BtnCancel.IsEnabled = false;
                    }
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
            if (_msgType == MsgType.Await)
            {
                if (_cancelAction != null)
                    _cancelAction.Invoke();
                if (Owner != null)
                    WindowHelper.SetOpenCoverMask(Owner, false);
                if (InstanceDictionarty.ContainsKey(Owner))
                    InstanceDictionarty.Remove(Owner);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
