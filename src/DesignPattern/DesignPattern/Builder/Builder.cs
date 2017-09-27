using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 建造者抽象类
    /// </summary>
    public abstract class Builder
    {
        /// <summary>
        /// 组装引擎
        /// </summary>
        public abstract void AssemblyEngines();

        /// <summary>
        /// 组装传动系统
        /// </summary>
        public abstract void AssemblyTransmissions();

        /// <summary>
        /// 获取组装好的汽车
        /// </summary>
        /// <returns></returns>
        public abstract BigCar GetCar();
    }
}
