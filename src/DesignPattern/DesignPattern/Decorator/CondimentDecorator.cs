using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator
{
    /// <summary>
    /// 调料装饰者基类
    /// </summary>
    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage Beverage { get; set; }
    }
}
