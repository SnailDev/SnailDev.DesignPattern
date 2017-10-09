using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator
{
    /// <summary>
    /// 饮品
    /// </summary>
    public abstract class Beverage
    {
        /// <summary>
        /// 描述
        /// </summary>
        /// <returns></returns>
        public abstract string GetDescription();

        /// <summary>
        /// 定价
        /// </summary>
        /// <returns></returns>
        public abstract double Cost();
    }
}
