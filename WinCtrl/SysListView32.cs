//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace WinCtrl
//{
//    public class SysListView32
//    {
//        #region 结构体
//        [StructLayout(LayoutKind.Sequential)]
//        public struct LVITEM
//        {
//            public int mask;
//            public int iItem;
//            public int iSubItem;
//            public int state;
//            public int stateMask;
//            public IntPtr pszText;
//            public int cchTextMax;
//            public int iImage;
//            public IntPtr lParam;
//            public int iIndent;
//            public int iGroupId;
//            public int cColumns;
//            public IntPtr puColumns;
//        }
//        #endregion
//        public const int LVM_FIRST = 0x1000;
//        public const int LVM_GETITEMCOUNT = LVM_FIRST + 4;
//        public const int LVM_GETHEADER = LVM_FIRST + 31;
//        public const int LVM_GETITEMTEXT = LVM_FIRST + 45;//获取列表内的内容
//        public const int LVM_GETITEMW = LVM_FIRST + 75;
//        public const int LVM_GETCOLUMNA = LVM_FIRST + 25;
//        public const int LVM_GETCOLUMNW = LVM_FIRST + 95;
//        public const int HDM_FIRST = 0x1200;
//        public const int HDM_GETITEMCOUNT = HDM_FIRST + 0;
//        public const int HDM_ORDERTOINDEX = HDM_FIRST + 15;
//        public const int HDM_GETITEMW = HDM_FIRST + 11;
//        public const int HDM_SETIMAGELIST = 4616;
//        public const int HDM_SETHOTDIVIDER = 4627;
//        public const int HDM_HITTEST = 4614;
//        public const int HDM_GETIMAGELIST = 4617;
//        public const int HDM_GETORDERARRAY = 4625;
//        public const int HDM_INSERTITEMA = 4609;


//        [DllImport("user32.DLL")]
//        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
//        [DllImport("user32.DLL")]
//        public static extern IntPtr FindWindow(string lpszClass, string lpszWindow);
//        [DllImport("user32.DLL")]
//        public static extern IntPtr FindWindowEx(IntPtr hwndParent,
//            IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
//        [DllImport("user32.dll")]
//        public static extern uint GetWindowThreadProcessId(IntPtr hWnd,
//            out uint dwProcessId);

//        public const uint PROCESS_VM_OPERATION = 0x0008;
//        public const uint PROCESS_VM_READ = 0x0010;
//        public const uint PROCESS_VM_WRITE = 0x0020;

//        [DllImport("kernel32.dll")]
//        public static extern IntPtr OpenProcess(uint dwDesiredAccess,
//            bool bInheritHandle, uint dwProcessId);
//        public const uint MEM_COMMIT = 0x1000;
//        public const uint MEM_RELEASE = 0x8000;

//        public const uint MEM_RESERVE = 0x2000;
//        public const uint PAGE_READWRITE = 4;

//        [DllImport("kernel32.dll")]
//        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
//            uint dwSize, uint flAllocationType, uint flProtect);

//        [DllImport("kernel32.dll")]
//        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress,
//           uint dwSize, uint dwFreeType);

//        [DllImport("kernel32.dll")]
//        public static extern bool CloseHandle(IntPtr handle);

//        [DllImport("kernel32.dll")]
//        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
//           IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);

//        [DllImport("kernel32.dll")]
//        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
//           IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);

//        [StructLayout(LayoutKind.Sequential)]
//        public struct LVITEM
//        {
//            public uint mask;
//            public int iItem;
//            public int iSubItem;
//            public uint state;
//            public uint stateMask;
//            public IntPtr pszText; // string 
//            public int cchTextMax;
//            public int iImage;
//            public IntPtr lParam;
//            public int iIndent;
//            public int iGroupId;
//            public uint cColumns;
//            public uint puColumns;
//            public IntPtr piColFmt;
//            public int iGroup;
//            //public int mask;//说明此结构中哪些成员是有效的
//            //public int iItem;//项目的索引值(可以视为行号)从0开始
//            //public int iSubItem; //子项的索引值(可以视为列号)从0开始
//            //public int state;//子项的状态
//            //public int stateMask; //状态有效的屏蔽位
//            //public IntPtr pszText;  //主项或子项的名称
//            //public int cchTextMax;//pszText所指向的缓冲区大小

