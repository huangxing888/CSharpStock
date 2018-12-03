using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpStock;
using Model.THS;
using Win32;
using WinCtrl;

namespace Services.THS
{
    public class StockService
    {
        public static List<WindowInfo> windows = new List<WindowInfo>();

        public static SysTreeView32 menu;
        #region 持仓
        /// <summary>
        /// 选择持仓界面
        /// </summary>
        public static void SelectStockMenu()
        {
            InitWindow();
            InitMenu().Select(Config.MenuStock);
        }
        /// <summary>
        /// 刷新持仓
        /// </summary>
        public static void RefreshStock()
        {
            Common.GetWindows(Config.MainWindow, ref windows);
            Common.Click(Common.GetWindowByCtrlID(windows, Config.StockCtrlRefresh));
        }
        /// <summary>
        /// 获取当前持仓列表
        /// </summary>
        /// <returns></returns>
        public static List<StockModel> GetStock()
        {
            //Common.BringToFront(hwnd);
            SelectStockMenu();
            RefreshStock();
            string tmp = "stock";
            int reTryLimit = 0;
            while (!Clipboard.GetText().Contains("证券代码")&& !Clipboard.GetText().Equals(tmp))
            {
                tmp = Clipboard.GetText();
                Thread.Sleep(500);
                Common.Copy(Common.GetWindowByCtrlID(windows, Config.StockCtrlGrid));
                reTryLimit += 1;
                if (reTryLimit > 100)
                {
                    return new List<StockModel>();
                }
            }
            return GetStock(Clipboard.GetText());
        }
        /// <summary>
        /// 获取持仓界面数据
        /// </summary>
        /// <returns></returns>
        public static MyAsset GetMyAsset()
        {
            MyAsset result = new MyAsset();
            result.stockList = GetStock();
            result.availableMoney = decimal.Parse(Common.GetTitle(Common.GetWindowByCtrlID(windows, Config.StockCtrlAvaliableMoney)));
            result.moratoriumMoney = decimal.Parse(Common.GetTitle(Common.GetWindowByCtrlID(windows, Config.StockCtrlMoratoriumMoney)));
            result.stockMoney = decimal.Parse(Common.GetTitle(Common.GetWindowByCtrlID(windows, Config.StockCtrlStockMoney)));
            result.allAsset = decimal.Parse(Common.GetTitle(Common.GetWindowByCtrlID(windows, Config.StockCtrlAllAsset)));
            return result;
        }
        /// <summary>
        /// 根据复制的文本转换成持仓数据实体
        /// </summary>
        /// <param name="clipStr"></param>
        /// <returns></returns>
        public static List<StockModel> GetStock(string clipStr)
        {
            if (string.IsNullOrEmpty(clipStr))
                return null;
            List<StockModel> result = new List<StockModel>();
            string[] tmp = clipStr.Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (tmp.Length > 1)
            {
                string[] titles = tmp[0].Split(new string[1] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < tmp.Length; i++)
                {
                    string[] items = tmp[i].Split(new string[1] { "\t" }, StringSplitOptions.None);
                    StockModel sItem = new StockModel();
                    for (int j = 0; j < titles.Length; j++)
                    {
                        switch (titles[j])
                        {
                            case "证券代码": sItem.code = items[j]; break;
                            case "证券名称": sItem.name = items[j]; break;
                            case "股票余额": sItem.totalCount = int.Parse(items[j]); break;
                            case "可用余额": sItem.available = int.Parse(items[j]); break;
                            case "冻结数量": sItem.moratorium = int.Parse(items[j]); break;
                            case "盈亏": sItem.gain_loss = decimal.Parse(items[j]); break;
                            case "成本价": sItem.costPrice = decimal.Parse(items[j]); break;
                            case "盈亏比例(%)": sItem.ratio = decimal.Parse(items[j]); break;
                            case "市价": sItem.marketPrice = decimal.Parse(items[j]); break;
                            case "市值": sItem.marketValue = decimal.Parse(items[j]); break;
                            case "成本金额": sItem.costMoney = decimal.Parse(items[j]); break;
                            case "交易市场": sItem.marketName = items[j]; break;
                            case "股东帐户": sItem.stockAccount = items[j]; break;
                            case "实际数量": sItem.actualCount = int.Parse(items[j]); break;
                            case "单位数量": sItem.unitNum = int.Parse(items[j]); break;
                            default: break;
                        }
                    }
                    result.Add(sItem);
                }
            }
            return result;
        }
        #endregion

