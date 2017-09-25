# 单例模式
### 什么是单例模式？
从“单例”字面意思上理解为——一个类只有一个实例，所以单例模式也就是保证一个类只有一个实例的一种实现方法罢了。
其官方定义为：**确保一个类只有一个实例,并提供一个全局访问点**。

![](https://i.imgur.com/cJZwHAa.png)

### 为什么会有单例模式？
从单例模式的定义中我们可以看出——单例模式的使用自然是当我们的系统中某个对象只需要一个实例的情况。

### 剖析单例模式实现思路
1. 明确目的：（1）确保一个类只有一个实例；（2）提供一个访问它的全局访问点；
2. 类的实例化基本都是通过关键字new的，而定义私有的构造函数就不能在外界通过new创建实例，类实例的创建在类里面；
3. 每个线程都有自己的线程栈，定义一个静态私有变量保存类的实例主要是为了在多线程确保类有一个实例；
4. 定义一个公有静态方法是为了公开类的实例；

简单代码实现如下：

	    /// <summary>
	    /// 单例模式（确保一个类只有一个实例，并提供一个全局访问点）
	    /// </summary>
	    public sealed class Singleton
	    {
		    /// <summary>
		    /// 私有静态变量保存类的唯一实例
		    /// </summary>
		    private static Singleton uniqueInstance;
		    
		    /// <summary>
		    /// 私有构造方法，避免外部 new
		    /// </summary>
		    private Singleton() { }
		    
		    /// <summary>
		    /// 暴露全局访问点
		    /// </summary>
		    /// <returns></returns>
		    public static Singleton GetInstance()
		    {
			    if (uniqueInstance == null)
			    uniqueInstance = new Singleton();
			    
			    return uniqueInstance;
		    }
	    }

上面的单例模式的实现在单线程下确实是完美的,然而在多线程的情况下会得到多个Singleton实例,因为在两个线程同时运行GetInstance方法时，此时两个线程判断(uniqueInstance ==null)这个条件时都返回真，此时两个线程就都会创建Singleton的实例，这样就违背了我们单例模式初衷了，既然上面的实现会运行多个线程执行，那我们对于多线程的解决方案自然就是使GetInstance方法在同一时间只运行一个线程运行就好了，也就是我们线程同步的问题了，具体的解决多线程的代码如下:

	/// <summary>
    /// 单例模式（确保一个类只有一个实例，并提供一个全局访问点，线程同步）
    /// </summary>
    public sealed class Singleton_MultiThread
    {
        /// <summary>
        /// 私有静态变量保存类的唯一实例
        /// </summary>
        private static Singleton_MultiThread uniqueInstance;

        /// <summary>
        /// 锁，确保线程同步
        /// </summary>
        private static readonly object locker = new object();

        /// <summary>
        /// 私有构造方法，避免外部 new
        /// </summary>
        private Singleton_MultiThread() { }

        /// <summary>
        /// 暴露全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton_MultiThread GetInstance1()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            lock (locker)
            {
                if (uniqueInstance == null)
                    uniqueInstance = new Singleton_MultiThread();
            }

            return uniqueInstance;
        }

        /// <summary>
        /// 暴露全局访问点(双重锁定，减小开销，提升性能)
        /// </summary>
        /// <returns></returns>
        public static Singleton_MultiThread GetInstance2()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要加一句判断就可以了
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    if (uniqueInstance == null)
                        uniqueInstance = new Singleton_MultiThread();
                }
            }

            return uniqueInstance;
        }
    }

上面这种解决方案确实可以解决多线程的问题,但是上面GetInstance1()对于每个线程都会对线程辅助对象locker加锁之后再判断实例是否存在，对于这个操作完全没有必要的，因为当第一个线程创建了该类的实例之后，后面的线程此时只需要直接判断（uniqueInstance==null）为假，此时完全没必要对线程辅助对象加锁之后再去判断，所以上面的实现方式增加了额外的开销，损失了性能，为了改进上面实现方式的缺陷，我们只需要在lock语句前面加一句（uniqueInstance==null）的判断就可以避免锁所增加的额外开销，这种实现方式我们就叫它 “双重锁定”，可参考GetInstance2()代码。