//        }
//        public struct LVCOLUMNW
//        {
//            //public uint mask;
//            //public int fmt;
//            //public int cx;
//            //public IntPtr pszText;
//            //public int cchTextMax;
//            //public int iSubItem;
//            //public int iImage;
//            //public int iOrder;
//            //public int cxMin;
//            //public int cxDefault;
//            //public int cxIdeal;
//            public uint mask;
//            public int cxy;
//            public IntPtr pszText;
//            public IntPtr hbm;
//            public int cchTextMax;
//            public int fmt;
//            public IntPtr lParam;
//            public int iImage;
//            public int iOrder;
//            public uint type;
//            public IntPtr pvFilter;
//            public uint state;
//        }
//        public uint LVIF_TEXT = 0x0001;


//        private void Read(object sender, EventArgs e)
//        {
//            IntPtr rootHwnd = FindWindow("TaskManagerWindow", "任务管理器");
//            rootHwnd = FindWindowEx(rootHwnd, IntPtr.Zero, "NativeHWNDHost", null);
//            rootHwnd = FindWindowEx(rootHwnd, IntPtr.Zero, "DirectUIHWND", null);
//            IntPtr vHandle = FindWindowEx(rootHwnd, IntPtr.Zero, "CtrlNotifySink", null);

//            IntPtr lvHwnd = FindWindowEx(vHandle, IntPtr.Zero, "SysListView32", null);
//            while (lvHwnd == IntPtr.Zero)
//            {
//                vHandle = FindWindowEx(rootHwnd, vHandle, "CtrlNotifySink", null);
//                lvHwnd = FindWindowEx(vHandle, IntPtr.Zero, "SysListView32", null);
//            }

//            vHandle = lvHwnd;

//            main = Common.GetIntPtrByProcess("tdxw");
//            vHandle = Common.GetIntPtrByControlID(main, "0000E81E.000000F5.00000000.00000000.00000000.0000E900.0000E901.00000000.0000061F");//
//            vHandle = (IntPtr)0x00040EB2;
//            if (vHandle == IntPtr.Zero) return;
//            int vItemCount = ListView_GetItemCount(vHandle);
//            uint vProcessId;
//            GetWindowThreadProcessId(vHandle, out vProcessId);

//            IntPtr vProcess = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ |
//                PROCESS_VM_WRITE, false, vProcessId);
//            IntPtr vPointer = VirtualAllocEx(vProcess, IntPtr.Zero, 4096,
//                MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
//            try
//            {
//                for (int i = 0; i < vItemCount; i++)
//                {
//                    byte[] vBuffer = new byte[256];
//                    LVITEM[] vItem = new LVITEM[1];
//                    vItem[0].mask = LVIF_TEXT;
//                    vItem[0].iItem = i;
//                    vItem[0].iSubItem = i;
//                    vItem[0].cchTextMax = vBuffer.Length;
//                    vItem[0].pszText = (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(LVITEM)));
//                    uint vNumberOfBytesRead = 0;

//                    WriteProcessMemory(vProcess, vPointer,
//                        Marshal.UnsafeAddrOfPinnedArrayElement(vItem, 0),
//                        Marshal.SizeOf(typeof(LVITEM)), ref vNumberOfBytesRead);
//                    SendMessage(vHandle, LVM_GETITEMW, 0, vPointer.ToInt32());
//                    ReadProcessMemory(vProcess,
//                        (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(LVITEM))),
//                        Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0),
//                        vBuffer.Length, ref vNumberOfBytesRead);

//                    string vText = Marshal.PtrToStringUni(
//                        Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0));
//                    Console.WriteLine(vText);
//                }
//            }
//            finally
//            {
//                VirtualFreeEx(vProcess, vPointer, 0, MEM_RELEASE);
//                CloseHandle(vProcess);
//            }
//            Console.WriteLine(ListViewColumnCount(vHandle));
//        }
//        /// <summary>
//        /// 获取 ListView 的行数
//        /// </summary>
//        /// <param name="hwnd"></param>
//        /// <returns></returns>
//        public int ListView_GetItemCount(IntPtr hwnd)
//        {
//            return SendMessage(hwnd, LVM_GETITEMCOUNT, 0, 0);
//        }

//        /// <summary>
//        /// 获取 ListView 的标题栏句柄
//        /// </summary>
//        /// <param name="hwnd"></param>
//        /// <returns></returns>
//        private IntPtr ListView_GetHeader(IntPtr hwnd)
//        {
//            return (IntPtr)SendMessage(hwnd, LVM_GETHEADER, 0, 0);
//        }

