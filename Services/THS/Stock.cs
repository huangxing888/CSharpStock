using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpStock;
using Model.THS;
using Win32;
using WinCtrl;
using static CSharpStock.Common;

namespace Services.THS
{
    public class StockService
    {
        public static List<WindowInfo> windows = new List<WindowInfo>();

        public static SysTreeView32 menu;
        
        public static void InitMenu()
        {
            menu = new SysTreeView32(windows.Where(p => p.DlgCtrlID == Config.Menu.ToLower()).FirstOrDefault().hWnd);
        }

        #region 持仓
        public static void SelectStockMenu()
        {
            Common.GetWindows(Config.MainWindow, "", ref windows);
            InitMenu();
            SysTreeView32_Item item = menu.ChildItems.Where(p => p.text == "查询[F4]").FirstOrDefault();
            item = item.ChildItems.Where(p=>p.text=="资金股票").FirstOrDefault();
            item.Select();
        }

        public static void RefreshStock()
        {
            Common.GetWindows(Config.MainWindow, "", ref windows);
            Common.Click(windows.Where(p => p.DlgCtrlID == Config.StockCtrlRefresh.ToLower()).FirstOrDefault().hWnd);
        }
        /// <summary>
        /// 获取当前持仓列表
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static List<Stock> GetStock(IntPtr hwnd)
        {
            //Common.BringToFront(hwnd);
            //Common.SendKeyWithCtrl(User.VK_KeyC);
            SelectStockMenu();
            Common.Copy(windows.Where(p => p.DlgCtrlID == Config.StockGrid.ToLower()).FirstOrDefault().hWnd);
            return GetStock(Clipboard.GetText());
        }
        /// <summary>
        /// 根据复制的文本转换成持仓数据实体
        /// </summary>
        /// <param name="clipStr"></param>
        /// <returns></returns>
        public static List<Stock> GetStock(string clipStr)
        {
            if (string.IsNullOrEmpty(clipStr))
                return null;
            List<Stock> result = new List<Stock>();
            string[] tmp = clipStr.Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (tmp.Length > 1)
            {
                string[] titles = tmp[0].Split(new string[1] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < tmp.Length; i++)
                {
                    string[] items = tmp[i].Split(new string[1] { "\t" }, StringSplitOptions.None);
                    Stock sItem = new Stock();
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

        #endregion

        #region 卖出下单

        #endregion

        #region 撤单

        #endregion

        #region 登录，初始化
        public static IntPtr GetMainHwnd()
        {
            return Common.GetIntPtrByProcess("xiadan");
        }
        #endregion
    }
}
