using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Iterator
{
    /// <summary>
    /// 具体聚合类
    /// </summary>
    public class ConcreteAggregate : Aggregate
    {
        private IList<object> items = new List<object>();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public object this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }

        public int Count
        {
            get { return items.Count; }
        }
    }
}
