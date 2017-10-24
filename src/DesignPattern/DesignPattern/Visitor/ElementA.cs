using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Visitor
{
    /// <summary>
    /// 元素A
    /// </summary>
    public class ElementA : Element
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Print()
        {
            Console.WriteLine("我是元素A");
        }
    }
}
