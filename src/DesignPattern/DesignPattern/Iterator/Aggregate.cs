using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Iterator
{
    /// <summary>
    /// 聚合抽象类
    /// </summary>
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }
}
