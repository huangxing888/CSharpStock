﻿using System;
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
using Services;
using Win32;

namespace CSharpStock
{
    public partial class Form1 : Form
    {
        IntPtr main;
        public Form1()
        {
            InitializeComponent();
            main = Common.GetIntPtrByProcess("xiadan");
        }

        public struct WindowInfo
        {
            public IntPtr hWnd;
            public string szWindowName;
            public string szClassName;
            public long DlgCtrlID;
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
                User.GetClassName((IntPtr)hWnd, wnd.szClassName, sb.Capacity);
                wnd.szClassName = sb.ToString();

                wnd.DlgCtrlID = User.GetDlgCtrlID((IntPtr)hWnd);

                //add it into list 
                wndList.Add(wnd);
                return true;
            }, 0);
            return wndList;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            User.PostMessage(main, 256, User.VK_F1, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User.PostMessage(main, 256, User.VK_F2, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User.PostMessage(main, 256, User.VK_F3, 2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User.PostMessage(main, 256, User.VK_F4, 2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Common.Click(Common.GetIntPtrByControlID(main, "00000000.0000E900.0000E901.00000000.00008016"));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show( StockService.getStock(main)[0].code);
            //main = Common.GetIntPtrByProcess("xiadan");
            //IntPtr treePtr = Common.GetIntPtrByControlID(main, "00000000.0000E900.0000E900.00000081.000000C8.00000081");

            //SysTreeView32 tree = new SysTreeView32(treePtr);
            //SysTreeView32_Item i = tree.FirstItem;
            //while(i!=null)
            //{
            //    richTextBox1.AppendText(i.text + "\n");
            //    i = i.NextItem;
            //}
        }
        
    }
}
