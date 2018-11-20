using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CSharpStock
{
    public partial class Form1 : Form
    {
        IntPtr main;
        public Form1()
        {
            InitializeComponent();
            main = Common.GetIntPtr("SwitchHosts");
        }

        public struct WindowInfo
        {
            public IntPtr hWnd;
            public string szWindowName;
            public string szClassName;
            public long DlgCtrlID;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            main = Common.GetIntPtr("SwitchHosts");
            IntPtr tree = FindWindowEx(main, 0, "SysTreeView32", "");
            PostMessage(main, 256, Keys.F1, 2);
            List<WindowInfo> wndList = addToDick(main);
            IntPtr child1 = GetDlgItem(main, 0x00000000);
            IntPtr child2 = GetDlgItem(child1, 0x0000E900);
            IntPtr child3 = GetDlgItem(child2, 0x0000E901);
            IntPtr child4 = GetDlgItem(child3, 0x00000000);
            IntPtr btn = GetDlgItem(child4, 0x00008016);

            SendMessage(btn, 0x00F5, 0, 0);
        }

        public List<WindowInfo> addToDick(IntPtr window)
        {
            //用来保存窗口对象 列表
            List<WindowInfo> wndList = new List<WindowInfo>();

            //enum all desktop windows 
            EnumChildWindows(window, delegate (IntPtr hWnd, int lParam)
                 {
                     WindowInfo wnd = new WindowInfo();
                     StringBuilder sb = new StringBuilder(256);

                    //get hwnd 
                    wnd.hWnd = hWnd;

                    //get window name  
                    GetWindowTextW(hWnd, sb, sb.Capacity);
                     wnd.szWindowName = sb.ToString();

                    //get window class 
                    GetClassNameW(hWnd, sb, sb.Capacity);
                     wnd.szClassName = sb.ToString();

                     wnd.DlgCtrlID = GetDlgCtrlID(hWnd);

                    //add it into list 
                    wndList.Add(wnd);
                     return true;
                 }, 0);
            return wndList;
        }

        public delegate bool CallBack(IntPtr hwnd, int y);
        [DllImport("user32.dll", EntryPoint = "FindWindowA", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, uint hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
        private static extern void SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern int EnumWindows(CallBack x, int y);
        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpEnumFunc, int lParam);
        [DllImport("user32")]
        public static extern int GetWindowText(int hwnd, StringBuilder lptrString, int nMaxCount);
        [DllImport("user32.dll ", EntryPoint = "GetDlgItem")]
        public static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);
        [DllImport("user32")]
        public static extern long GetDlgCtrlID(IntPtr hwnd);// &&通过句柄得到控件ID
        //获取窗口Text 
        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern int PostMessage(IntPtr hWnd, int Msg, Keys wParam, int lParam);
        //获取窗口类名 
        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        private void button2_Click(object sender, EventArgs e)
        {
            PostMessage(main, 256, Keys.F1, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PostMessage(main, 256, Keys.F2, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PostMessage(main, 256, Keys.F3, 2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PostMessage(main, 256, Keys.F4, 2);
        }
    }
}
