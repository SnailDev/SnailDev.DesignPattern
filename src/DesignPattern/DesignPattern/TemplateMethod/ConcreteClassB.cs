using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.TemplateMethod
{
    /// <summary>
    /// 具体类，实现了抽象类中的特定步骤
    /// </summary>
    public class ConcreteClassB : AbstractClass
    {
        /// <summary>
        /// 与ConcreteClassA中的实现逻辑不同
        /// </summary>
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("Implement operation 1 in Concreate class B.");
        }

        /// <summary>
        /// 与ConcreteClassA中的实现逻辑不同
        /// </summary>
        public override void PrimitiveOperation2()
        {
            Console.WriteLine("Implement operation 2 in Concreate class B.");
        }
    }
}
