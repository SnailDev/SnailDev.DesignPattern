using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 兰博基尼
    /// </summary>
    public class LamboCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("我的品牌是兰博基尼");
        }
    }
}
