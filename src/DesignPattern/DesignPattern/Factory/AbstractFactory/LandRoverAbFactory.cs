using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class LandRoverAbFactory : AbstractFactory
    {
        public override Car CreateCar()
        {
            return new LandRoverCar();
        }

        public override CustomerService Service()
        {
            return new LandRoverService();
        }
    }
}
