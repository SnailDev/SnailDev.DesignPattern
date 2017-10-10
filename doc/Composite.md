# 组合模式
### 什么是组合模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Composite1.png)

组合模式允许你将对象组合成树形结构来表现”部分-整体“的层次结构，使得客户以一致的方式处理单个对象以及对象的组合。
组合模式实现的最关键的地方是——简单对象和复合对象必须实现相同的接口。这就是组合模式能够将组合对象和简单对象进行一致处理的原因。
- 组合部件（Component）：它是一个抽象角色，为要组合的对象提供统一的接口。
- 叶子（Leaf）：在组合中表示子节点对象，叶子节点不能有子节点。
- 合成部件（Composite）：定义有枝节点的行为，用来存储部件，实现在Component接口中的有关操作，如增加（Add）和删除（Remove）。

### 代码实现
**透明式的组合模式**
在Component中声明所有来管理子对象的方法，其中包括Add，Remove等。这样实现Component接口的所有子类都具备了Add和Remove方法。这样做的好处是叶节点和枝节点对于外界没有区别，它们具备完全一致的接口。

 	/// <summary>
    /// 一个抽象构件，声明一个接口用于访问和管理Component的子部件
    /// </summary>
    public abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// 增加一个节点
        /// </summary>
        /// <param name="component"></param>
        public abstract void Add(Component component);

        /// <summary>
        /// 移除一个节点
        /// </summary>
        /// <param name="component"></param>
        public abstract void Remove(Component component);

        /// <summary>
        /// 显示层级结构
        /// </summary>
        public abstract void Display(int level);
    }

	/// <summary>
    /// 叶子节点
    /// </summary>
    public class Leaf : Component
    {
        public Leaf(string name)
            : base(name)
        { }

        /// <summary>
        /// 由于叶子节点没有子节点，所以Add和Remove方法对它来说没有意义，但它继承自Component，这样做可以消除叶节点和枝节点对象在抽象层次的区别，它们具备完全一致的接口。
        /// </summary>
        /// <param name="component"></param>
        public override void Add(Component component)
        {
            Console.WriteLine("Can not add a component to a leaf.");
        }

        /// <summary>
        /// 实现它没有意义，只是提供了一个一致的调用接口
        /// </summary>
        /// <param name="component"></param>
        public override void Remove(Component component)
        {
            Console.WriteLine("Can not remove a component to a leaf.");
        }

        public override void Display(int level)
        {
            Console.WriteLine(new string('-', level) + name);
        }
    }

	/// <summary>
    /// 定义有枝节点的行为，用来存储部件，实现在Component接口中对子部件有关的操作
    /// </summary>
    public class Composite : Component
    {
        public Composite(string name)
            : base(name)
        { }

        /// <summary>
        /// 一个子对象集合，用来存储其下属的枝节点和叶节点
        /// </summary>
        private List<Component> children = new List<Component>();

        /// <summary>
        /// 增加子节点
        /// </summary>
        /// <param name="component"></param>
        public override void Add(Component component)
        {
            children.Add(component);
        }

        /// <summary>
        /// 移除子节点
        /// </summary>
        /// <param name="component"></param>
        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int level)
        {
            Console.WriteLine(new string('-', level) + name);

            // 遍历其子节点并显示
            foreach (Component component in children)
            {
                component.Display(level + 2);
            }
        }
    }

	/// <summary>
    /// 调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
	    // 生成树根，并为其增加两个叶子节点
	    Component root = new Composite.Composite("Root");
	    root.Add(new Leaf("Leaf A in Root"));
	    root.Add(new Leaf("Leaf B in Root"));
	
	    // 为根增加两个枝节点
	    Component branchX = new Composite.Composite("Branch X in Root");
	    Component branchY = new Composite.Composite("Branch Y in Root");
	    root.Add(branchX);
	    root.Add(branchY);
	
	    // 为BranchX增加页节点
	    branchX.Add(new Leaf("Leaf A in Branch X"));
	
	    // 为BranchX增加枝节点
	    Component branchZ = new Composite.Composite("Branch Z in Branch X");
	    branchX.Add(branchZ);
	
	    // 为BranchY增加叶节点
	    branchY.Add(new Leaf("Leaf in Branch Y"));
	
	    // 为BranchZ增加叶节点
	    branchZ.Add(new Leaf("Leaf in Branch Z"));
	
	    // 显示树
	    root.Display(1);
	}
