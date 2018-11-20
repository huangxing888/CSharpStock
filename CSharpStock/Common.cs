using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
