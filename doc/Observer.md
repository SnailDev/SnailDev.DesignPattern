# 观察者模式
### 什么是观察者模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/observer1.png)
观察者模式定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个主题对象，这个主题对象在状态发生变化时，会通知所有观察者对象，使它们能够自动更新自己的行为。
结构：
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/observer2.png)
可以看出，在观察者模式的结构图有以下角色：
- 抽象主题角色（Subject）：抽象主题把所有观察者对象的引用保存在一个列表中，并提供增加和删除观察者对象的操作，抽象主题角色又叫做抽象被观察者角色，一般由抽象类或接口实现。
- 抽象观察者角色（Observer）：为所有具体观察者定义一个接口，在得到主题通知时更新自己，一般由抽象类或接口实现。
- 具体主题角色（ConcreteSubject）：实现抽象主题接口，具体主题角色又叫做具体被观察者角色。
- 具体观察者角色（ConcreteObserver）：实现抽象观察者角色所要求的接口，以便使自身状态与主题的状态相协调。

### 设计分析及代码实现
我们以监控QQ游戏公众号的消息推送为例展开讨论。

First:

	namespace DesignPattern.Observer.First
	{
	    /// <summary>
	    /// QQ游戏公众号
	    /// </summary>
	    public class QQGame
	    {
	        /// <summary>
	        /// 订阅对象
	        /// </summary>
	        public Subscriber Subscriber { get; set; }
	
	        public string Symbol { get; set; }
	
	        public string Info { get; set; }
	
	        public QQGame(string symbol,string info)
	        {
	            this.Symbol = symbol;
	            this.Info = info;
	        }
	
	        public void Update()
	        {
	            if (Subscriber!=null)
	            {
	                Subscriber.ReceiveAndPrintData(this);
	            }
	        }
	    }
	}

	namespace DesignPattern.Observer.First
	{
	    /// <summary>
	    /// 订阅者类
	    /// </summary>
	    public class Subscriber
	    {
	        public string Name { get; set; }
	
	        public Subscriber(string name)
	        {
	            this.Name = name;
	        }
	
	        public void ReceiveAndPrintData(QQGame game)
	        {
	            Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, game.Symbol, game.Info);
	        }
	    }
	}

	class Program
    {
        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // 第一种方式
            Observer.First.Subscriber XiaoMingSub = new Observer.First.Subscriber("XiaoMing");
            Observer.First.QQGame qqGame1 = new Observer.First.QQGame("QQ Game", "Have a new game published ....");
            qqGame1.Subscriber = XiaoMingSub;
            qqGame1.Update();

            Console.ReadLine();
        }
	}

上面代码确实实现了监控订阅号的任务。但这里的实现存在下面几个问题：
- QQGame类和Subscriber类之间形成了一种双向依赖关系，一个类变化将引起另一个类的改变。
- 当出现一个新的订阅者时，此时不得不修改QQGame代码，即添加另一个订阅者的引用和在Update方法中调用另一个订阅者的方法。


Next:
这样的设计违背了“开放——封闭”原则，显然不是我们想要的。下面做出改进：
- 订阅者抽象出一个接口，用它来取消QQGame类与具体的订阅者之间的依赖
- QQGame中采用一个列表来保存所有的订阅者对象，内部再添加对该列表的操作

实现代码为：

	namespace DesignPattern.Observer.Next
	{
	    public abstract class AbstractGame
	    {
	        // 订阅者列表
	        private List<IObserver> observers = new List<IObserver>();
	
	        public string Symbol { get; set; }
	
	        public string Info { get; set; }
	
	        public AbstractGame(string symbol, string info)
	        {
	            this.Symbol = symbol;
	            this.Info = info;
	        }
	
	        public void AddObserver(IObserver ob)
	        {
	            observers.Add(ob);
	        }
	
	        public void RemoveObserver(IObserver ob)
	        {
	            observers.Remove(ob);
	        }
	
	        public void Update()
	        {
	            foreach (var ob in observers)
	            {
	                if (ob != null)
	                {
	                    ob.ReceiveAndPrint(this);
	                }
	            }
	        }
	    }
	}

	namespace DesignPattern.Observer.Next
	{
	    public class QQGame : AbstractGame
	    {
	        public QQGame(string symbol, string info)
	            : base(symbol, info)
	        {
	        }
	    }
	}

	namespace DesignPattern.Observer.Next
	{
	    public interface IObserver
	    {
	        void ReceiveAndPrint(AbstractGame game);
	    }
	}

	namespace DesignPattern.Observer.Next
	{
	    public class Subscriber : IObserver
	    {
	        public string Name { get; set; }
	
	        public Subscriber(string name)
	        {
	            this.Name = name;
	        }
	
	        public void ReceiveAndPrint(AbstractGame game)
	        {
	            Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, game.Symbol, game.Info);
	        }
	    }
	}

	class Program
    {
        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // 第二种方式
            Observer.Next.QQGame qqGame2 = new Observer.Next.QQGame("QQ Game", "Have a new game published ....");
            qqGame2.AddObserver(new Observer.Next.Subscriber("XiaoMing"));
            qqGame2.Update();

            Console.ReadLine();
        }
	}

