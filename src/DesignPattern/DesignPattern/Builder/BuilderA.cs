using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 建造者A
    /// </summary>
    public class BuilderA : Builder
    {
        BigCar car = new BigCar();
        public override void AssemblyEngines()
        {
            car.AddPart("enginesA");
        }

        public override void AssemblyTransmissions()
        {
            car.AddPart("transmissionsA");
        }

        public override BigCar GetCar()
        {
            return car;
        }
    }
}
