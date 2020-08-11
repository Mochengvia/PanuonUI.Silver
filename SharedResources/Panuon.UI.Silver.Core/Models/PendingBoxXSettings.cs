using Panuon.UI.Silver.Internal.Utils;

namespace Panuon.UI.Silver.Core
{
    public class PendingBoxXSettings
    {
        #region Ctor
        public PendingBoxXSettings()
        {
        }
        #endregion

        #region Properties
        public bool CreateOnNewThread { get; set; }

        public bool IsEscEnabled { get; set; } = true;

        public bool InteractOwnerMask { get; set; } = true;

        public object CancelButtonContent { get; set; } = LocalizationUtils.Cancel;
        #endregion
    }
}
