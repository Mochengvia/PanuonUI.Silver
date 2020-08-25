using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Controls;
using System;
using System.Threading;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public static class NoticeX
    {
        #region Fields
        private static NoticeXWindow _noticeWindow;

        private static Thread _thread;
        #endregion

        #region Properties
        public static NoticeXSettings Settings { get; } = new NoticeXSettings();
        #endregion

        #region Methods

        public static void Show(string message, bool canClose = true)
        {
            CallNoticeXWindow(message, null, null, null, null, canClose);
        }

        public static void Show(string message, string caption, bool canClose = true)
        {
            CallNoticeXWindow(message, caption, null, null, null, canClose);
        }

        public static void Show(string message, string caption, int? intervalMs, bool canClose = true)
        {
            CallNoticeXWindow(message, caption, null, null, intervalMs, canClose);
        }

        public static void Show(string message, MessageBoxIcon icon, bool canClose = true)
        {
            CallNoticeXWindow(message, null, icon, null, null, canClose);
        }

        public static void Show(string message, string caption, MessageBoxIcon icon, bool canClose = true)
        {
            CallNoticeXWindow(message, caption, icon, null, null, canClose);
        }

        public static void Show(string message, MessageBoxIcon icon, int intervalMs, bool canClose = true)
        {
            CallNoticeXWindow(message, null, icon, null, intervalMs, canClose);
        }

        public static void Show(string message, string caption, MessageBoxIcon icon, int intervalMs, bool canClose = true)
        {
            CallNoticeXWindow(message, caption, icon, null, intervalMs, canClose);
        }

        public static void Show(string message, string caption, string imageSource, bool canClose = true)
        {
            CallNoticeXWindow(message, caption, null, imageSource, null, canClose);
        }

        public static void Show(string message, string imageSource, int intervalMs, bool canClose = true)
        {
            CallNoticeXWindow(message, null, null, imageSource, intervalMs, canClose);
        }

        public static void Show(string message, string caption, string imageSource, int intervalMs, bool canClose = true)
        {
            CallNoticeXWindow(message, caption, null, imageSource, intervalMs, canClose);
        }

        public static void Dispose()
        {
            if (_noticeWindow != null)
            {
                _noticeWindow.Dispatcher.Invoke(new Action(() =>
                {
                    _noticeWindow.Close();
                }));
            }
        }
        #endregion

        #region Function
        private static void CallNoticeXWindow(string message, string caption, MessageBoxIcon? icon, string imageSource, int? intervalMs, bool canClose)
        {
            if (_noticeWindow == null && _thread == null)
            {
                if (Settings.CreateOnNewThread)
                {
                    var autoReset = new AutoResetEvent(false);
                    _thread = new Thread(() =>
                    {
                        _noticeWindow = new NoticeXWindow();
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
                    _noticeWindow = new NoticeXWindow();
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
