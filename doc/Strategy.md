# 策略者模式
### 什么是策略者模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Strategy2.png)
策略模式是针对一组算法，将每个算法封装到具有公共接口的独立的类中，从而使它们可以相互替换。策略模式使得算法可以在不影响到客户端的情况下发生变化。对算法的包装，是把使用算法的责任和算法本身分割开，委派给不同的对象负责。策略模式通常把一系列的算法包装到一系列的策略类里面。用一句话慨括策略模式就是——“将每个算法封装到不同的策略类中，使得它们可以互换”。

该模式涉及到三个角色：
- 环境角色（Context）：持有一个Strategy类的引用
- 抽象策略角色（Strategy）：这是一个抽象角色，通常由一个接口或抽象类来实现。此角色给出所有具体策略类所需实现的接口。
- 具体策略角色（ConcreteStrategy）：包装了相关算法或行为。

### 代码实现
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Strategy1.jpg)

	/// <summary>
    /// 抽象策略
    /// </summary>
    public interface ICommunication
    {
        bool Send(object data);
    }

	/// <summary>
    /// 串口
    /// </summary>
    public class Serial : ICommunication
    {
        public bool Send(object data)
        {
            Console.WriteLine("通过串口发送一个数据的算法");
            return true;
        }
    }

	/// <summary>
    /// 网口
    /// </summary>
    public class Lan : ICommunication
    {
        public bool Send(object data)
        {
            Console.WriteLine("通过网口发送一个数据的算法");
            return true;
        }
    }

	 /// <summary>
    /// 上下文环境
    /// </summary>
    public class Context
    {
        private ICommunication _communication;

        public void SetStrategy(ICommunication communication)//传递具体的策略
        {
            this._communication = communication;
        }

        public bool Send(object data)
        {
            return this._communication.Send(data);
        }
    }

	/// <summary>
    /// 调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
         Console.WriteLine("请输入通信类型：Lan、Serial");
        string input = Console.ReadLine();
        object data = new object();

        Strategy.Context context = new Strategy.Context();
        if (input.Equals("Lan")) 
        {
            context.SetStrategy(new Strategy.Lan());
        }
        else
        {
            context.SetStrategy(new Strategy.Serial());
        }

        context.Send(data);

        Console.ReadLine();
    }

### 策略者模式的优缺点
**优点：**
- 策略类之间可以自由切换。由于策略类都实现同一个接口，所以使它们之间可以自由切换。
- 易于扩展。增加一个新的策略只需要添加一个具体的策略类即可，基本不需要改变原有的代码。
- 避免使用多重条件选择语句，充分体现面向对象设计思想。

**缺点：**
- 客户端必须知道所有的策略类，并自行决定使用哪一个策略类。这点可以考虑使用IOC容器和依赖注入的方式来解决
- 策略模式会造成很多的策略类

### 策略者模式的适用场景
在下面的情况下可以考虑使用策略模式：
- 一个系统需要动态地在几种算法中选择一种的情况下。那么这些算法可以包装到一个个具体的算法类里面，并为这些具体的算法类提供一个统一的接口。
- 如果一个对象有很多的行为，如果不使用合适的模式，这些行为就只好使用多重的if-else语句来实现，此时，可以使用策略模式，把这些行为转移到相应的具体策略类里面，就可以避免使用难以维护的多重条件选择语句，并体现面向对象涉及的概念。