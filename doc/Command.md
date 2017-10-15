# 命令模式
### 什么是命令模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Command.png)
命令模式将一个请求封装为一个对象(即我们创建的Command对象），从而使你可用不同的请求对客户进行参数化; 对请求排队或记录请求日志，以及支持可撤销的操作。
- 抽象命令（Command）：定义命令的接口，声明执行的方法。
- 具体命令（ConcreteCommand）：具体命令，实现要执行的方法，它通常是“虚”的实现；通常会有接收者，并调用接收者的功能来完成命令要执行的操作。
- 接收者（Receiver）：真正执行命令的对象。任何类都可能成为一个接收者，只要能实现命令要求实现的相应功能。
- 调用者（Invoker）：要求命令对象执行请求，通常会持有命令对象，可以持有很多的命令对象。这个是客户端真正触发命令并要求命令执行相应操作的地方，也就是说相当于使用命令对象的入口。
- 客户端（Client）：命令由客户端来创建，并设置命令的接收者。

### 代码实现

 	/// <summary>
    /// 接收者类，知道如何实施与执行一个请求相关的操作，任何类都可能作为一个接收者。
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// 真正的命令实现
        /// </summary>
        public void Action()
        {
            Console.WriteLine("Execute request!");
        }
    }

	/// <summary>
    /// 抽象命令类，用来声明执行操作的接口
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }

	/// <summary>
    /// 具体命令类，实现具体命令。
    /// </summary>
    public class ConcereteCommand : ICommand
    {
        // 具体命令类包含有一个接收者，将这个接收者对象绑定于一个动作
        private Receiver receiver;

        public ConcereteCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        /// <summary>
        /// 说这个实现是“虚”的，因为它是通过调用接收者相应的操作来实现Execute的
        /// </summary>
        public void Execute()
        {
            receiver.Action();
        }
    }

	/// <summary>
    /// 调度类，要求该命令执行这个请求
    /// </summary>
    public class Invoker
    {
        private ICommand command;

        /// <summary>
        /// 设置命令
        /// </summary>
        /// <param name="command"></param>
        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        public void ExecuteCommand()
        {
            command.Execute();
        }
    }

	/// <summary>
    /// 调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Receiver receiver = new Receiver();
        ICommand command = new ConcereteCommand(receiver);
        Invoker invoker = new Invoker();

        invoker.SetCommand(command);
        invoker.ExecuteCommand();

        Console.ReadLine();
    }

### 命令模式的优缺点
命令模式使得命令发出的一个和接收的一方实现低耦合，从而有以下的优点：
- 解除了请求者与实现者之间的耦合，降低了系统的耦合度。
- 对请求排队或记录请求日志，支持撤销操作。
- 可以容易地设计一个组合命令。
- 新命令可以容易地加入到系统中。
　　
命令模式的缺点：
使用命令模式可能会导致系统有过多的具体命令类。这会使得命令模式在这样的系统里变得不实际。

### 命令模式的适用场景
在下面的情况下可以考虑使用命令模式：
- 当需要对行为进行“记录、撤销/重做”等处理时。
- 系统需要将请求者和接收者解耦，使得调用者和接收者不直接交互。
- 系统需要在不同时间指定请求、请求排队和执行请求。
- 系统需要将一组操作组合在一起，即支持宏命令。