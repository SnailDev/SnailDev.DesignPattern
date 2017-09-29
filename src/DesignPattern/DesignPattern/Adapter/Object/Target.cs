using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 适配器模式中的目标(Target)角色
    /// </summary>
    public class Target
    {
        /// <summary>
        /// 使用virtual修饰以便子类可以重写
        /// </summary>
        public virtual void Request()
        {
            Console.WriteLine("This is a common request");
        }
    }
}
