using Caliburn.Micro;
using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIBrowser.Core;

namespace UIBrowser.ViewModels.Partials.Notifications
{
    public class NoticeXViewModel : Screen, IShell, IPartialView
    {
        #region Event
        public event UpdatePaletteEventHandler UpdatePalette;
        #endregion

        #region Properties

        public ControlType PaletteControlType => ControlType.WindowX;

        public bool IsPaletteEnabled => false;

        #endregion

        #region Methods
        public void Notice(string cap)
        {
            switch (cap)
            {
                case "none":
                    NoticeX.Show("This is a message. This is a message. This is a message. This is a message. This is a message.", "None", MessageBoxIcon.None, 3000);
                    break;
                case "info":
                    NoticeX.Show("This is a message. This is a message. This is a message. This is a message. This is a message.", "Info", MessageBoxIcon.Info, 3000);
                    break;
                case "warning":
                    NoticeX.Show("This is a message. This is a message. This is a message. This is a message. This is a message.", "Warning", MessageBoxIcon.Warning, 3000);
                    break;
                case "error":
                    NoticeX.Show("This is a message. This is a message. This is a message. This is a message. This is a message.", "Error", MessageBoxIcon.Error, 3000);
                    break;
                case "question":
                    NoticeX.Show("This is a message. This is a message. This is a message. This is a message. This is a message.", "Question", MessageBoxIcon.Question, 3000);
                    break;
                case "success":
                    NoticeX.Show("This is a message. This is a message. This is a message. This is a message. This is a message.", "Warning", MessageBoxIcon.Success, 3000);
                    break;
                case "image":
                    NoticeX.Show("This is a message.", "Image", "/UIBrowser;component/Resources/Images/panuon.png", 3000);
                    break;
                case "always":
                    NoticeX.Show("This is a message.", "Image", "/UIBrowser;component/Resources/Images/panuon.png");
                    break;
            }
        }
        #endregion
    }
}
