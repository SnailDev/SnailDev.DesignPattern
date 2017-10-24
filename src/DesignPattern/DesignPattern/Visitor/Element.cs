using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Visitor
{
    /// <summary>
    /// 抽象元素角色
    /// </summary>
    public abstract class Element
    {
        public abstract void Print();

        public abstract void Accept(IVisitor visitor);
    }
}
