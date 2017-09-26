using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 路虎工厂
    /// </summary>
    public class LandRoverFactory : CarFactory
    {
        /// <summary>
        /// 生产汽车
        /// </summary>
        /// <returns></returns>
        public override Car CreateCar()
        {
            return new LandRoverCar();
        }
    }
}
