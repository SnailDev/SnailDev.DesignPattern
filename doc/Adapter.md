# 适配器模式
### 什么是适配器模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Adapter.jpg)

**把一个类的接口变换成客户端所期待的另一种接口，从而使原本接口不匹配而无法一起工作的两个类能够在一起工作**。

模式中的角色：
- 目标接口（Target）：客户所期待的接口。目标可以是具体的或抽象的类，也可以是接口。
- 需要适配的类（Adaptee）：需要适配的类或适配者类。
- 适配器（Adapter）：通过包装一个需要适配的对象，把原接口转换成目标接口。

适配器模式有**类的适配器模式**和**对象的适配器模式**两种形式，下面我们分别讨论这两种形式的实现

### 类的适配器模式
具体实现代码如下：

	/// <summary>
    /// 目标接口（C#不支持类的多继承，故此处定义为接口）
    /// </summary>
    public interface ITarget
    {
        void Request();
    }

	/// <summary>
    /// 定义需要适配的类
    /// </summary>
    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("This is a special request.");
        }
    }

	/// <summary>
    /// 定义适配器，继承适配的类和目标接口
    /// </summary>
    public class PowerAdapter_Class : Adaptee, ITarget
    {
        /// <summary>
        /// 实现目标接口方法
        /// </summary>
        public void Request()
        {
            this.SpecificRequest();
        }
    }

	/// <summary>
    /// 客户端调用
    /// </summary>
	static void Main(string[] args)
    {
        ITarget target = new PowerAdapter_Class();
        target.Request();
        Console.ReadLine();
    }

从上面代码中可以看出，客户端希望调用Request方法（即三个孔插头），但是我们现有的类（即2个孔的插头）并没有Request方法，它只有SpecificRequest方法（即两个孔插头本身的方法），然而适配器类（适配器必须实现三个孔插头接口和继承两个孔插头类）可以提供这种转换，它提供了Request方法的实现（其内部调用的是两个孔插头，因为适配器只是一个外壳罢了，包装着两个孔插头（因为只有这样，电器才能使用），并向外界提供三个孔插头的外观，）以供客户端使用，对应类图如下：

![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Adapter1.png)

### 对象的适配器模式
具体实现代码如下：

	/// <summary>
    /// 适配器模式中的目标(Target)角色
    /// </summary>
    public class Target
    {
        /// <summary>
        /// 使用virtual修饰以便子类可以重写
        /// </summary>
        public virtual void Request()
        {
            Console.WriteLine("This is a common request");
        }
    }

	/// <summary>
    /// 定义需要适配的类
    /// </summary>
    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("This is a special request.");
        }
    }

	/// <summary>
    /// 定义适配器继承目标类
    /// </summary>
    public class PowerAdapter_Object : Target
    {
        public Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }

	/// <summary>
    /// 客户端调用
    /// </summary>
	static void Main(string[] args)
    {
        Target target = new PowerAdapter_Object();
        target.Request();
        Console.ReadLine();
    }

一目了然，在适配器类中创建需要适配的对象，并通过对象调用指定方法以达到适配的目的。对应类图如下：

![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Adapter2.png)

### 适配器模式的优缺点

**类的适配器模式**：

优点：
- 可以在不修改原有代码的基础上来复用现有类，很好地符合 “开闭原则”
- 可以重新定义Adaptee(被适配的类)的部分行为，因为在类适配器模式中，Adapter是Adaptee的子类
- 仅仅引入一个对象，并不需要额外的字段来引用Adaptee实例（这个即是优点也是缺点）。

缺点：
- 用一个具体的Adapter类对Adaptee和Target进行匹配，当如果想要匹配一个类以及所有它的子类时，类的适配器模式就不能胜任了。因为类的适配器模式中没有引入Adaptee的实例，光调用this.SpecificRequest方法并不能去调用它对应子类的SpecificRequest方法。
- 采用了 “多继承”的实现方式，带来了不良的高耦合。

**对象的适配器模式**：

优点：
- 可以在不修改原有代码的基础上来复用现有类，很好地符合 “开闭原则”（这点是两种实现方式都具有的）
- 采用 “对象组合”的方式，更符合松耦合。

缺点：
- 使得重定义Adaptee的行为较困难，这就需要生成Adaptee的子类并且使得Adapter引用这个子类而不是引用Adaptee本身。

### 适配器模式的应用场景
在以下情况下可以考虑使用适配器模式：
1. 系统需要复用现有类，而该类的接口不符合系统的需求
2. 想要建立一个可重复使用的类，用于与一些彼此之间没有太大关联的一些类，包括一些可能在将来引进的类一起工作。
3. 对于对象适配器模式，在设计里需要改变多个已有子类的接口，如果使用类的适配器模式，就要针对每一个子类做一个适配器，而这不太实际。

.NET中的一个重要适配器模式的应用就是DataAdapter。ADO.NET为统一的数据访问提供了多个接口和基类，其中最重要的接口之一是IdataAdapter。DataAdpter起到了数据库到DataSet桥接器的作用，使应用程序的数据操作统一到DataSet上，而与具体的数据库类型无关。甚至可以针对特殊的数据源编制自己的DataAdpter，从而使我们的应用程序与这些特殊的数据源相兼容。