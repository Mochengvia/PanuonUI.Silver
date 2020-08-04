using Panuon.UI.Silver.Internal.Resources;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class GlobalSettings
    {
        public FontFamily FontFamily
        {
            get
            {
                return GlobalHelper.FontFamily;
            }
            set
            {
                GlobalHelper.FontFamily = value;
            }
        }


        public int FontSize
        {
            get
            {
                return GlobalHelper.FontSize;
            }
            set
            {
                GlobalHelper.FontSize = value;
            }
        }
    }
}
