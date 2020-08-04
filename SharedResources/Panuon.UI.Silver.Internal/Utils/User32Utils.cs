using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal static class User32Utils
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32", EntryPoint = "SetWindowPos")]
        internal static extern int SetWindowPos(IntPtr hWnd, int hwndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        [DllImport("user32")]
        internal static extern IntPtr GetParent(IntPtr hWnd);
    }
}
