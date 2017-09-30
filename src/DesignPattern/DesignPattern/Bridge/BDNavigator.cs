using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Bridge
{
    /// <summary>
    /// 北斗导航
    /// </summary>
    public class BDNavigator : INavigator
    {
        public void Work()
        {
            Console.WriteLine("我是北斗导航。");
        }
    }
}
