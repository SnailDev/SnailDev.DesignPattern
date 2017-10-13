using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Proxy
{
    /// <summary>
    /// 抽象主题角色
    /// </summary>
    public abstract class Shop
    {
        /// <summary>
        /// 出售
        /// </summary>
        public abstract void Sell();
    }
}
