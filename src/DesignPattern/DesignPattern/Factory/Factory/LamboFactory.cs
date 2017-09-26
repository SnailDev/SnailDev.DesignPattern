using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 兰博基尼工厂
    /// </summary>
    public class LamboFactory : CarFactory
    {
        /// <summary>
        /// 生产汽车
        /// </summary>
        /// <returns></returns>
        public override Car CreateCar()
        {
            return new LamboCar();
        }
    }
}
