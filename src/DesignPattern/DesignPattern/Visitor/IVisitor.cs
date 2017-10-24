using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Visitor
{
    /// <summary>
    /// 抽象访问者
    /// </summary>
    public interface IVisitor
    {
        void Visit(Element element);
    }
}
