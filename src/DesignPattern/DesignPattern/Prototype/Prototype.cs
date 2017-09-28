using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 原型抽象类
    /// </summary>
    public abstract class Prototype
    {
        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public abstract Prototype Clone();
    }
}
