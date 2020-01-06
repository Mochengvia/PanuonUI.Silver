using Microsoft.Windows.Shell;
using System.Windows;

namespace Panuon.UI.Silver
{
    public partial class WindowX
    {
        #region Functon
        private static void SetIsHitTestVisibleInChrome(UIElement element, bool hitTestVisible)
        {
            WindowChrome.SetIsHitTestVisibleInChrome(element, hitTestVisible);
        }
        #endregion
    }
}
