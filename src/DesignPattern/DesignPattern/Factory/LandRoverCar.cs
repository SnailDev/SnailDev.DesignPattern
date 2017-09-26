using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 路虎
    /// </summary>
    public class LandRoverCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("我的品牌路虎");
        }
    }
}
