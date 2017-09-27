using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 建造者B
    /// </summary>
    public class BuilderB : Builder
    {
        BigCar car = new BigCar();
        public override void AssemblyEngines()
        {
            car.AddPart("enginesB");
        }

        public override void AssemblyTransmissions()
        {
            car.AddPart("transmissionsB");
        }

        public override BigCar GetCar()
        {
            return car;
        }
    }
}