这样的实现就是观察者模式的实现。在任何时候，只要调用了AbstractGame类的Update方法，它就会通知所有的观察者对象，同时，取消了直接依赖，变为间接依赖，这样大大提供了系统的可维护性和可扩展性。

Last:
使用委托与事件来简化观察者模式的实现

	namespace DesignPattern.Observer.Last
	{
	    public abstract class AbstractGame
	    {
	        // 委托充当订阅者接口类
	        public delegate void NotifyEventHandler(object sender);
	
	        public NotifyEventHandler NotifyEvent;
	
	        public string Symbol { get; set; }
	
	        public string Info { get; set; }
	
	        public AbstractGame(string symbol, string info)
	        {
	            this.Symbol = symbol;
	            this.Info = info;
	        }
	
	        public void AddObserver(NotifyEventHandler ob)
	        {
	            NotifyEvent += ob;
	        }
	
	        public void RemoveObserver(NotifyEventHandler ob)
	        {
	            NotifyEvent -= ob;
	        }
	
	        public void Update()
	        {
	            if (NotifyEvent != null)
	            {
	                NotifyEvent(this);
	            }
	        }
	    }
	}

	namespace DesignPattern.Observer.Last
	{
	    public class QQGame : AbstractGame
	    {
	        public QQGame(string symbol, string info)
	            : base(symbol, info)
	        {
	        }
	    }
	}

	namespace DesignPattern.Observer.Last
	{
	    public class Subscriber
	    {
	        public string Name { get; set; }
	
	        public Subscriber(string name)
	        {
	            this.Name = name;
	        }
	
	        public void ReceiveAndPrint(Object obj)
	        {
	            AbstractGame game = obj as AbstractGame;
	            if (game != null)
	            {
	                Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, game.Symbol, game.Info);
	            }
	        }
	    }
	}

	class Program
    {
        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // 第三种方式
            Observer.Last.QQGame qqGame3 = new Observer.Last.QQGame("QQ Game", "Have a new game published ....");
            var xiaoming = new Observer.Last.Subscriber("XiaoMing");
            var xiaohong = new Observer.Last.Subscriber("XiaoHong");

            qqGame3.AddObserver(new Observer.Last.AbstractGame.NotifyEventHandler(xiaoming.ReceiveAndPrint));
            qqGame3.AddObserver(new Observer.Last.AbstractGame.NotifyEventHandler(xiaohong.ReceiveAndPrint));

            qqGame3.Update();

            Console.ReadLine();
        }
	}

使用事件和委托实现的观察者模式中，减少了订阅者接口类的定义，此时，.委托正式充当订阅者接口类的角色。

### 观察者模式的优缺点
**优点：**
- 观察者模式实现了表示层和数据逻辑层的分离，并定义了稳定的更新消息传递机制，并抽象了更新接口，使得可以有各种各样不同的表示层，即观察者。
- 观察者模式在被观察者和观察者之间建立了一个抽象的耦合，被观察者并不知道任何一个具体的观察者，只是保存着抽象观察者的列表，每个具体观察者都符合一个抽象观察者的接口。
- 观察者模式支持广播通信。被观察者会向所有的注册过的观察者发出通知。

**缺点：**
- 如果一个被观察者有很多直接和间接的观察者时，将所有的观察者都通知到会花费很多时间。
- 虽然观察者模式可以随时使观察者知道所观察的对象发送了变化，但是观察者模式没有相应的机制使观察者知道所观察的对象是怎样发生变化的。
- 如果在被观察者之间有循环依赖的话，被观察者会触发它们之间进行循环调用，导致系统崩溃，在使用观察者模式应特别注意这点。

### 观察者模式的适用场景
以下情况可以考虑使用观察者模式：
- 当一个抽象模型有两个方面，其中一个方面依赖于另一个方面，将这两者封装在独立的对象中以使它们可以各自独立地改变和复用的情况下。
- 当对一个对象的改变需要同时改变其他对象，而又不知道具体有多少对象有待改变的情况下。
- 当一个对象必须通知其他对象，而又不能假定其他对象是谁的情况下。