//        /// <summary>
//        /// 获取 ListView 的标题栏的列数
//        /// </summary>
//        /// <param name="header"></param>
//        /// <returns></returns>
//        private int Header_GetItemCount(IntPtr header)
//        {
//            return SendMessage(header, HDM_GETITEMCOUNT, 0, 0);
//        }

//        /// <summary>
//        /// 获取 ListView 的列数
//        /// </summary>
//        /// <param name="listViewHandle"></param>
//        /// <returns></returns>
//        int ListViewColumnCount(IntPtr listViewHandle)
//        {
//            return Header_GetItemCount(ListView_GetHeader(listViewHandle));
//        }
//        IntPtr hwnd;   //窗口句柄
//        IntPtr process;//进程句柄
//        IntPtr pointer;
//        IntPtr headerhwnd; //listview控件的列头句柄

//        private void read(object sender, EventArgs e)
//        {
//            int rows, cols;  //listview控件中的行列数
//            uint processId; //进程pid  

//            IntPtr rootHwnd = FindWindow("TaskManagerWindow", "任务管理器");
//            rootHwnd = FindWindowEx(rootHwnd, IntPtr.Zero, "NativeHWNDHost", null);
//            rootHwnd = FindWindowEx(rootHwnd, IntPtr.Zero, "DirectUIHWND", null);
//            IntPtr vHandle = FindWindowEx(rootHwnd, IntPtr.Zero, "CtrlNotifySink", null);

//            IntPtr lvHwnd = FindWindowEx(vHandle, IntPtr.Zero, "SysListView32", null);
//            while (lvHwnd == IntPtr.Zero)
//            {
//                vHandle = FindWindowEx(rootHwnd, vHandle, "CtrlNotifySink", null);
//                lvHwnd = FindWindowEx(vHandle, IntPtr.Zero, "SysListView32", null);
//            }
//            hwnd = lvHwnd;
//            //hwnd = (IntPtr)0x00020C22;
//            headerhwnd = (IntPtr)SendMessage(hwnd, LVM_GETHEADER, 0, 0);//listview的列头句柄

//            rows = ListView_GetItemCount(hwnd);//总行数，即进程的数量
//            cols = ListViewColumnCount(hwnd);//列表列数
//            GetWindowThreadProcessId(hwnd, out processId);

//            //打开并插入进程
//            process = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, processId);
//            //申请代码的内存区,返回申请到的虚拟内存首地址
//            pointer = VirtualAllocEx(process, IntPtr.Zero, 4096, MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
//            string[,] tempStr;//二维数组
//            string[] temp = new string[cols];

//            tempStr = GetListViewItmeValue(rows, cols);//将要读取的其他程序中的ListView控件中的文本内容保存到二维数组中
//            ListView listView1 = new ListView();
//            listView1.Items.Clear();//清空LV控件信息
//            //输出数组中保存的其他程序的LV控件信息
//            for (int i = 0; i < rows; i++)
//            {
//                for (int j = 0; j < cols; j++)
//                {
//                    temp[j] = tempStr[i, j];
//                }
//                ListViewItem lvi = new ListViewItem(temp);
//                listView1.Items.Add(lvi);
//            }
//            temp = GetListViewItmeValue(cols);
//        }

//        /// <summary>
//        /// 从内存中读取指定的LV控件的文本内容
//        /// </summary>
//        /// <param name="rows">要读取的LV控件的行数</param>
//        /// <param name="cols">要读取的LV控件的列数</param>
//        /// <returns>取得的LV控件信息</returns>
//        private string[,] GetListViewItmeValue(int rows, int cols)
//        {
//            string[,] tempStr = new string[rows, cols];//二维数组:保存LV控件的文本信息
//            bool type = Environment.Is64BitOperatingSystem;
//            for (int i = 0; i < rows; i++)
//            {
//                for (int j = 0; j < cols; j++)
//                {
//                    byte[] vBuffer = new byte[1024];//定义一个临时缓冲区
//                    LVITEM[] vItem = new LVITEM[1];
//                    vItem[0].mask = LVIF_TEXT;//说明pszText是有效的
//                    vItem[0].iItem = i;     //行号
//                    vItem[0].iSubItem = j;  //列号
//                    vItem[0].cchTextMax = vBuffer.Length;//所能存储的最大的文本为256字节
//                    if (type)
//                    {
//                        vItem[0].pszText = (IntPtr)(pointer.ToInt64() + Marshal.SizeOf(typeof(LVITEM)));
//                    }
//                    else
//                    {
//                        vItem[0].pszText = (IntPtr)(pointer + Marshal.SizeOf(typeof(LVITEM)));
//                    }
//                    uint vNumberOfBytesRead = 0;

