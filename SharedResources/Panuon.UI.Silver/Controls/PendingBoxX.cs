using Panuon.UI.Silver.Internal.Constracts.Implements;
using Panuon.UI.Silver.Internal.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public static class PendingBoxX
    {
        #region Methods
        public static IPendingHandler Show(string message)
        {
            return CallPendingBox(message, null, true, null);
        }

        public static IPendingHandler Show(string message, bool canCancel, Window owner = null)
        {
            return CallPendingBox(message, null, canCancel, owner);
        }

        public static IPendingHandler Show(string message, string caption)
        {
            return CallPendingBox(message, caption, true, null);
        }

        public static IPendingHandler Show(string message, string caption, bool canCancel, Window owner = null)
        {
            return CallPendingBox(message, caption, canCancel, owner);
        }
        #endregion

        #region Properties
        public static PendingBoxConfigurations Configurations { get; } = new PendingBoxConfigurations();
        #endregion

        #region Function
        private static IPendingHandler CallPendingBox(string message, string caption, bool canCancel, Window owner)
        {
            PendingHanlderImpl handler = null;
            if (Configurations.InvokeOnNewThread)
            {
                PendingWindow pendingWindow = null;
                handler = new PendingHanlderImpl(pendingWindow);
                var thread = new Thread(() =>
                {
                    pendingWindow = new PendingWindow(message, caption, canCancel, owner);
                    pendingWindow.Closed += delegate
                    {
                        pendingWindow.Dispatcher.InvokeShutdown();
                    };
                    pendingWindow.Show();
                    Dispatcher.Run();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
                var pendingWindow = new PendingWindow(message, caption, canCancel, owner);
                handler = new PendingHanlderImpl(pendingWindow);
            }
            return handler;
        }
        #endregion
    }
}