弊端：客户端对叶节点和枝节点是一致的，但叶节点并不具备Add和Remove的功能，因而对它们的实现是没有意义的

**安全式组合模式**
在Component中不去声明Add和Remove方法，那么子类的Leaf就不需要实现它，而是在Composit声明所有用来管理子类对象的方法。

	/// <summary>
    /// 一个抽象构件，声明一个接口用于访问和管理Component的子部件
    /// </summary>
    public abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// 显示层级结构
        /// </summary>
        public abstract void Display(int level);
    }

	/// <summary>
    /// 叶子节点
    /// </summary>
    public class Leaf : Component
    {
        public Leaf(string name)
            : base(name)
        { }
       
        public override void Display(int level)
        {
            Console.WriteLine(new string('-', level) + name);
        }
    }

	/// <summary>
    /// 定义有枝节点的行为，用来存储部件，实现在Component接口中对子部件有关的操作
    /// </summary>
    public class Composite : Component
    {
        public Composite(string name)
            : base(name)
        { }

        /// <summary>
        /// 一个子对象集合，用来存储其下属的枝节点和叶节点
        /// </summary>
        private List<Component> children = new List<Component>();

        /// <summary>
        /// 增加子节点
        /// </summary>
        /// <param name="component"></param>
        public void Add(Component component)
        {
            children.Add(component);
        }

        /// <summary>
        /// 移除子节点
        /// </summary>
        /// <param name="component"></param>
        public void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int level)
        {
            Console.WriteLine(new string('-', level) + name);

            // 遍历其子节点并显示
            foreach (Component component in children)
            {
                component.Display(level + 2);
            }
        }
    }

	/// <summary>
    /// 调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
	    // 生成树根，并为其增加两个叶子节点
        Composite.Composite root = new Composite.Composite("Root");
        root.Add(new Leaf("Leaf A in Root"));
        root.Add(new Leaf("Leaf B in Root"));

        // 为根增加两个枝节点
        Composite.Composite branchX = new Composite.Composite("Branch X in Root");
        Composite.Composite branchY = new Composite.Composite("Branch Y in Root");
        root.Add(branchX);
        root.Add(branchY);

        // 为BranchX增加页节点
        branchX.Add(new Leaf("Leaf A in Branch X"));

        // 为BranchX增加枝节点
        Composite.Composite branchZ = new Composite.Composite("Branch Z in Branch X");
        branchX.Add(branchZ);

        // 为BranchY增加叶节点
        branchY.Add(new Leaf("Leaf in Branch Y"));

        // 为BranchZ增加叶节点
        branchZ.Add(new Leaf("Leaf in Branch Z"));

        // 显示树
        root.Display(1);
	}
弊端：叶节点无需在实现Add与Remove这样的方法，但是对于客户端来说，必须对叶节点和枝节点进行判定，为客户端的使用带来不便。

### 组合模式的优缺点
**优点：**
- 组合模式使得客户端代码可以一致地处理对象和对象容器，无需关系处理的单个对象，还是组合的对象容器。
- 将”客户代码与复杂的对象容器结构“解耦。
- 可以更容易地往组合对象中加入新的构件。

**缺点：** 使得设计更加复杂。客户端需要花更多时间理清类之间的层次关系。（这个是几乎所有设计模式所面临的问题）。
**注意的问题：**
- 有时候系统需要遍历一个树枝结构的子构件很多次，这时候可以考虑把遍历子构件的结构存储在父构件里面作为缓存。
- 客户端尽量不要直接调用树叶类中的方法（在我上面实现就是这样的，创建的是一个树枝的具体对象;），而是借用其父类（Graphics）的多态性完成调用，这样可以增加代码的复用性。

### 组合模式的使用场景
在以下情况下应该考虑使用组合模式：
1. 当想表达对象的部分-整体的层次结构时。
2. 希望用户忽略组合对象与单个对象的不同，用户将统一地使用组合结构中的所有对象时。

.NET 中Winform 中的空间类型大多用到了该种设计模式。另， 《设计模式》一书中提倡：相对于安全性，我们比较强调透明性。对于第一种方式中叶子节点内不需要的方法可以使用空处理或者异常报告的方式来解决。