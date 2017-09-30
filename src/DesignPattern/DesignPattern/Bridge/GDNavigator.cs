using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Bridge
{
    /// <summary>
    /// 高德导航
    /// </summary>
    public class GDNavigator : INavigator
    {
        public void Work()
        {
            Console.WriteLine("我是高德导航。");
        }
    }
}
