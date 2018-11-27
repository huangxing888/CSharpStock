using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpStock;
using Win32;

namespace Model.THS
{
    public class Stock
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 股票名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 股票余额
        /// </summary>
        public int totalCount { get; set; }
        /// <summary>
        /// 可用余额
        /// </summary>
        public int available { get; set; }
        /// <summary>
        /// 冻结数量
        /// </summary>
        public int moratorium { get; set; }
        /// <summary>
        /// 盈亏
        /// </summary>
        public decimal gain_loss { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public decimal costPrice { get; set; }
        /// <summary>
        /// 盈亏比例
        /// </summary>
        public decimal ratio { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal marketPrice { get; set; }
        /// <summary>
        /// 总市值
        /// </summary>
        public decimal marketValue { get; set; }
        /// <summary>
        /// 成本金额
        /// </summary>
        public decimal costMoney { get; set; }
        /// <summary>
        /// 市场名称
        /// </summary>
        public string marketName { get; set; }
        /// <summary>
        /// 股东账户
        /// </summary>
        public string stockAccount { get; set; }
        /// <summary>
        /// 实际数量
        /// </summary>
        public int actualCount { get; set; }
        /// <summary>
        /// 单位数量
        /// </summary>
        public int unitNum { get; set; }
    }
}
