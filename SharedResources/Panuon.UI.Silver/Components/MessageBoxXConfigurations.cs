using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Utils;
using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class MessageBoxXConfigurations
    {
        #region Ctor

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the basic style.
        /// </summary>
        public MessageBoxStyle MessageBoxStyle { get; set; } = MessageBoxStyle.Standard;

        /// <summary>
        /// Gets or sets the background of the default button.
        /// </summary>
        public Brush DefaultButtonBrush { get; set; } = "#80BEE8".ToColor().ToBrush();

        /// <summary>
        /// Gets or sets the min height of MessageBoxX.
        /// </summary>
        public double MinHeight { get; set; } = 250;

        /// <summary>
        /// Gets or sets the min width of MessageBoxX.
        /// </summary>
        public double MinWidth { get; set; } = 500;

        /// <summary>
        /// Gets or sets the font size of MessageBoxX.
        /// </summary>
        public double FontSize { get; set; } = 16;

        /// <summary>
        /// Gets or sets the content height of MessageBoxX.
        /// </summary>
        public double ContentHeight { get; set; } = 100;

        /// <summary>
        /// Gets or sets the content width of MessageBoxX.
        /// </summary>
        public double ContentWidth { get; set; } = 300;

        /// <summary>
        /// Gets or sets whether MessageBoxX is displayed in the taskbar
        /// </summary>
        public bool ShowInTaskbar { get; set; } = true;

        /// <summary>
        /// Gets or sets whether MessageBoxX is placed on top of all windows
        /// </summary>
        public bool Topmost { get; set; } = true;

        /// <summary>
        /// Gets or sets the startup position of MessageBoxX.
        /// </summary>
        public WindowStartupLocation WindowStartupLocation { get; set; } = WindowStartupLocation.CenterOwner;

        /// <summary>
        /// Gets or sets whether to open the mask layer of the owner window when MessageBoxX pops up. Mask layer will be closed after MessageBoxX closed.
        /// <para>Only works when Owner is of WindowX type.</para>
        /// </summary>
        public bool InteractOwnerMask { get; set; } = true;

        /// <summary>
        /// Gets or sets the content text of the Yes button.
        /// </summary>
        public string YesButton { get; set; } = LocalizationUtils.Yes;

        /// <summary>
        /// Gets or sets the content text of the No button.
        /// </summary>
        public string NoButton { get; set; } = LocalizationUtils.No;

        /// <summary>
        /// Gets or sets the content text of the OK button.
        /// </summary>
        public string OKButton { get; set; } = LocalizationUtils.OK;

        /// <summary>
        /// Gets or sets the content text of the Cancel button.
        /// </summary>
        public string CancelButton { get; set; } = LocalizationUtils.Cancel;

        /// <summary>
        /// Gets or sets whether to reverse the sequence of the buttons group.
        /// </summary>
        public bool ReverseButtonSequence { get; set; }
        #endregion
    }
}
