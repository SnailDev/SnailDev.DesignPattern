using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class AbstractFactory
    {
        /// <summary>
        /// 生产汽车
        /// </summary>
        /// <returns></returns>
        public abstract Car CreateCar();

        /// <summary>
        /// 提供售后服务
        /// </summary>
        /// <returns></returns>
        public abstract CustomerService Service();
    }
}
