using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator
{
    public class HouseBlend : Beverage
    {
        public override double Cost()
        {
            return 2.3;
        }

        public override string GetDescription()
        {
            return "我是家庭混合咖啡";
        }
    }
}
