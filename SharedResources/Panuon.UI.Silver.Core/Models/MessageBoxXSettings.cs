using Panuon.UI.Silver.Internal.Utils;

namespace Panuon.UI.Silver.Core
{
    public class MessageBoxXSettings
    {
        #region Properties
        /// <summary>
        /// Allow the user to close the window by pressing the Esc key. Only works  when MessageBoxButton is OK , OKCancel or YesNoCancel.
        /// </summary>
        public bool IsEscEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets whether to open the mask layer of the owner window when MessageBoxX pops up. Mask layer will be closed after MessageBoxX closed.
        /// <para>Only works when Owner is WindowX type.</para>
        /// </summary>
        public bool InteractOwnerMask { get; set; } = true;

        /// <summary>
        /// Gets or sets the content text of the Yes button.
        /// </summary>
        public object YesButton { get; set; } = LocalizationUtils.Yes;

        /// <summary>
        /// Gets or sets the content text of the No button.
        /// </summary>
        public object NoButton { get; set; } = LocalizationUtils.No;

        /// <summary>
        /// Gets or sets the content text of the OK button.
        /// </summary>
        public object OKButton { get; set; } = LocalizationUtils.OK;

        /// <summary>
        /// Gets or sets the content text of the Cancel button.
        /// </summary>
        public object CancelButton { get; set; } = LocalizationUtils.Cancel;

        /// <summary>
        /// Arrangement order of buttons.
        /// </summary>
        public MessageBoxButtonArrangement ButtonArrangement { get; set; } = MessageBoxButtonArrangement.Standard;
        #endregion
    }
}