//                    //把数据写到vItem中
//                    //pointer为申请到的内存的首地址
//                    //UnsafeAddrOfPinnedArrayElement:获取指定数组中指定索引处的元素的地址
//                    WriteProcessMemory(process, pointer, Marshal.UnsafeAddrOfPinnedArrayElement(vItem, 0), Marshal.SizeOf(typeof(LVITEM)), ref vNumberOfBytesRead);

//                    //发送LVM_GETITEMW消息给hwnd,将返回的结果写入pointer指向的内存空间
//                    User.SendMessage(hwnd, LVM_GETITEMW, i, pointer);

//                    //从pointer指向的内存地址开始读取数据,写入缓冲区vBuffer中
//                    ReadProcessMemory(process, (pointer + Marshal.SizeOf(typeof(LVITEM))), Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0), vBuffer.Length, ref vNumberOfBytesRead);

//                    string vText = Encoding.Unicode.GetString(vBuffer, 0, (int)vNumberOfBytesRead);
//                    vText = vText.Substring(0, vText.IndexOf('\0'));
//                    vBuffer = null;
//                    tempStr[i, j] = vText;
//                }
//            }
//            //VirtualFreeEx(process, pointer, 0, MEM_RELEASE);//在其它进程中释放申请的虚拟内存空间,MEM_RELEASE方式很彻底,完全回收
//            //CloseHandle(process);//关闭打开的进程对象
//            return tempStr;
//        }
//        /// <summary>
//        /// 从内存中读取指定的LV控件的文本内容
//        /// </summary>
//        /// <param name="rows">要读取的LV控件的行数</param>
//        /// <param name="cols">要读取的LV控件的列数</param>
//        /// <returns>取得的LV控件信息</returns>
//        private string[] GetListViewItmeValue(int cols)
//        {
//            string[] tempStr = new string[cols];//二维数组:保存LV控件的文本信息
//            bool type = Environment.Is64BitOperatingSystem;
//            for (int i = 0; i < cols; i++)
//            {
//                byte[] vBuffer = new byte[1024];//定义一个临时缓冲区
//                LVCOLUMNW[] vItem = new LVCOLUMNW[1];
//                vItem[0].mask = LVIF_TEXT;//说明pszText是有效的
//                vItem[0].cchTextMax = vBuffer.Length;//所能存储的最大的文本为256字节
//                if (type)
//                {
//                    vItem[0].pszText = (IntPtr)(pointer.ToInt64() + Marshal.SizeOf(typeof(LVCOLUMNW)));
//                }
//                else
//                {
//                    vItem[0].pszText = (IntPtr)(pointer + Marshal.SizeOf(typeof(LVCOLUMNW)));
//                }
//                uint vNumberOfBytesRead = 0;

//                //把数据写到vItem中
//                //pointer为申请到的内存的首地址
//                //UnsafeAddrOfPinnedArrayElement:获取指定数组中指定索引处的元素的地址
//                WriteProcessMemory(process, pointer, Marshal.UnsafeAddrOfPinnedArrayElement(vItem, 0), Marshal.SizeOf(typeof(LVCOLUMNW)), ref vNumberOfBytesRead);

//                //发送LVM_GETITEMW消息给hwnd,将返回的结果写入pointer指向的内存空间
//                User.SendMessage(headerhwnd, HDM_GETITEMW, i, pointer);

//                //从pointer指向的内存地址开始读取数据,写入缓冲区vBuffer中
//                ReadProcessMemory(process, (pointer + Marshal.SizeOf(typeof(LVCOLUMNW))), Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0), vBuffer.Length, ref vNumberOfBytesRead);

//                string vText = Encoding.Unicode.GetString(vBuffer, 0, (int)vNumberOfBytesRead);
//                //vText = vText.Substring(0, vText.IndexOf('\0'));
//                vBuffer = null;
//                tempStr[i] = vText;
//            }
//            VirtualFreeEx(process, pointer, 0, MEM_RELEASE);//在其它进程中释放申请的虚拟内存空间,MEM_RELEASE方式很彻底,完全回收
//            CloseHandle(process);//关闭打开的进程对象
//            return tempStr;
//        }
//    }

//}
