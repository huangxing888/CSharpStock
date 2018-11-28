using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Win32;

namespace WinCtrl
{
    public class SysTreeView32
    {
        #region 对象封装
        public SysTreeView32(IntPtr treeHwnd)
        {
            hwnd = treeHwnd;
        }
        public IntPtr hwnd { get; }
        public int ItemCount
        {
            get
            {
                return User.SendMessage(hwnd, TVM_GETCOUNT, 0, IntPtr.Zero);
            }
        }
        public SysTreeView32_Item FirstItem
        {
            get
            {
                return new SysTreeView32_Item(hwnd, (IntPtr)User.SendMessage(hwnd, TVM_GETNEXTITEM, TVGN_ROOT, IntPtr.Zero));
            }
        }
        public List<SysTreeView32_Item> ChildItems
        {
            get
            {
                SysTreeView32_Item cItem = FirstItem;
                if (cItem.itemHwnd == IntPtr.Zero)
                {
                    return new List<SysTreeView32_Item>();
                }
                else
                {
                    List<SysTreeView32_Item> result = new List<SysTreeView32_Item>();
                    while (cItem.itemHwnd!=IntPtr.Zero)
                    {
                        result.Add(cItem);
                        cItem = cItem.NextSiblingItem;
                    }
                    return result;
                }
            }
        }
        #endregion

        #region 常量定义
        public const int TV_FIRST = 0x1100;
        public const int TVM_GETCOUNT = TV_FIRST + 5;
        public const int TVM_GETNEXTITEM = TV_FIRST + 10;
        public const int TVM_GETITEMA = TV_FIRST + 12;
        public const int TVM_GETITEMW = TV_FIRST + 62;
        public const int TVM_SELECTITEM = 0x0000110b;
        public const int TVGN_ROOT = 0x0000;
        public const int TVGN_NEXT = 0x0001;
        public const int TVGN_PREVIOUS = 0x0002;
        public const int TVGN_PARENT = 0x0003;
        public const int TVGN_CHILD = 0x0004;
        public const int TVGN_FIRSTVISIBLE = 0x0005;
        public const int TVGN_NEXTVISIBLE = 0x0006;
        public const int TVGN_PREVIOUSVISIBLE = 0x0007;
        public const int TVGN_DROPHILITE = 0x0008;
        public const int TVGN_CARET = 0x0009;
        public const int TVGN_LASTVISIBLE = 0x000A;

        public const int TVIF_TEXT = 0x0001;
        public const int TVIF_IMAGE = 0x0002;
        public const int TVIF_PARAM = 0x0004;
        public const int TVIF_STATE = 0x0008;
        public const int TVIF_HANDLE = 0x0010;
        public const int TVIF_SELECTEDIMAGE = 0x0020;
        public const int TVIF_CHILDREN = 0x0040;
        public const int TVIF_INTEGRAL = 0x0080;
        #endregion

