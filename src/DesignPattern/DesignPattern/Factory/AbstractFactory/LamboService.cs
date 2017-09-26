using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 兰博基尼售后服务
    /// </summary>
    public class LamboService : CustomerService
    {
        public override void Print()
        {
            Console.WriteLine("我是兰博基尼售后服务");
        }
    }
}
