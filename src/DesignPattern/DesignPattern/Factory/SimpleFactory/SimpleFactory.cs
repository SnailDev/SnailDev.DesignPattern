using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 简单工厂
    /// </summary>
    public class SimpleFactory
    {
        public static Car GetCar(CarType type)
        {
            switch (type)
            {
                case CarType.Chery:
                    return new CheryCar();
                case CarType.LandRover:
                    return new LandRoverCar();
                case CarType.Lambo:
                    return new LamboCar();
                default:
                    throw new Exception("未找到相应品牌汽车");
            }
        }
    }
}
