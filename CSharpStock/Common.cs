using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win32;

namespace CSharpStock
{
    public class Common
    {
        /// <summary>
        /// 根据进程名获取第一个有窗体的句柄
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public static IntPtr GetIntPtr(string processName)
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
        public static IntPtr getItem(IntPtr mainWindow, string id)
        {
            string[] ids = id.Split(".".ToArray());
            IntPtr result = mainWindow;
            for (int i = 0; i < ids.Length; i++)
            {
                result = (IntPtr)User.GetDlgItem(result, Convert.ToInt32(ids[i], 16));
            }
            return result;
        }
    }
}
