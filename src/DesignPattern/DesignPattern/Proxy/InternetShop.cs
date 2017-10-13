using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Proxy
{
    /// <summary>
    /// 网上商店
    /// </summary>
    public class InternetShop : Shop
    {
        // 引用真实主题实例
        RealShop realShop;

        /// <summary>
        /// 通过代理类访问真实实体对象的方法
        /// </summary>
        public override void Sell()
        {
            if (realShop == null)
            {
                realShop = new RealShop();
            }

            this.PreSell();

            // 调用真实主题方法
            realShop.Sell();

            this.PostSell();
        }

        // 代理角色执行的一些操作
        public void PreSell()
        {
            // 商品上架
            Console.WriteLine("线上创建商店，上传商品列表");
        }

        // 代理角色执行的一些操作
        public void PostSell()
        {
            Console.WriteLine("等待外卖骑手送货");
        }
    }
}
