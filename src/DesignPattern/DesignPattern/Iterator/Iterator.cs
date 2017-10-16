using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Iterator
{
    /// <summary>
    /// 迭代器抽象类
    /// </summary>
    public abstract class Iterator
    {
        public abstract object First();

        public abstract object Next();

        public abstract bool IsDone();

        public abstract object CurrentItem();
    }
}