        #region 买入下单
        /// <summary>
        /// 选择买入界面
        /// </summary>
        public static void SelectBuyMenu()
        {
            InitWindow();
            InitMenu().Select(Config.MenuBuy);
        }

        public static void BuyStock(string code,decimal price,int count)
        {
            SelectBuyMenu();
            IntPtr codeIntptr = Common.GetWindowByCtrlID(windows, Config.BuyCtrlCode);
            while (codeIntptr == IntPtr.Zero)
            {
                Thread.Sleep(10);
                Common.GetWindows(Config.MainWindow, ref windows);
                codeIntptr = Common.GetWindowByCtrlID(windows, Config.BuyCtrlCode);
            }
            Common.SetTitle(Common.GetWindowByCtrlID(windows, Config.BuyCtrlPrice), price.ToString());
            Common.SetTitle(Common.GetWindowByCtrlID(windows, Config.BuyCtrlCount), count.ToString());
            Common.SetTitle(Common.GetWindowByCtrlID(windows, Config.BuyCtrlCode), code);
        }
        #endregion

        #region 卖出下单
        public static void SelectSellMenu()
        {
            InitWindow();
            InitMenu().Select(Config.MenuSell);
        }
        public static void SellStock(string code, decimal price, int count)
        {
            SelectSellMenu();
            IntPtr codeIntptr = Common.GetWindowByCtrlID(windows, Config.SellCtrlCode);
            while (codeIntptr == IntPtr.Zero)
            {
                Thread.Sleep(10);
                Common.GetWindows(Config.MainWindow, ref windows);
                codeIntptr = Common.GetWindowByCtrlID(windows, Config.SellCtrlCode);
            }
            Common.SetTitle(Common.GetWindowByCtrlID(windows, Config.SellCtrlPrice), price.ToString());
            Common.SetTitle(Common.GetWindowByCtrlID(windows, Config.SellCtrlCount), count.ToString());
            Common.SetTitle(Common.GetWindowByCtrlID(windows, Config.SellCtrlCode), code);
        }
        #endregion

        #region 撤单

        public static void SelectRevertMenu()
        {
            Common.GetWindows(Config.MainWindow, ref windows);
            InitMenu().Select(Config.MenuRevert);
        }
        #endregion

        #region 登录，初始化
        /// <summary>
        /// 自动启动程序并登录
        /// </summary>
        /// <returns></returns>
        public static IntPtr AutoLogin()
        {
            Process.Start(Config.ApplicationUrl);
            Common.GetWindows(IntPtr.Zero, ref windows);
            IntPtr password = Common.GetWindowByCtrlID(windows, Config.LoginCtrlPassword);
            while (password == IntPtr.Zero)
            {
                Common.GetWindows(IntPtr.Zero, ref windows);
                password = Common.GetWindowByCtrlID(windows, Config.LoginCtrlPassword);
            }
            Common.SetTitle(password, Config.Password);
            Common.Click(Common.GetWindowByCtrlID(windows, Config.LoginCtrlLogon));
            Config.MainWindow = Common.GetIntPtrByProcess(Config.ApplicationName);
            while (Config.MainWindow == IntPtr.Zero)
            {
                Thread.Sleep(500);
                Config.MainWindow = Common.GetIntPtrByProcess(Config.ApplicationName);
            }
            return Config.MainWindow;
        }
        /// <summary>
        /// 初始化窗体控件，强制转到精简模式
        /// </summary>
        public static void InitWindow()
        {
            Config.MainWindow = Common.GetIntPtrByProcess(Config.ApplicationName);
            if (Config.MainWindow == IntPtr.Zero)
            {
                Config.MainWindow = AutoLogin();
            }
            windows = new List<WindowInfo>();
            Common.GetWindows(Config.MainWindow, ref windows);
            IntPtr status = Common.GetWindowByCtrlID(windows, Config.MainStatus);
            if (Common.IsWindowVisible(status))
            {
                Common.Click(status);
            }
            Config.MainWindow = Common.GetIntPtrByProcess(Config.ApplicationName);
            Common.GetWindows(Config.MainWindow, ref windows);
        }
        /// <summary>
        /// 初始化菜单
        /// </summary>
        /// <returns></returns>
        public static SysTreeView32 InitMenu()
        {
            Common.GetWindows(Config.MainWindow, ref windows);
            menu = new SysTreeView32(Common.GetWindowByCtrlID(windows, Config.Menu));
            return menu;
        }
        #endregion
    }
}
