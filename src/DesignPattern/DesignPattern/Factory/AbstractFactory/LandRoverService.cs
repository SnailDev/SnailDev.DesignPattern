using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 路虎售后服务
    /// </summary>
    public class LandRoverService : CustomerService
    {
        public override void Print()
        {
            Console.WriteLine("我是路虎售后服务");
        }
    }
}
