using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 汽车抽象工厂
    /// </summary>
    public abstract class CarFactory
    {
        /// <summary>
        /// 生产汽车
        /// </summary>
        /// <returns></returns>
        public abstract Car CreateCar();
    }
}
