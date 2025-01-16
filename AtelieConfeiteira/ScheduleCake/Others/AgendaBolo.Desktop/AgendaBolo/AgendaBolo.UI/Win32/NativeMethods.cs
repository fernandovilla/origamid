using System.Runtime.InteropServices;
using System.Text;

namespace AgendaBolo.UI.Win32
{
    internal static class NativeMethods
    {
        public const int WM_DESTROY = 0x0002;
        public const int WM_ACTIVATE = 0x0006;
        public const int WM_SETFOCUS = 0x0007;
        public const int WM_KILLFOCUS = 0x0008;
        public const int WM_SETREDRAW = 0x000B;
        public const int WM_SETTEXT = 0x000C;
        public const int WM_ERASEBKGND = 0x0014;
        public const int WM_PAINT = 0x000F;
        public const int WM_NCACTIVATE = 0x0086;
        public const int WM_CUT = 0x0300;
        public const int WM_COPY = 0x0301;
        public const int WM_PASTE = 0x0302;
        public const int WM_QUERYUISTATE = 0x0129;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_WINDOWPOSCHANGED = 0x0047;
        public const int WM_SETFONT = 0x0030;
        public const int WM_KEYDOWN = 0x0100;

        public const int WS_VISIBLE = 0x10000000;
        public const int WS_EX_APPWINDOW = 0x40000;
        public const int WS_CAPTION = 0xC00000;
        public const int WS_CLIPSIBLINGS = 0x4000000;
        public const int WS_CLIPCHILDREN = 0x02000000;
        public const int WS_POPUP = unchecked((int)0x80000000);
        public const int WS_MAXIMIZEBOX = 0x00010000;
        public const int WS_BORDER = 0x00800000;
        public const int WS_CHILD = 0x40000000;
        public const int WS_DISABLED = 0x08000000;

        public const int WS_EX_LEFT = 0x00000000;
        public const int WS_EX_LTRREADING = 0x00000000;
        public const int WS_EX_RIGHTSCROLLBAR = 0x00000000;
        public const int WS_EX_TOPMOST = 0x00000008;
        public const int WS_EX_CONTROLPARENT = 0x10000;
        public const int WS_EX_LAYERED = 0x80000;
        public const int WS_EX_TOOLWINDOW = 0x00000080;
        public const int WS_EX_NOACTIVATE = 0x08000000;
        public const int WS_EX_COMPOSITED = 0x02000000;

        public const int CS_DROPSHADOW = 0x20000;
        public const int CS_SAVEBITS = 0x800;
        public const int CS_HREDRAW = 0x0002;
        public const int CS_VREDRAW = 0x0001;

        public const int RDW_INVALIDATE = 1;
        public const int RDW_ERASE = 4;
        public const int RDW_ALLCHILDREN = 0x80;
        public const int RDW_UPDATENOW = 0x100;
        public const int RDW_FRAME = 0x400;

        public const int EC_LEFTMARGIN = 1;
        public const int EC_RIGHTMARGIN = 2;
        public const int EC_USEFONTINFO = 0xffff;

        public const int EM_GETMARGINS = 0x00d4;
        public const int EM_SETMARGINS = 0x00d3;
        public const int EM_CHARFROMPOS = 0x00d7;
        public const int EM_GETLINECOUNT = 0x00ba;

        public const int GWL_HWNDPARENT = -8;
        public const int GWL_STYLE = -16;

        public const int WA_INACTIVE = 0;
        public const int WA_ACTIVE = 1;

        public const int WM_CHANGEUISTATE = 0x0127;
        public const int WM_UPDATEUISTATE = 0x0128;
        public const int UIS_CLEAR = 2;
        public const short UISF_HIDEFOCUS = 0x0001;

        public const int KEYEVENTF_EXTENDEDKEY = 0x1;
        public const int KEYEVENTF_KEYDOWN = 0x0;
        public const int KEYEVENTF_KEYUP = 0x2;

        public const int SW_RESTORE = 0x0009;


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetActiveWindow();


        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);


        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDC(IntPtr hWnd);


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool RedrawWindow(IntPtr hwnd, IntPtr rcUpdate, IntPtr hrgnUpdate, int flags);


        public static bool InvalidateNC(IntPtr handle)
        {
            return NativeMethods.RedrawWindow(handle, IntPtr.Zero, IntPtr.Zero, NativeMethods.RDW_FRAME | NativeMethods.RDW_UPDATENOW | NativeMethods.RDW_INVALIDATE);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, bool wParam, int lParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, StringBuilder lParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);


        public static void SetRedraw(IntPtr hWnd, bool redraw)
        {
            NativeMethods.SendMessage(hWnd, NativeMethods.WM_SETREDRAW, redraw, 0);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool IsChild(IntPtr hWndParent, IntPtr hwnd);



        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);


        public static string GetWindowText(IntPtr hWnd)
        {
            StringBuilder buffer = new StringBuilder(512);

            int length = GetWindowText(hWnd, buffer, buffer.Length);

            return buffer.ToString();
        }


        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);


        public static string GetClassName(IntPtr hWnd)
        {
            StringBuilder buffer = new StringBuilder(512);

            int length = GetClassName(hWnd, buffer, buffer.Length);

            return buffer.ToString();
        }


        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr32(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        public static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
            }

            return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);


        [DllImport("user32.dll")]
        public static extern bool ScrollWindow(IntPtr hWnd, int nXAmount, int nYAmount, ref RECT rectScrollRegion, ref RECT rectClip);


        [DllImport("user32.dll")]
        public static extern bool UpdateWindow(IntPtr hWnd);


        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);


        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);


        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);


        [DllImport("user32.dll")]
        public static extern bool IsZoomed(IntPtr hWnd);


        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);


        public static int MakeLong(int a, int b)
        {
            return a | ((int)b << 16);
        }

        public static int LOWORD(int n)
        {
            return (n & 0xFFFF);
        }

        public static int HIWORD(int n)
        {
            return ((n >> 0x10) & 0xFFFF);
        }


        public static Rectangle GetClientRect(IntPtr hWnd)
        {
            RECT rect;

            if (NativeMethods.GetClientRect(hWnd, out rect))
            {
                return Rectangle.FromLTRB(rect.left, rect.top, rect.right, rect.bottom);
            }

            return Rectangle.Empty;
        }


        public static Rectangle GetWindowRect(IntPtr hWnd)
        {
            RECT rect;

            if (NativeMethods.GetWindowRect(hWnd, out rect))
            {
                return Rectangle.FromLTRB(rect.left, rect.top, rect.right, rect.bottom);
            }

            return Rectangle.Empty;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;

        public RECT(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public RECT(System.Drawing.Rectangle r)
        {
            this.left = r.Left;
            this.top = r.Top;
            this.right = r.Right;
            this.bottom = r.Bottom;
        }

        public static RECT FromXYWH(int x, int y, int width, int height)
        {
            return new RECT(x, y, x + width, y + height);
        }

        public System.Drawing.Size Size
        {
            get
            {
                return new System.Drawing.Size(this.right - this.left, this.bottom - this.top);
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public class BitmapInfoHeader
    {
        public int Size;
        public int Width;
        public int Height;
        public short Planes;
        public short BitCount;
        public int Compression;
        public int ImageSize;
        public int XPelsPerMeter;
        public int YPelsPerMeter;
        public int ClrUsed;
        public int ClrImportant;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class VideoInfoHeader
    {
        public RECT SrcRect;
        public RECT TargetRect;
        public int BitRate;
        public int BitErrorRate;
        public long AvgTimePerFrame;
        public BitmapInfoHeader BmiHeader;
    }
}
