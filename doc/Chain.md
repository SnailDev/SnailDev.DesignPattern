# 责任链模式
### 什么事责任链模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/chain1.jpg)
在现实生活中，有很多请求并不是一个人说了就算的，例如面试时的工资，低于1万的薪水可能技术经理就可以决定了，但是1万~1万5的薪水可能技术经理就没这个权利批准，可能就需要请求技术总监的批准，所以在面试的完后，经常会有面试官说，你这个薪水我这边觉得你这技术可以拿这个薪水的，但是还需要技术总监的批准等的话。

责任链模式——某个请求需要多个对象进行处理，从而避免请求的发送者和接收之间的耦合关系。将这些对象连成一条链子，并沿着这条链子传递该请求，直到有对象处理它为止。主要涉及两个角色：
- 抽象处理者角色（Handler）：定义出一个处理请求的接口。这个接口通常由接口或抽象类来实现。
- 具体处理者角色（ConcreteHandler）：具体处理者接受到请求后，可以选择将该请求处理掉，或者将请求传给下一个处理者。因此，每个具体处理者需要保存下一个处理者的引用，以便把请求传递下去。

### 设计思路及代码实现



![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/chain.png)


	/// <summary>
    /// 采购请求
    /// </summary>
    public class PurchaseRequest
    {
        public double Amount { get; set; }

        public string ProductName { get; set; }

        public PurchaseRequest(string productName, double amount)
        {
            this.ProductName = productName;
            this.Amount = amount;
        }
    }

	/// <summary>
    /// 审批人
    /// </summary>
    public abstract class Approver
    {
        public Approver NextApprover { get; set; }

        public string Name { get; set; }

        public abstract void ProcessRequest(PurchaseRequest request);

        public Approver(string name)
        {
            Name = name;
        }
    }

	/// <summary>
    /// 小头头
    /// </summary>
    public class Manager : Approver
    {
        public Manager(string name)
            : base(name)
        {
        }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 10000)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this.GetType().Name, Name, request.ProductName);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

	/// <summary>
    /// 副总经理
    /// </summary>
    public class VicePresident : Approver
    {
        public VicePresident(string name) 
            : base(name)
        {
        }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 50000)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this.GetType().Name, Name, request.ProductName);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

	/// <summary>
    /// 总经理
    /// </summary>
    public class President : Approver
    {
        public President(string name) 
            : base(name)
        {
        }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 100000)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this.GetType().Name, Name, request.ProductName);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

### 责任链模式的优缺点
**优点：**

- 降低了请求的发送者和接收者之间的耦合。
- 把多个条件判定分散到各个处理类中，使得代码更加清晰，责任更加明确。

**缺点：**
- 在找到正确的处理对象之前，所有的条件判定都要执行一遍，当责任链过长时，可能会引起性能的问题
- 可能导致某个请求不被处理。


### 责任链模式的适用场景
在以下场景中可以考虑使用责任链模式：

- 一个系统的审批需要多个对象才能完成处理的情况下，例如请假系统等。
- 代码中存在多个if-else语句的情况下，此时可以考虑使用责任链模式来对代码进行重构。