        #region 结构体
        [StructLayout(LayoutKind.Sequential)]
        public struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
            public IntPtr HTreeItem;
        }
        #endregion

    }

    public class SysTreeView32_Item
    {
        public SysTreeView32_Item(IntPtr treeHwnd, IntPtr hwnd)
        {
            this.treeHwnd = treeHwnd;
            this.itemHwnd = hwnd;
            this.text = GetTreeItemText(treeHwnd, hwnd);
        }
        public IntPtr treeHwnd { get; set; }
        public IntPtr itemHwnd { get; set; }
        public string text { get; set; }
        public int ChildCount
        {
            get
            {
                return this.ChildItems.Count;
            }
        }
        public SysTreeView32_Item FirstChild
        {
            get
            {
                return new SysTreeView32_Item(treeHwnd, (IntPtr)User.SendMessage(treeHwnd, SysTreeView32.TVM_GETNEXTITEM, SysTreeView32.TVGN_CHILD, itemHwnd));
            }
        }
        public List<SysTreeView32_Item> ChildItems {
            get
            {
                SysTreeView32_Item cItem = FirstChild;
                if (cItem.itemHwnd == IntPtr.Zero)
                {
                    return new List<SysTreeView32_Item>();
                }
                else
                {
                    List<SysTreeView32_Item> result = new List<SysTreeView32_Item>();
                    while (cItem.itemHwnd != IntPtr.Zero)
                    {
                        result.Add(cItem);
                        cItem = cItem.NextSiblingItem;
                    }
                    return result;
                }
            }
        }
        public SysTreeView32_Item ParentItem
        {
            get
            {
                return new SysTreeView32_Item(treeHwnd, (IntPtr)User.SendMessage(treeHwnd, SysTreeView32.TVM_GETNEXTITEM, SysTreeView32.TVGN_PARENT, itemHwnd));
            }
        }
        public SysTreeView32_Item NextSiblingItem
        {
            get
            {
                return new SysTreeView32_Item(treeHwnd, (IntPtr)User.SendMessage(treeHwnd, SysTreeView32.TVM_GETNEXTITEM, SysTreeView32.TVGN_NEXT, itemHwnd));
            }
        }

        public SysTreeView32_Item NextItem
        {
            get
            {
                SysTreeView32_Item nItem;
                if (treeHwnd == IntPtr.Zero || itemHwnd == IntPtr.Zero)
                    return null;
                nItem = FirstChild;
                if (nItem.itemHwnd != IntPtr.Zero)
                    return nItem;
                nItem = NextSiblingItem;
                if (nItem.itemHwnd != IntPtr.Zero)
                    return nItem;
                nItem = ParentItem.NextSiblingItem;
                if (nItem.itemHwnd != IntPtr.Zero)
                    return nItem;
                return null;
            }
        }
        public bool Select()
        {
            return SelectNode(this.treeHwnd, this.itemHwnd);
        }
        #region 句柄操作
        public bool SelectNode(IntPtr TreeViewHwnd, IntPtr ItemHwnd)
        {
            int result = User.SendMessage(TreeViewHwnd, SysTreeView32.TVM_SELECTITEM, SysTreeView32.TVGN_CARET, ItemHwnd);
            if (result == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string GetTreeItemText(IntPtr treePtr, IntPtr vTreeItem)
        {
            int vProcessId = 0;
            User.GetWindowThreadProcessId(treePtr, ref vProcessId);
            IntPtr vProcess = (IntPtr)Kernel.OpenProcess(Kernel.PROCESS_VM_OPERATION | Kernel.PROCESS_VM_READ | Kernel.PROCESS_VM_WRITE, 0, vProcessId);
            IntPtr vPointer = (IntPtr)Kernel.VirtualAllocEx(vProcess, IntPtr.Zero, 4096, Kernel.MEM_RESERVE | Kernel.MEM_COMMIT, Kernel.PAGE_READWRITE);
            try
            {
                byte[] vBuffer = new byte[256];
                SysTreeView32.TVITEM[] vItem = new SysTreeView32.TVITEM[1];
                vItem[0] = new SysTreeView32.TVITEM();
                vItem[0].mask = SysTreeView32.TVIF_TEXT;
                vItem[0].hItem = vTreeItem;
                vItem[0].pszText = (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(SysTreeView32.TVITEM)));
                vItem[0].cchTextMax = vBuffer.Length;
                int vNumberOfBytesRead = 0;
                Kernel.WriteProcessMemory(vProcess, vPointer,
                    Marshal.UnsafeAddrOfPinnedArrayElement(vItem, 0),
                    Marshal.SizeOf(typeof(SysTreeView32.TVITEM)), ref vNumberOfBytesRead);
                User.SendMessage(treePtr, SysTreeView32.TVM_GETITEMA, 0, vPointer);
                Kernel.ReadProcessMemory(vProcess,
                    (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(SysTreeView32.TVITEM))),
                    Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0),
                    vBuffer.Length, ref vNumberOfBytesRead);
                return Marshal.PtrToStringAnsi(
                    Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0));
            }
            finally
            {
                Kernel.VirtualFreeEx(vProcess, vPointer, 0, Kernel.MEM_RELEASE);
                Kernel.CloseHandle(vProcess);
            }
        } 
        #endregion
    }
}
