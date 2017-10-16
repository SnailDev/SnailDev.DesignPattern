using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.TemplateMethod
{
    /// <summary>
    /// 抽象类
    /// </summary>
    public abstract class AbstractClass
    {
        // 一些抽象行为，放到子类去实现
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        /// <summary>
        /// 模板方法，给出了逻辑的骨架，而逻辑的组成是一些相应的抽象操作，它们推迟到子类去实现。
        /// </summary>
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("Done the method.");
        }
    }
}
