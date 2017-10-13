using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Proxy
{
    /// <summary>
    /// 线下实体商店
    /// </summary>
    public class RealShop : Shop
    {
        public override void Sell()
        {
            Console.WriteLine("卖了一份黄焖鸡米饭");
        }
    }
}
