using Panuon.UI.Silver.Controls.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panuon.UI.Silver.Controls
{
    public class Notice
    {
        public static void Show(string message , string title)
        {
            CallNoticeWindow(message, title, null);
        }

        public static void Show(string message, string title, double durationSeconds = 3)
        {
            CallNoticeWindow(message, title, durationSeconds);
        }

        private static void CallNoticeWindow(string message, string title, double? durationSeconds)
        {
            if (NoticeWindow.Instance == null)
            {
                var window = new NoticeWindow();
                window.Show();
            }
            NoticeWindow.Instance.AddNotice();
        }
    }
}
