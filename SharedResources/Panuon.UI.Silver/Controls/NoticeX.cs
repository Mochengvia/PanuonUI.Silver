using Panuon.UI.Silver.Internal.Controls;
using Panuon.UI.Silver.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Collections.Concurrent;

namespace Panuon.UI.Silver
{
    public static class NoticeX
    {
        #region Fields
        private static NoticeWindow _noticeWindow;

        private static Thread _thread;
        #endregion

        #region Properties
        public static NoticeXConfigurations Configurations { get; } = new NoticeXConfigurations();
        #endregion

        #region Methods

        public static void Show(string message, string caption, bool canClose = true)
        {
            CallNoticeWindow(message, caption, MessageBoxIcon.None, null, null, canClose);
        }

        public static void Show(string message, string caption, int? intervalMs, bool canClose = true)
        {
            CallNoticeWindow(message, caption, MessageBoxIcon.None, null, intervalMs, canClose);
        }

        public static void Show(string message, MessageBoxIcon icon, bool canClose = true)
        {
            CallNoticeWindow(message, null, icon, null, null, canClose);
        }

        public static void Show(string message, string caption, MessageBoxIcon icon, bool canClose = true)
        {
            CallNoticeWindow(message, caption, icon, null, null, canClose);
        }

        public static void Show(string message, MessageBoxIcon icon, int intervalMs, bool canClose = true)
        {
            CallNoticeWindow(message, null, icon, null, intervalMs, canClose);
        }

        public static void Show(string message, string caption, MessageBoxIcon icon, int intervalMs, bool canClose = true)
        {
            CallNoticeWindow(message, caption, icon, null, intervalMs, canClose);
        }

        public static void Show(string message, string caption, string imageSource, bool canClose = true)
        {
            CallNoticeWindow(message, caption, MessageBoxIcon.None, imageSource, null, canClose);
        }

        public static void Show(string message, string imageSource, int intervalMs, bool canClose = true)
        {
            CallNoticeWindow(message, null, MessageBoxIcon.None, imageSource, intervalMs, canClose);
        }

        public static void Show(string message, string caption, string imageSource, int intervalMs, bool canClose = true)
        {
            CallNoticeWindow(message, caption, MessageBoxIcon.None, imageSource, intervalMs, canClose);
        }

        #endregion

        #region Function
        private static void CallNoticeWindow(string message, string caption, MessageBoxIcon? icon, string imageSource, int? intervalMs, bool canClose)
        {
            if (_noticeWindow == null && _thread == null)
            {
                if (Configurations.InvokeOnNewThread)
                {
                    var autoReset = new AutoResetEvent(false);
                    _thread = new Thread(() =>
                    {
                        _noticeWindow = new NoticeWindow();
                        _noticeWindow.Closed += delegate
                        {
                            _noticeWindow.Dispatcher.InvokeShutdown();
                        };
                        _noticeWindow.Show();
                        _noticeWindow.AddCard(message, caption, icon, imageSource, intervalMs, canClose);
                        autoReset.Set();
                        Dispatcher.Run();
                    });
                    _thread.SetApartmentState(ApartmentState.STA);
                    _thread.IsBackground = true;
                    _thread.Start();
                    autoReset.WaitOne();
                }
                else
                {
                    _noticeWindow = new NoticeWindow();
                    _noticeWindow.Show();
                }
            }
            else
            {
                _noticeWindow.AddCard(message, caption, icon, imageSource, intervalMs, canClose);
            }
          
        }

        #endregion
    }
}
