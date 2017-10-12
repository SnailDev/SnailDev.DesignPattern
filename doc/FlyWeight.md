# 享元模式
### 什么是享元模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/flyweight1.png)

所谓享元模式就是运行共享技术有效地支持大量细粒度对象的复用。系统使用少量对象,而且这些都比较相似，状态变化小，可以实现对象的多次复用。共享模式是支持大量细粒度对象的复用，所以享元模式要求能够共享的对象必须是细粒度对象。
两个重要的概念：内部状态、外部状态。
- 内部状态：在享元对象内部不随外界环境改变而改变的共享部分。
- 外部状态：随着环境的改变而改变，不能够共享的状态就是外部状态。
       
正因为享元模式区分了内部状态和外部状态，我们就可以通过设置不同的外部状态使得相同的对象可以具备一些不同的特性，而内部状态设置为相同部分。在我们的程序设计过程中，我们可能会需要大量的细粒度对象来表示对象，如果这些对象除了几个参数不同外其他部分都相同，这个时候我们就可以利用享元模式来大大减少应用程序当中的对象。如何利用享元模式呢？这里我们只需要将他们少部分的不同的部分当做参数移动到类实例的外部去，然后再方法调用的时候将他们传递过来就可以了

### 具体代码实现
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/flyweight2.jpg)

	/// <summary>
    /// 抽象享元类
    /// </summary>
    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

	/// <summary>
    /// 具体享元对象
    /// </summary>
    public class ConcreteFlyweight : Flyweight
    {
        /// <summary>
        /// 内部状态
        /// </summary>
        private string intrinsicstate;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="innerState"></param>
        public ConcreteFlyweight(string innerState)
        {
            this.intrinsicstate = innerState;
        }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="extrinsicaste">外部状态</param>
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine($"具体实现类: intrinsicstate {intrinsicstate}, extrinsicstate {extrinsicstate}");
        }
    }

 	/// <summary>
    /// 享元工厂，负责创建和管理享元对象
    /// </summary>
    public class FlyweightFactory
    {
        /// <summary>
        /// 享元对象内存缓存
        /// </summary>
        public Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            flyweights.Add("A", new ConcreteFlyweight("A"));
            flyweights.Add("B", new ConcreteFlyweight("B"));
            flyweights.Add("C", new ConcreteFlyweight("C"));
        }

        public Flyweight GetFlyweight(string key)
        {
            if (!flyweights.ContainsKey(key))
            {
                Console.WriteLine($"驻留池中不存在字符串{key}");

                flyweights.Add(key, new ConcreteFlyweight(key));
            }

            return flyweights[key] as Flyweight;
        }
    }

	/// <summary>
    /// 客户端调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        int externalstate = 10; // 定义外部状态，如字母的位置等信息
        FlyweightFactory factory = new FlyweightFactory(); // 初始化享元工厂

        Flyweight fa = factory.GetFlyweight("A");
        fa.Operation(--externalstate);

        Flyweight fb = factory.GetFlyweight("B");
        fb.Operation(--externalstate);

        Flyweight fd = factory.GetFlyweight("D");
        fd.Operation(--externalstate);

        Console.ReadLine();
    }

输出

	具体实现类: intrinsicstate A, extrinsicstate 9
	具体实现类: intrinsicstate B, extrinsicstate 8
	驻留池中不存在字符串D
	具体实现类: intrinsicstate D, extrinsicstate 7


### 享元模式的优缺点
**优点：** 降低了系统中对象的数量，从而降低了系统中细粒度对象给内存带来的压力。
**缺点：** 为了使对象可以共享，需要将一些状态外部化，这使得程序的逻辑更复杂，使系统复杂化。

### 享元模式的应用场景
在下面所有条件都满足时，可以考虑使用享元模式：
- 一个系统中有大量的对象；
- 这些对象耗费大量的内存；
- 这些对象中的状态大部分都可以被外部化
- 这些对象可以按照内部状态分成很多的组，当把外部对象从对象中剔除时，每一个组都可以仅用一个对象代替
- 软件系统不依赖这些对象的身份，

.NET中，String类的实现用到了享元模式，可以参考字符串驻留池的相关介绍。