using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Strategy
{
    /// <summary>
    /// 网口
    /// </summary>
    public class Lan : ICommunication
    {
        public bool Send(object data)
        {
            Console.WriteLine("通过网口发送一个数据的算法");
            return true;
        }
    }
}
