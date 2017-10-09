using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator
{
    public class DarkRoast : Beverage
    {
        public override double Cost()
        {
            return 2.5;
        }

        public override string GetDescription()
        {
            return "我是焦烤咖啡";
        }
    }
}
