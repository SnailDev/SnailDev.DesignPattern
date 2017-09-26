using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 奇瑞汽车
    /// </summary>
    public class CheryCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("我的品牌是奇瑞");
        }
    }
}
