using System.Windows;
using System.Windows.Shell;

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
