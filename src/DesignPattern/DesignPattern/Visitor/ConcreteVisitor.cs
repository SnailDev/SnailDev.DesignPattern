using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Visitor
{
    /// <summary>
    /// 具体访问者
    /// </summary>
    public class ConcreteVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            element.Print();
        }
    }
}
