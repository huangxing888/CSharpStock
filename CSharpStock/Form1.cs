using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CSharpStock
{
    public partial class Form1 : Form
    {
        #region bVk参数 常量定义

        public const byte vbKeyLButton = 0x1;    // 鼠标左键
        public const byte vbKeyRButton = 0x2;    // 鼠标右键
        public const byte vbKeyCancel = 0x3;     // CANCEL 键
        public const byte vbKeyMButton = 0x4;    // 鼠标中键
        public const byte vbKeyBack = 0x8;       // BACKSPACE 键
        public const byte vbKeyTab = 0x9;        // TAB 键
        public const byte vbKeyClear = 0xC;      // CLEAR 键
        public const byte vbKeyReturn = 0xD;     // ENTER 键
        public const byte vbKeyShift = 0x10;     // SHIFT 键
        public const byte vbKeyControl = 0x11;   // CTRL 键
        public const byte vbKeyAlt = 18;         // Alt 键  (键码18)
        public const byte vbKeyMenu = 0x12;      // MENU 键
        public const byte vbKeyPause = 0x13;     // PAUSE 键
        public const byte vbKeyCapital = 0x14;   // CAPS LOCK 键
        public const byte vbKeyEscape = 0x1B;    // ESC 键
        public const byte vbKeySpace = 0x20;     // SPACEBAR 键
        public const byte vbKeyPageUp = 0x21;    // PAGE UP 键
        public const byte vbKeyEnd = 0x23;       // End 键
        public const byte vbKeyHome = 0x24;      // HOME 键
        public const byte vbKeyLeft = 0x25;      // LEFT ARROW 键
        public const byte vbKeyUp = 0x26;        // UP ARROW 键
        public const byte vbKeyRight = 0x27;     // RIGHT ARROW 键
        public const byte vbKeyDown = 0x28;      // DOWN ARROW 键
        public const byte vbKeySelect = 0x29;    // Select 键
        public const byte vbKeyPrint = 0x2A;     // PRINT SCREEN 键
        public const byte vbKeyExecute = 0x2B;   // EXECUTE 键
        public const byte vbKeySnapshot = 0x2C;  // SNAPSHOT 键
        public const byte vbKeyDelete = 0x2E;    // Delete 键
        public const byte vbKeyHelp = 0x2F;      // HELP 键
        public const byte vbKeyNumlock = 0x90;   // NUM LOCK 键

        //常用键 字母键A到Z
        public const byte vbKeyA = 65;
        public const byte vbKeyB = 66;
        public const byte vbKeyC = 67;
        public const byte vbKeyD = 68;
        public const byte vbKeyE = 69;
        public const byte vbKeyF = 70;
        public const byte vbKeyG = 71;
        public const byte vbKeyH = 72;
        public const byte vbKeyI = 73;
        public const byte vbKeyJ = 74;
        public const byte vbKeyK = 75;
        public const byte vbKeyL = 76;
        public const byte vbKeyM = 77;
        public const byte vbKeyN = 78;
        public const byte vbKeyO = 79;
        public const byte vbKeyP = 80;
        public const byte vbKeyQ = 81;
        public const byte vbKeyR = 82;
        public const byte vbKeyS = 83;
        public const byte vbKeyT = 84;
        public const byte vbKeyU = 85;
        public const byte vbKeyV = 86;
        public const byte vbKeyW = 87;
        public const byte vbKeyX = 88;
        public const byte vbKeyY = 89;
        public const byte vbKeyZ = 90;

        //数字键盘0到9
        public const byte vbKey0 = 48;    // 0 键
        public const byte vbKey1 = 49;    // 1 键
        public const byte vbKey2 = 50;    // 2 键
        public const byte vbKey3 = 51;    // 3 键
        public const byte vbKey4 = 52;    // 4 键
        public const byte vbKey5 = 53;    // 5 键
        public const byte vbKey6 = 54;    // 6 键
        public const byte vbKey7 = 55;    // 7 键
        public const byte vbKey8 = 56;    // 8 键
        public const byte vbKey9 = 57;    // 9 键


        public const byte vbKeyNumpad0 = 0x60;    //0 键
        public const byte vbKeyNumpad1 = 0x61;    //1 键
        public const byte vbKeyNumpad2 = 0x62;    //2 键
        public const byte vbKeyNumpad3 = 0x63;    //3 键
        public const byte vbKeyNumpad4 = 0x64;    //4 键
        public const byte vbKeyNumpad5 = 0x65;    //5 键
        public const byte vbKeyNumpad6 = 0x66;    //6 键
        public const byte vbKeyNumpad7 = 0x67;    //7 键
        public const byte vbKeyNumpad8 = 0x68;    //8 键
        public const byte vbKeyNumpad9 = 0x69;    //9 键
        public const byte vbKeyMultiply = 0x6A;   // MULTIPLICATIONSIGN(*)键
        public const byte vbKeyAdd = 0x6B;        // PLUS SIGN(+) 键
        public const byte vbKeySeparator = 0x6C;  // ENTER 键
        public const byte vbKeySubtract = 0x6D;   // MINUS SIGN(-) 键
        public const byte vbKeyDecimal = 0x6E;    // DECIMAL POINT(.) 键
        public const byte vbKeyDivide = 0x6F;     // DIVISION SIGN(/) 键


        //F1到F12按键
        public const byte vbKeyF1 = 0x70;   //F1 键
        public const byte vbKeyF2 = 0x71;   //F2 键
        public const byte vbKeyF3 = 0x72;   //F3 键
        public const byte vbKeyF4 = 0x73;   //F4 键
        public const byte vbKeyF5 = 0x74;   //F5 键
        public const byte vbKeyF6 = 0x75;   //F6 键
        public const byte vbKeyF7 = 0x76;   //F7 键
        public const byte vbKeyF8 = 0x77;   //F8 键
        public const byte vbKeyF9 = 0x78;   //F9 键
        public const byte vbKeyF10 = 0x79;  //F10 键
        public const byte vbKeyF11 = 0x7A;  //F11 键
        public const byte vbKeyF12 = 0x7B;  //F12 键

        #endregion
        public const int WM_SETTEXT = 0x000C;
        public const int WM_CLICK = 0x00F5;
        IntPtr main;
        public Form1()
        {
            InitializeComponent();
            main = Common.GetIntPtr("xiadan");
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
            main = Common.GetIntPtr("xiadan");
            IntPtr tree = FindWindowEx(main, 0, "SysTreeView32", "");
            //PostMessage(main, 256, Keys.F1, 2);
            //getStock();
            Common.getItem(main, "00000000.0000E900");
            List<WindowInfo> wndList = addToDick(main);
            IntPtr child1 = GetDlgItem(main, 0x00000000);
            IntPtr child2 = GetDlgItem(child1, 0x0000E900);
            IntPtr child3 = GetDlgItem(child2, 0x0000E901);
            IntPtr child4 = GetDlgItem(child3, 0x00000417);
            IntPtr child5 = GetDlgItem(child4, 0x000000C8);
            IntPtr child6 = GetDlgItem(child5, 0x00000417);
            //SendMessage(child6, 0x111, 0, 0);
            //MessageBox.Show(System.Windows.Forms.Clipboard.GetText().ToString());
            ////SendMessage,0x111,57634,0,CVirtualGridCtrl2,同花顺

            //int length = GetWindowTextLength(child6);
            //StringBuilder windowName = new StringBuilder(length + 1);
            //GetWindowText(child6, windowName, windowName.Capacity);
            //MessageBox.Show(windowName.ToString());


            //SetWindowPos(main, -1, 0, 0, 0, 0, 1 | 2);
            //keybd_event(vbKeyControl, 0, 0, 0);  //按下ctrl，在下面释放之前，他的状态一直还是被按下的
            //keybd_event(vbKeyS, 0, 0, 0);  //按下s
            //Thread.Sleep(10);
            //keybd_event(vbKeyS, 0, 0x02, 0);   //释放s键 
            //keybd_event(vbKeyControl, 0, 0x02, 0);  //释放 ctrl 键
            //Thread.Sleep(100);
            //IntPtr text = FindWindow(null, "另存为");
            //IntPtr edit = FindWindowEx(text, 0, "Edit", null);
            //SendMessage(edit, WM_SETTEXT, IntPtr.Zero, "d:\\" + DateTime.Now.Ticks + ".xls");
            //Thread.Sleep(100);
            //IntPtr save = FindWindowEx(text, 0, "Button", "保存(&S)");
            //SendMessage(save, WM_CLICK, IntPtr.Zero, "");

        }

        public void getStock()
        {
            SetWindowPos(main, -1, 0, 0, 0, 0, 1 | 2);
            PostMessage(main, 256, Keys.F4, 2);
            Thread.Sleep(100);
            keybd_event(vbKeyControl, 0, 0, 0);  //按下ctrl，在下面释放之前，他的状态一直还是被按下的
            keybd_event(vbKeyC, 0, 0, 0);  //按下s
            Thread.Sleep(10);
            keybd_event(vbKeyC, 0, 0x02, 0);   //释放s键 
            keybd_event(vbKeyControl, 0, 0x02, 0);  //释放 ctrl 键
            MessageBox.Show(System.Windows.Forms.Clipboard.GetText());
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
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowText(IntPtr hWnd, string text);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, uint wParam, uint lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        public delegate bool CallBack(IntPtr hwnd, int y);
        [DllImport("user32.dll", EntryPoint = "FindWindowA", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, uint hwndChildAfter, string lpszClass, string lpszWindow);
        
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
        private static extern void SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern int EnumWindows(CallBack x, int y);
        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpEnumFunc, int lParam);
        [DllImport("user32")]
        public static extern int GetWindowText(IntPtr hwnd, StringBuilder lptrString, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);
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
