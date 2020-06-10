using Caliburn.Micro;
using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using UIBrowser.Core;

namespace UIBrowser.ViewModels.Partials.Notifications
{
    public class PendingBoxXViewModel : Screen, IShell, IPartialView
    {
        #region Event
        public event UpdatePaletteEventHandler UpdatePalette;
        #endregion

        #region Properties

        public ControlType PaletteControlType => ControlType.WindowX;

        public bool IsPaletteEnabled => false;

        #endregion

        #region Methods
        public async void PendingBox(string cap)
        {
            IPendingHandler handler = null;
            switch (cap)
            {
                case "normal":
                    handler = PendingBoxX.Show("Processing .....", "Normal", true, Application.Current.MainWindow);
                    break;
            }
            if (handler != null)
            {
                handler.Cancelling += Handler_Cancelling;
                await Task.Delay(2000);
                handler.UpdateMessage("Almost complete ...");
                await Task.Delay(4000);
                handler.Close();
            }
        }

        #endregion

        #region Event Handler
        private void Handler_Cancelling(IPendingHandler sender, Panuon.UI.Silver.Core.PendingBoxCancellingEventArgs e)
        {
            sender.Close();
        }
        #endregion
    }
}
