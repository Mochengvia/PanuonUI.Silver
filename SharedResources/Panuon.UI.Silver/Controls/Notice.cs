using Panuon.UI.Silver.Controls.Internal;

namespace Panuon.UI.Silver
{
    public class Notice
    {
        public static void Show(string message , string title)
        {
            CallNoticeWindow(message, title, null, MessageBoxIcon.None);
        }

        public static void Show(string message, string title, MessageBoxIcon noticeIcon)
        {
            CallNoticeWindow(message, title, null, noticeIcon);
        }

        public static void Show(string message, string title, double durationSeconds = 3, MessageBoxIcon noticeIcon = MessageBoxIcon.None)
        {
            CallNoticeWindow(message, title, durationSeconds, noticeIcon);
        }

        private static void CallNoticeWindow(string message, string title, double? durationSeconds, MessageBoxIcon noticeIcon)
        {
            if (NoticeWindow.Instance == null)
            {
                var window = new NoticeWindow();
                window.Show();
            }
            NoticeWindow.Instance.AddNotice(message, title, durationSeconds, noticeIcon);
        }
    }
}
