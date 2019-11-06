using Panuon.UI.Silver.Utils;
using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver.Core
{
    public class MessageBoxXConfigurations
    {
        public MessageBoxXConfigurations()
        {
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag)
            {
                case "zh-CN":
                    YesButton = "是 的";
                    NoButton = "不";
                    OKButton = "好 的";
                    CancelButton = "取 消";
                    break;
            }
        }

        /// <summary>
        /// MessageBox style.
        /// </summary>
        public MessageBoxStyle MessageBoxStyle { get; set; } = MessageBoxStyle.Standard;

        /// <summary>
        /// MessageBox icon
        /// </summary>
        public MessageBoxIcon MessageBoxIcon { get; set; } = MessageBoxIcon.Info;

        /// <summary>
        /// Default button
        /// </summary>
        public DefaultButton DefaultButton { get; set; } = DefaultButton.YesOK;

        /// <summary>
        /// Button Brush
        /// </summary>
        public Brush ButtonBrush { get; set; } = "#55CEF1".ToColor().ToBrush();

        /// <summary>
        /// Min height. Default : 250.
        /// </summary>
        public double MinHeight { get; set; } = 250;

        /// <summary>
        /// Min width. Default : 500.
        /// </summary>
        public double MinWidth { get; set; } = 500;

        /// <summary>
        /// Font size. Default : 16.
        /// </summary>
        public double FontSize { get; set; } = 16;

        /// <summary>
        /// Max content height. default : 100.
        /// </summary>
        public double MaxContentHeight { get; set; } = 100;

        /// <summary>
        /// Max content width. Default : 300;
        /// </summary>
        public double MaxContentWidth { get; set; } = 300;

        /// <summary>
        /// Show in taskbar.
        /// </summary>
        public bool ShowInTaskbar { get; set; } = true;

        /// <summary>
        /// Topmost.
        /// </summary>
        public bool Topmost { get; set; } = true;

        /// <summary>
        /// Window startup location.
        /// </summary>
        public WindowStartupLocation WindowStartupLocation { get; set; } = WindowStartupLocation.CenterScreen;

        /// <summary>
        /// Show owner's mask when popuped, and hide it when closed. Only worked with WindowX type owner.
        /// </summary>
        public bool InteractOwnerMask { get; set; } = true;

        /// <summary>
        /// Content of yes button.
        /// </summary>
        public string YesButton { get; set; } = "Yes";

        /// <summary>
        /// Content of no button.
        /// </summary>
        public string NoButton { get; set; } = "No";

        /// <summary>
        /// Content of ok button.
        /// </summary>
        public string OKButton { get; set; } = "OK";

        /// <summary>
        /// Content of cancel button. 
        /// </summary>
        public string CancelButton { get; set; } = "Cancel";

        /// <summary>
        /// Reverse button sequence.
        /// </summary>
        public bool ReverseButtonSequence { get; set; }
    }
}
