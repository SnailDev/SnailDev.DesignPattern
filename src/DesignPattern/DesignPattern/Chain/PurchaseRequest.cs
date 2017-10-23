using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Chain
{
    /// <summary>
    /// 采购请求
    /// </summary>
    public class PurchaseRequest
    {
        public double Amount { get; set; }

        public string ProductName { get; set; }

        public PurchaseRequest(string productName, double amount)
        {
            this.ProductName = productName;
            this.Amount = amount;
        }
    }
}
