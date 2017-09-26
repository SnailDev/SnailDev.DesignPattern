using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 奇瑞工厂类
    /// </summary>
    public class CheryFactory : CarFactory
    {
        /// <summary>
        /// 生产奇瑞汽车
        /// </summary>
        /// <returns></returns>
        public override Car CreateCar()
        {
            return new CheryCar();
        }
    }
}
