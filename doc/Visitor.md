# 访问者模式
### 什么是访问者模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/visitor1.png)
访问者模式是封装一些施加于某种数据结构之上的操作。一旦这些操作需要修改的话，接受这个操作的数据结构则可以保存不变。访问者模式适用于数据结构相对稳定的系统， 它把数据结构和作用于数据结构之上的操作之间的耦合度降低，使得操作集合可以相对自由地改变。
数据结构的每一个节点都可以接受一个访问者的调用，此节点向访问者对象传入节点对象，而访问者对象则反过来执行节点对象的操作。这样的过程叫做“双重分派”。节点调用访问者，将它自己传入，访问者则将某算法针对此节点执行。

涉及以下几类角色：
- 抽象访问者角色（Vistor）:声明一个活多个访问操作，使得所有具体访问者必须实现的接口。
- 具体访问者角色（ConcreteVistor）：实现抽象访问者角色中所有声明的接口。
- 抽象节点角色（Element）：声明一个接受操作，接受一个访问者对象作为参数。
- 具体节点角色（ConcreteElement）：实现抽象元素所规定的接受操作。
- 结构对象角色（ObjectStructure）：节点的容器，可以包含多个不同类或接口的容器。

### 设计思路及实现
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/visitor.jpg)

普通方式实现：


 	/// <summary>
    /// 抽象元素角色
    /// </summary>
    public abstract class Element
    {
        public abstract void Print();
    }

	/// <summary>
    /// 元素A
    /// </summary>
    public class ElementA : Element
    {
        public override void Print()
        {
            Console.WriteLine("我是元素A");
        }
    }

	/// <summary>
    /// 元素B
    /// </summary>
    public class ElementB : Element
    {
        public override void Print()
        {
            Console.WriteLine("我是元素B");
        }
    }

	/// <summary>
    /// 对象结构
    /// </summary>
    public class ObjectStructure
    {
        private List<Element> elements = new List<Element>();

        public List<Element> Elements
        {
            get
            {
                return elements;
            }
        }

        public ObjectStructure()
        {
            Random ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int ranNum = ran.Next(10);
                if (ranNum>5)
                {
                    elements.Add(new ElementA());
                }
                else
                {
                    elements.Add(new ElementB());
                }
            }
        }
    }

	/// <summary>
    /// 调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        ObjectStructure objectStructure = new ObjectStructure();
        foreach (var e in objectStructure.Elements)
        {
            e.Print();
        }

        Console.ReadLine();
    }

万一除了想打印元素的信息外，还想打印出元素被访问的时间，此时就不得不去修改每个元素的Print方法，再加入相对应的输入访问时间的输出信息。

访问者模式：

	/// <summary>
    /// 抽象访问者
    /// </summary>
    public interface IVisitor
    {
        void Visit(Element element);
    }

	/// <summary>
    /// 抽象元素角色
    /// </summary>
    public abstract class Element
    {
        public abstract void Print();

        public abstract void Accept(IVisitor visitor);
    }

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

	/// <summary>
    /// 元素B
    /// </summary>
    public class ElementB : Element
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Print()
        {
            Console.WriteLine("我是元素B");
        }
    }

	/// <summary>
    /// 对象结构
    /// </summary>
    public class ObjectStructure
    {
        private List<Element> elements = new List<Element>();

        public List<Element> Elements
        {
            get
            {
                return elements;
            }
        }

        public ObjectStructure()
        {
            Random ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int ranNum = ran.Next(10);
                if (ranNum>5)
                {
                    elements.Add(new ElementA());
                }
                else
                {
                    elements.Add(new ElementB());
                }
            }
        }
    }

	/// <summary>
    /// 调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
	    // 客户端与元素的Print方法隔离

        ObjectStructure objectStructure = new ObjectStructure();
        foreach (var e in objectStructure.Elements)
        {
            // e.Print();
            e.Accept(new ConcreteVisitor());
        }

        Console.ReadLine();
    }

使用访问者模式实现上面场景后，元素Print方法的访问封装到了访问者对象中了（我觉得可以把Print方法封装到具体访问者对象中。），此时客户端与元素的Print方法就隔离开了。此时，如果需要添加打印访问时间的需求时，此时只需要再添加一个具体的访问者类即可。此时就不需要去修改元素中的Print()方法了。

### 访问者模式的优缺点：
**优点：**
- 访问者模式使得添加新的操作变得容易。如果一些操作依赖于一个复杂的结构对象的话，那么一般而言，添加新的操作会变得很复杂。而使用访问者模式，增加新的操作就意味着添加一个新的访问者类。因此，使得添加新的操作变得容易。
- 访问者模式使得有关的行为操作集中到一个访问者对象中，而不是分散到一个个的元素类中。这点类似与"中介者模式"。
- 访问者模式可以访问属于不同的等级结构的成员对象，而迭代只能访问属于同一个等级结构的成员对象。

**缺点：** 增加新的元素类变得困难。每增加一个新的元素意味着要在抽象访问者角色中增加一个新的抽象操作，并在每一个具体访问者类中添加相应的具体操作。

### 访问者模式的适用场景
以下场景可以考虑使用访问者模式：
- 如果系统有比较稳定的数据结构，而又有易于变化的算法时，此时可以考虑使用访问者模式。因为访问者模式使得算法操作的添加比较容易。
- 如果一组类中，存在着相似的操作，为了避免出现大量重复的代码，可以考虑把重复的操作封装到访问者中。（当然也可以考虑使用抽象类了）
- 如果一个对象存在着一些与本身对象不相干，或关系比较弱的操作时，为了避免操作污染这个对象，则可以考虑把这些操作封装到访问者对象中。