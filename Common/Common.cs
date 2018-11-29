using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Win32;

namespace CSharpStock
{
    public class Common
    {
        public struct WindowInfo
        {
            public IntPtr hWnd;
            public string szWindowName;
            public string szClassName;
            public string DlgCtrlID;
            public int isVisible;
        }
        /// <summary>
        /// 根据进程名获取第一个有窗体的句柄
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public static IntPtr GetIntPtrByProcess(string processName)
        {
            IntPtr main = IntPtr.Zero;
            foreach (Process p in Process.GetProcessesByName(processName))
            {
                if (p.MainWindowHandle != IntPtr.Zero)
                {
                    main = p.MainWindowHandle;
                    break;
                }
            }
            return main;
        }
        /// <summary>
        /// 依据ID序列，获取指定的窗体句柄
        /// </summary>
        /// <param name="mainWindow"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IntPtr GetIntPtrByControlID(IntPtr mainWindow, string id)
        {
            string[] ids = id.Split(".".ToArray());
            IntPtr result = mainWindow;
            for (int i = 0; i < ids.Length; i++)
            {
                result = (IntPtr)User.GetDlgItem(result, Convert.ToInt32(ids[i], 16));
            }
            return result;
        }

        public List<WindowInfo> addToDick(IntPtr window)
        {
            //用来保存窗口对象 列表
            List<WindowInfo> wndList = new List<WindowInfo>();
            //enum all desktop windows 
            User.EnumChildWindows(window, delegate (IntPtr hWnd, int lParam)
            {
                WindowInfo wnd = new WindowInfo();
                StringBuilder sb = new StringBuilder(256);

                //get hwnd 
                wnd.hWnd = (IntPtr)hWnd;

                //get window name  
                User.GetWindowText((IntPtr)hWnd, sb, sb.Capacity);
                wnd.szWindowName = sb.ToString();

                //get window class 
                User.GetClassName((IntPtr)hWnd, sb, sb.Capacity);
                wnd.szClassName = sb.ToString();

                wnd.DlgCtrlID = User.GetDlgCtrlID((IntPtr)hWnd).ToString();

                //add it into list 
                wndList.Add(wnd);
                return true;
            }, 0);
            return wndList;
        }

        public static void GetWindows(IntPtr window, ref List<WindowInfo> wndList, string ctrlID="")
        {
            int curChild = 0;
            curChild = User.FindWindowEx(window, (IntPtr)curChild, null, null);
            while (curChild > 0)
            {
                WindowInfo curWindow = new WindowInfo();
                StringBuilder sb = new StringBuilder(256);
                curWindow.hWnd = (IntPtr)curChild;
                User.GetWindowText((IntPtr)curChild, sb, sb.Capacity);
                curWindow.szWindowName = sb.ToString();
                User.GetClassName((IntPtr)curChild, sb, sb.Capacity);
                curWindow.szClassName = sb.ToString();
                curWindow.DlgCtrlID = ctrlID + "." + User.GetDlgCtrlID((IntPtr)curChild).ToString("x").PadLeft(8, '0');
                curWindow.isVisible = User.IsWindowVisible((IntPtr)curChild);

                wndList.Add(curWindow);
                GetWindows((IntPtr)curChild, ref wndList, curWindow.DlgCtrlID);
                curChild = User.FindWindowEx(window, (IntPtr)curChild, null, null);
            }

        }
        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="hWnd"></param>
        public static void Click(IntPtr hWnd)
        {
            User.SendMessage(hWnd, User.WM_CLICK, 0, IntPtr.Zero);
        }
        /// <summary>
        /// 窗体在最前显示
        /// </summary>
        /// <param name="hWnd"></param>
        public static void BringToFront(IntPtr hWnd)
        {
            User.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, 1 | 2);
        }
        /// <summary>
        /// 模拟键盘按下
        /// </summary>
        /// <param name="key"></param>
        public static void SendKey(byte key)
        {
            User.keybd_event(key, 0, User.KEYEVENTF_KEYDOWN, 0);
            Thread.Sleep(10);
            User.keybd_event(key, 0, User.KEYEVENTF_KEYUP, 0);
        }
        /// <summary>
        /// 模拟组合键盘按下+Ctrl
        /// </summary>
        /// <param name="key"></param>
        public static void SendKeyWithCtrl(byte key)
        {
            User.keybd_event(User.VK_CONTROL, 0, User.KEYEVENTF_KEYDOWN, 0);
            User.keybd_event(key, 0, User.KEYEVENTF_KEYDOWN, 0);
            Thread.Sleep(10);
            User.keybd_event(key, 0, User.KEYEVENTF_KEYUP, 0);
            User.keybd_event(User.VK_CONTROL, 0, User.KEYEVENTF_KEYUP, 0);
        }
        /// <summary>
        /// 获取控件文本
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static string GetTitle(IntPtr hWnd)
        {
            StringBuilder sb = new StringBuilder(User.GetWindowTextLength(hWnd));
            User.GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }
        /// <summary>
        /// 设置控件文本
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="text"></param>
        public static void SetTitle(IntPtr hWnd, string text)
        {
            User.SendMessage(hWnd, User.WM_SETTEXT, 0, text);
        }
        /// <summary>
        /// 向指定窗体发送复制命令
        /// </summary>
        /// <param name="hwnd"></param>
        public static void Copy(IntPtr hwnd)
        {
            User.SendMessage(hwnd, User.WM_COMMAND, 0x0000E122, IntPtr.Zero);
        }
    }
}
