# 迭代器模式
### 什么是迭代器模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Iterator.jpg)

迭代器是针对集合对象而生的，提供了一种方法顺序访问一个聚合对象（可理解为集合对象）中各个元素，而又无需暴露该对象的内部表示，这样既可以做到不暴露集合的内部结构，又可让外部代码透明地访问集合内部的数据。
从上图可以看出，迭代器模式由以下角色组成：
- 迭代器角色（Iterator）：迭代器角色负责定义访问和遍历元素的接口
- 具体迭代器角色（ConcreteIteraror）：具体迭代器角色实现了迭代器接口，并需要记录遍历中的当前位置。
- 聚合角色（Aggregate）：聚合角色负责定义获得迭代器角色的接口
- 具体聚合角色（ConcreteAggregate）：具体聚合角色实现聚合角色接口。

### 代码实现

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

	/// <summary>
    /// 聚合抽象类
    /// </summary>
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

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

	/// <summary>
    /// 具体迭代器类
    /// </summary>
    public class ConcreteIterator : Iterator
    {
        private ConcreteAggregate aggregate;
        private int current = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public override object CurrentItem()
        {
            return aggregate[current];
        }

        public override object First()
        {
            return aggregate[0];
        }

        public override bool IsDone()
        {
            return current == aggregate.Count;
        }

        public override object Next()
        {
            object ret = null;

            current++;
            if (current < aggregate.Count)
            {
                ret = aggregate[current];
            }

            return ret;
        }
    }

 	/// <summary>
    /// 调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        ConcreteAggregate a = new ConcreteAggregate();
        a[0] = "xiaoming";
        a[1] = "xiaohong";

        Iterator.Iterator i = a.CreateIterator();
        object item = i.First();
        while (!i.IsDone())
        {
            Console.WriteLine("{0}请Say Hi！", i.CurrentItem());
            i.Next();
        }

        Console.ReadLine();
    }

### 迭代器模式的优缺点
由于迭代器承担了遍历集合的职责，从而有以下的优点：

- 迭代器模式使得访问一个聚合对象的内容而无需暴露它的内部表示，即迭代抽象。
- 迭代器模式为遍历不同的集合结构提供了一个统一的接口，从而支持同样的算法在不同的集合结构上进行操作

迭代器模式存在的缺点：
- 迭代器模式在遍历的同时更改迭代器所在的集合结构会导致出现异常。所以使用foreach语句只能在对集合进行遍历，不能在遍历的同时更改集合中的元素。

### 迭代器模式的适用场景
在下面的情况下可以考虑使用迭代器模式：
- 系统需要访问一个聚合对象的内容而无需暴露它的内部表示。
- 系统需要支持对聚合对象的多种遍历。
- 系统需要为不同的聚合结构提供一个统一的接口。

在.NET下，迭代器模式中的聚集接口和迭代器接口都已经存在了，其中IEnumerator接口扮演的就是迭代器角色，IEnumberable接口则扮演的就是抽象聚集的角色，只有一个GetEnumerator()方法，关于这两个接口的定义可以自行参考MSDN。