using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class ConcretePrototypeDeepClone : ICloneable
    {
        public CheryCar SmallCar { get; set; }

        public object Clone()
        {
            ConcretePrototypeDeepClone copy = (ConcretePrototypeDeepClone)this.MemberwiseClone();
            CheryCar newSmallCar = new CheryCar();
            copy.SmallCar = newSmallCar;
            return copy;
        }
    }
}
