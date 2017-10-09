using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator
{
    public class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage)
        {
            this.Beverage = beverage;
        }

        public override double Cost()
        {
            return Beverage.Cost() + 0.2;
        }

        public override string GetDescription()
        {
            return Beverage.GetDescription() + "，加了牛奶";
        }
    }
}
