using Panuon.UI.Silver.Internal.Utils;
using Panuon.UI.Silver.Components;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver.Internal.Controls
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    internal partial class PendingWindow : Window
    {
        public PendingWindow(string message, string caption, bool canCancel, Window owner)
        {
            InitializeComponent();
            Owner = owner;
            if(Owner != null)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            PbcControl.Message = message;
            PbcControl.Caption = caption;
            PbcControl.CanCancel = canCancel;
        }

        #region Event Handlers
        private void PendingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PbcControl.IsLoading = true;
        }

        #endregion

        #region Methods
        internal void UpdateMessage(string message)
        {
            Dispatcher.Invoke(new Action(() =>
           {
               PbcControl.Message = message;
           }));
        }
        #endregion
    }
}