### 单例模式的其他实现方法
##### 静态初始化

	public sealed class Singleton_StaticInit
    {
        private static readonly Singleton_StaticInit _instance = new Singleton_StaticInit();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton_StaticInit()
        {
        }

        /// <summary>
        /// Prevents a default instance of the 
        /// <see cref="Singleton_StaticInit"/> class from being created.
        /// </summary>
        private Singleton_StaticInit()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Singleton_StaticInit GetInstance
        {
            get
            {
                return _instance;
            }
        }
    }

以上方式实现比之前介绍的方式都要简单，但它确实是多线程环境下，C#实现的Singleton的一种方式。由于这种静态初始化的方式是在自己的字段被引用时才会实例化。

##### 延迟初始化

 	public sealed class Singleton_LazyInit
    {
        private Singleton_LazyInit()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Singleton_LazyInit Instance { get { return Nested._instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Singleton_LazyInit _instance = new Singleton_LazyInit();
        }
    }

这里我们把初始化工作放到Nested类中的一个静态成员来完成，这样就实现了延迟初始化。上面了一个嵌套类借鉴了.Net中lambda和匿名函数的实现原理。

##### Lazy< T > type

    /// <summary>
    /// .NET 4's Lazy<T> type
    /// </summary>
    public sealed class Singleton_LazyType
    {
        private static readonly Lazy<Singleton_LazyType> lazy =
            new Lazy<Singleton_LazyType>(() => new Singleton_LazyType());

        public static Singleton_LazyType Instance { get { return lazy.Value; } }

        private Singleton_LazyType()
        {
        }
    }

这种方式的简单和性能良好，而且还提供检查是否已经创建实例的属性IsValueCreated。

### 单例模式总结

###### 单例模式的优点：
单例模式（Singleton）会控制其实例对象的数量，从而确保访问对象的唯一性。
实例控制：单例模式防止其它对象对自己的实例化，确保所有的对象都访问一个实例。
伸缩性：因为由类自己来控制实例化进程，类就在改变实例化进程上有相应的伸缩性。

###### 单例模式的缺点：
系统开销。虽然这个系统开销看起来很小，但是每次引用这个类实例的时候都要进行实例是否存在的检查。这个问题可以通过静态实例来解决。
开发混淆。当使用一个单例模式的对象的时候（特别是定义在类库中的），开发人员必须要记住不能使用new关键字来实例化对象。因为开发者看不到在类库中的源代码，所以当他们发现不能实例化一个类的时候会很惊讶。
对象生命周期。单例模式没有提出对象的销毁。在提供内存管理的开发语言（比如，基于.NetFramework的语言）中，只有单例模式对象自己才能将对象实例销毁，因为只有它拥有对实例的引用。在各种开发语言中，比如C++，其它类可以销毁对象实例，但是这么做将导致单例类内部的指针指向不明。

###### 单例模式的适用性：
使用Singleton模式有一个必要条件：在一个系统要求一个类只有一个实例时才应当使用单例模式。反之，如果一个类可以有几个实例共存，就不要使用单例模式。
不要使用单例模式存取全局变量。这违背了单例模式的用意，最好放到对应类的静态成员中。
不要将数据库连接做成单例，因为一个系统可能会与数据库有多个连接，并且在有连接池的情况下，应当尽可能及时释放连接。Singleton模式由于使用静态成员存储类实例，所以可能会造成资源无法及时释放，带来问题。

### 参考资料
http://www.cnblogs.com/rush/archive/2011/10/30/2229565.html

http://csharpindepth.com/Articles/General/Singleton.aspx