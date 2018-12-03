using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.THS
{
    public class MyAsset
    {
        /// <summary>
        /// 可用金额
        /// </summary>
        public decimal availableMoney { get; set; }
        /// <summary>
        /// 冻结金额
        /// </summary>
        public decimal moratoriumMoney { get; set; }
        /// <summary>
        /// 股票市值
        /// </summary>
        public decimal stockMoney { get; set; }
        /// <summary>
        /// 总资产
        /// </summary>
        public decimal allAsset { get; set; }
        /// <summary>
        /// 持仓列表
        /// </summary>
        public List<StockModel> stockList { get; set; }
    }
}
