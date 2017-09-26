using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class LamboAbFactory : AbstractFactory
    {
        public override Car CreateCar()
        {
            return new LamboCar();
        }

        public override CustomerService Service()
        {
            return new LamboService();
        }
    }
}
