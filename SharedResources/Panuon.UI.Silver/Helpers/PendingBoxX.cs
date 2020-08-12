using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Controls;
using Panuon.UI.Silver.Internal.Implements;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public static class PendingBoxX
    {
        #region Methods

        public static IPendingHandler Show(string message)
        {
            return CallPendingBox(message, null, false, null);
        }

        public static IPendingHandler Show(Window owner ,string message)
        {
            return CallPendingBox(message, null, false, owner);

        }

        public static IPendingHandler Show(string message, bool canCancel)
        {
            return CallPendingBox(message, null, canCancel, null);
        }

        public static IPendingHandler Show(Window owner, string message, bool canCancel)
        {
            return CallPendingBox(message, null, canCancel, owner);
        }

        public static IPendingHandler Show(string message, string caption)
        {
            return CallPendingBox(message, caption, false, null);
        }

        public static IPendingHandler Show(Window owner, string message, string caption)
        {
            return CallPendingBox(message, caption, false, owner);
        }

        public static IPendingHandler Show(string message, string caption, bool canCancel)
        {
            return CallPendingBox(message, caption, canCancel, null);
        }

        public static IPendingHandler Show(Window owner, string message, string caption, bool canCancel)
        {
            return CallPendingBox(message, caption, canCancel, owner);
        }
        #endregion

        #region Properties
        public static PendingBoxXSettings Settings { get; } = new PendingBoxXSettings();
        #endregion

        #region Function
        private static IPendingHandler CallPendingBox(string message, string caption, bool canCancel, Window owner)
        {
            var handler = new PendingHanlderImpl();
            var interact = Settings.InteractOwnerMask;
            var content = Settings.CancelButtonContent;
            InteractOwnerMask(owner, interact, true);
            if (Settings.CreateOnNewThread)
            {
                PendingBoxXWindow pendingWindow = null;
                var autoReset = new AutoResetEvent(false);
                var ownerRect = GetOwnerRect(owner);

                var threadStart = new ThreadStart(() =>
                {
                    pendingWindow = new PendingBoxXWindow(message, caption, canCancel, ownerRect, Settings);
                    handler.SetWindow(pendingWindow);
                    pendingWindow.OnCancel += (s, e) =>
                    {
                        handler.RaiseCancellingEvent(s, e);
                    };
                    pendingWindow.Closed += delegate
                    {
                        pendingWindow.Dispatcher.InvokeShutdown();
                    };
                    pendingWindow.Show();
                    autoReset.Set();
                    Dispatcher.Run();
                });
                threadStart += () =>
                {
                    InteractOwnerMask(owner, interact, false);
                    handler.RaiseClosedEvent();
                };
                var thread = new Thread(threadStart);
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true; 
                thread.Start();
                autoReset.WaitOne();
            }
            else
            {
                var pendingWindow = new PendingBoxXWindow(message, caption, canCancel, owner, Settings);
                pendingWindow.OnCancel += (s, e) =>
                {
                    handler.RaiseCancellingEvent(s, e);
                };
                pendingWindow.Closed += delegate
                {
                    handler.RaiseClosedEvent();
                    InteractOwnerMask(owner, interact, false);
                };
                pendingWindow.Show();
                handler.SetWindow(pendingWindow);
            }
            return handler;
        }

        private static Rect GetOwnerRect(Window owner)
        {
            var rect = new Rect();
            if (owner != null)
            {
                owner.Dispatcher.Invoke(new Action(() =>
                {
                    var handle = new WindowInteropHelper(owner).Handle;
                    rect = WindowUtils.GetWindowRect(handle);
                }));
            }
            return rect;
        }

        private static void InteractOwnerMask(Window owner, bool interact, bool toOpen)
        {
            if (owner == null || !interact || !(owner is WindowX))
            {
                return;
            }
            owner.Dispatcher.Invoke(new Action(() =>
            {
                (owner as WindowX).IsMaskVisible = toOpen;
            }));
        }
        #endregion
    }
}
