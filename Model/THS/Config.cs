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
        public static string ApplicationUrl { get { return @"D:\Program Files\同花顺v8\xiadan#stock.exe"; } }
        /// <summary>
        /// 程序名称 xiadan
        /// </summary>
        public static string ApplicationName { get { return "xiadan#stock"; } }
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
        public static string Password { get { return "826724"; } }
        /// <summary>
        /// 主窗体句柄
        /// </summary>
        public static IntPtr MainWindow { get; set; }
        #region 登录界面
        /// <summary>
        /// 登录界面密码输入框
        /// </summary>
        public static string LoginCtrlPassword { get { return ".00000000.000003F4"; } }
        /// <summary>
        /// 登录界面登录按钮
        /// </summary>
        public static string LoginCtrlLogon { get { return ".00000000.000003EE"; } }
        #endregion
        /// <summary>
        /// 菜单树
        /// </summary>
        public static string Menu { get { return ".00000000.0000E900.0000E900.00000081.000000C8.00000081"; } }
        /// <summary>
        /// 精简模式按钮
        /// </summary>
        public static string MainStatus { get { return ".0000E800.00000000.0000802C"; } }

        #region 菜单树
        /// <summary>
        /// 菜单项：买入
        /// </summary>
        public static string MenuBuy { get { return "买入[F1]"; } }
        /// <summary>
        /// 菜单项：卖出
        /// </summary>
        public static string MenuSell { get { return "卖出[F2]"; } }
        /// <summary>
        /// 菜单项：撤单
        /// </summary>
        public static string MenuRevert { get { return "撤单[F3]"; } }
        /// <summary>
        /// 菜单项：查询持仓
        /// </summary>
        public static string MenuStock { get { return "查询[F4].资金股票"; } }
        #endregion
        #region 快捷键
        public static int KeyBuy { get { return User.VK_F1; } }
        public static int KeySell { get { return User.VK_F2; } }
        public static int KeyRevert { get { return User.VK_F3; } }
        public static int KeyStock { get { return User.VK_F4; } }
        #endregion
        #region 买入界面控件
        /// <summary>
        /// 买入证券代码
        /// </summary>
        public static string BuyCtrlCode { get { return ".00000000.0000E900.0000E901.00000408"; } }
        /// <summary>
        /// 买入价格
        /// </summary>
        public static string BuyCtrlPrice { get { return ".00000000.0000E900.0000E901.00000409"; } }
        /// <summary>
        /// 买入数量
        /// </summary>
        public static string BuyCtrlCount { get { return ".00000000.0000E900.0000E901.0000040A"; } }
        /// <summary>
        /// 买入按钮
        /// </summary>
        public static string BuyCtrlBuyButton { get { return ".00000000.0000E900.0000E901.000003EE"; } }
        /// <summary>
        /// 弹框确认按钮
        /// </summary>
        public static string BuyCtrlConfirmButton { get { return ".00000006"; } }
        /// <summary>
        /// 弹框取消按钮
        /// </summary>
        public static string BuyCtrlCancelButton { get { return ".00000007"; } }
        /// <summary>
        /// 买入界面持仓列表
        /// </summary>
        public static string BuyCtrlGrid { get { return ".00000000.0000E900.0000E901.00000417.000000C8.00000417"; } }
        /// <summary>
        /// 买入界面刷新按钮
        /// </summary>
        public static string BuyCtrlRefresh { get { return ".00000000.0000E900.0000E901.00000000.00008016"; } }
        #endregion
        #region 卖出界面控件
        /// <summary>
        /// 卖出证券代码
        /// </summary>
        public static string SellCtrlCode { get { return ".00000000.0000E900.0000E901.00000408"; } }
        /// <summary>
        /// 卖出价格
        /// </summary>
        public static string SellCtrlPrice { get { return ".00000000.0000E900.0000E901.00000409"; } }
        /// <summary>
        /// 卖出数量
        /// </summary>
        public static string SellCtrlCount { get { return ".00000000.0000E900.0000E901.0000040A"; } }
        /// <summary>
        /// 卖出按钮
        /// </summary>
        public static string SellCtrlBuyButton { get { return ".00000000.0000E900.0000E901.000003EE"; } }
        /// <summary>
        /// 弹框确认按钮
        /// </summary>
        public static string SellCtrlConfirmButton { get { return ".00000006"; } }
        /// <summary>
        /// 弹框取消按钮
        /// </summary>
        public static string SellCtrlCancelButton { get { return ".00000007"; } }
        /// <summary>
        /// 卖出界面持仓列表
        /// </summary>
        public static string SellCtrlGrid { get { return ".00000000.0000E900.0000E901.00000417.000000C8.00000417"; } }
        #endregion
        #region 撤单界面控件

        #endregion
        #region 持仓界面控件
        /// <summary>
        /// 可用金额
        /// </summary>
        public static string StockCtrlAvaliableMoney { get { return ".00000000.0000E900.0000E901.00000000.000003F8"; } }
        /// <summary>
        /// 冻结金额
        /// </summary>
        public static string StockCtrlMoratoriumMoney { get { return ".00000000.0000E900.0000E901.00000000.000003F5"; } }
        /// <summary>
        /// 股票市值
        /// </summary>
        public static string StockCtrlStockMoney { get { return ".00000000.0000E900.0000E901.00000000.000003F6"; } }
        /// <summary>
        /// 总资产
        /// </summary>
        public static string StockCtrlAllAsset { get { return ".00000000.0000E900.0000E901.00000000.000003F7"; } }
        /// <summary>
        /// 持仓刷新按钮
        /// </summary>
        public static string StockCtrlRefresh { get { return ".00000000.0000E900.0000E901.00000000.00008016"; } }
        public static string StockCtrlGrid { get { return ".00000000.0000E900.0000E901.00000417.000000C8.00000417"; } }
        #endregion
    }
}
