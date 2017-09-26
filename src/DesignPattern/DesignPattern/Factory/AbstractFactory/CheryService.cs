using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 奇瑞售后服务
    /// </summary>
    public class CheryService : CustomerService
    {
        public override void Print()
        {
            Console.WriteLine("我是奇瑞售后服务");
        }
    }
}
