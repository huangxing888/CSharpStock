using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win32;

namespace Model.THS
{
    public class Config
    {
        /// <summary>
        /// 应用路径 D:\Program Files\同花顺v8\xiadan.exe
        /// </summary>
        public static string ApplicationUrl { get; set; }
        /// <summary>
        /// 程序名称 xiadan
        /// </summary>
        public static string ApplicationName { get; set; }
        /// <summary>
        /// 标识名称 找到窗口后修改为指定的标识
        /// </summary>
        public static string ApplicationIdentity { get; set; }
        /// <summary>
        /// 证券账号
        /// </summary>
        public static string Account { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public static string Password { get; set; }
        /// <summary>
        /// 主窗体句柄
        /// </summary>
        public static IntPtr MainWindow { get; set; }

        #region 菜单树
        public static string MenuBuy { get { return ""; } }
        public static string MenuSell { get { return ""; } }
        public static string MenuRevert { get { return ""; } }
        public static string MenuStock { get { return ""; } }
        #endregion
        #region 快捷键
        public static int KeyBuy { get { return User.VK_F1; } }
        public static int KeySell { get { return User.VK_F2; } }
        public static int KeyRevert { get { return User.VK_F3; } }
        public static int KeyStock { get { return User.VK_F4; } }
        #endregion
        #region 买入界面控件
        public static string BuyCtrlCode { get { return "00000000.0000E900.0000E901.00000408"; } }
        public static string BuyCtrlPrice { get { return "00000000.0000E900.0000E901.00000409"; } }
        public static string BuyCtrlCount { get { return "00000000.0000E900.0000E901.0000040A"; } }
        public static string BuyCtrlBuyButton { get { return "00000000.0000E900.0000E901.000003EE"; } }
        public static string BuyCtrlConfirmButton { get { return "00000006"; } }
        public static string BuyCtrlCancelButton { get { return "00000007"; } }
        /// <summary>
        /// 买入界面刷新按钮
        /// </summary>
        public static string BuyCtrlRefresh { get { return "00000000.0000E900.0000E901.00000000.00008016"; } }
        #endregion
        #region 卖出界面控件

        public static string SellCtrlCode { get { return "00000000.0000E900.0000E901.00000408"; } }
        public static string SellCtrlPrice { get { return "00000000.0000E900.0000E901.00000409"; } }
        public static string SellCtrlCount { get { return "00000000.0000E900.0000E901.0000040A"; } }
        public static string SellCtrlBuyButton { get { return "00000000.0000E900.0000E901.000003EE"; } }
        public static string SellCtrlConfirmButton { get { return "00000006"; } }
        public static string SellCtrlCancelButton { get { return "00000007"; } }
        #endregion
        #region 撤单界面控件

        #endregion
        #region 持仓界面控件
        //public static string StockCtrlAvaliable { get { return "00000000.0000E900.FFFFFFFF.00000000.000003F8"; } }
        /// <summary>
        /// 持仓刷新按钮
        /// </summary>
        public static string StockCtrlRefresh { get { return "00000000.0000E900.0000E901.00000000.00008016"; } }
        #endregion
    }
}
