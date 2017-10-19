# 状态者模式
### 什么是状态者模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/state3.jpg)

每个对象都有其对应的状态，而每个状态又对应一些相应的行为，如果某个对象有多个状态时，那么就会对应很多的行为。那么对这些状态的判断和根据状态完成的行为，就会导致多重条件语句，并且如果添加一种新的状态时，需要更改之前现有的代码。这样的设计显然违背了开闭原则。状态模式正是用来解决这样的问题的。状态模式将每种状态对应的行为抽象出来成为单独新的对象，这样状态的变化不再依赖于对象内部的行为。

状态者模式：当一个对象的内在状态改变时允许改变其行为，这个对象看起来像是改变了其类。其主要解决的是当控制一个对象状态转换的条件表达式过于复杂时的情况。通过把状态的判断逻辑转移到表示不同的一系列类当中，可以把复杂的逻辑判断简单化。
- 上下文环境（Context）：它定义了客户程序需要的接口并维护一个具体状态角色的实例，将与状态相关的操作委托给当前的Concrete State对象来处理。
- 抽象状态（State）：定义一个接口以封装使用上下文环境的的一个特定状态相关的行为。
- 具体状态（Concrete State）：实现抽象状态定义的接口。

### 设计思路及代码实现
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/state2.png)

	/// <summary>
    /// Context类，维护一个ConcreteState子类的实例，这个实例定义当前的状态。
    /// </summary>
    public class Context
    {
        private State state;
        /// <summary>
        /// 定义Context的初始状态
        /// </summary>
        /// <param name="state"></param>
        public Context(State state)
        {
            this.state = state;
        }

        /// <summary>
        /// 可读写的状态属性，用于读取和设置新状态
        /// </summary>
        public State State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// 对请求做处理，并设置下一个状态
        /// </summary>
        public void Request()
        {
            state.Handle(this);
        }
    }

	/// <summary>
    /// 抽象状态类，定义一个接口以封装与Context的一个特定状态相关的行为
    /// </summary>
    public abstract class State
    {
        public abstract void Handle(Context context);
    }

	/// <summary>
    /// 具体状态类，每一个子类实现一个与Context的一个状态相关的行为
    /// </summary>
    public class ConcreteStateA : State
    {
        /// <summary>
        /// 设置ConcreteStateA的下一个状态是ConcreteStateB
        /// </summary>
        /// <param name="context"></param>
        public override void Handle(Context context)
        {
            Console.WriteLine("当前状态是 A.");
            context.State = new ConcreteStateB();
        }
    }

	/// <summary>
    /// 具体状态类，每一个子类实现一个与Context的一个状态相关的行为
    /// </summary>
    public class ConcreteStateB : State
    {
        /// <summary>
        /// 设置ConcreteStateB的下一个状态是ConcreteSateA
        /// </summary>
        /// <param name="context"></param>
        public override void Handle(Context context)
        {
            Console.WriteLine("当前状态是 B.");
            context.State = new ConcreteStateA();
        }
    }

	/// <summary>
    /// 调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // 设置Context的初始状态为ConcreteStateA
	    Context context = new Context(new ConcreteStateA());
	
	    // 不断地进行请求，同时更改状态
	    for (int i = 0; i < 10; i++)
	    {
	        context.Request();
	    }


        Console.ReadLine();
    }

### 应用状态者模式完善中介者模式

	/// <summary>
    /// 抽象牌友类
    /// </summary>
    public abstract class AbstractCardPartner
    {
        public int Money { get; set; }

        public abstract void ChangeMoney(int money, AbstractMediator mediator);
    }

	/// <summary>
    /// 牌友A
    /// </summary>
    public class PartnerA : AbstractCardPartner
    {
        public override void ChangeMoney(int money, AbstractMediator mediator)
        {
            mediator.ChangeMoney(money);
        }
    }

	/// <summary>
    /// 牌友B
    /// </summary>
    public class PartnerB : AbstractCardPartner
    {
        public override void ChangeMoney(int money, AbstractMediator mediator)
        {
            mediator.ChangeMoney(money);
        }
    }

	// 抽象状态类
    public abstract class State
    {
        protected AbstractMediator meditor;

        public abstract void ChangeMoney(int money);
    }

	// 初始化状态类
    public class InitState : State
    {
        public InitState()
        {
            Console.WriteLine("游戏才刚刚开始,暂时还有玩家胜出");
        }

        public override void ChangeMoney(int money)
        {
            return;
        }
    }

	public class AWinState : State
    {
        public AWinState(AbstractMediator concretemediator)
        {
            meditor = concretemediator;
        }

        public override void ChangeMoney(int money)
        {
            foreach (AbstractCardPartner p in meditor.list)
            {
                PartnerA a = p as PartnerA;
                if (a != null)
                {
                    a.Money += money;
                }
                else
                {
                    p.Money -= money;
                }
            }
        }
    }

	public class BWinState : State
    {
        public BWinState(AbstractMediator concretemediator)
        {
            meditor = concretemediator;
        }

        public override void ChangeMoney(int money)
        {
            foreach (AbstractCardPartner p in meditor.list)
            {
                PartnerB b = p as PartnerB;
                // 如果集合对象中时B对象，则对B的钱添加
                if (b != null)
                {
                    b.Money += money;
                }
                else
                {
                    p.Money -= money;
                }
            }
        }
    }

	/// <summary>
    /// 抽象中介者类
    /// </summary>
    public abstract class AbstractMediator
    {
        public List<AbstractCardPartner> list = new List<AbstractCardPartner>();

        public State State { get; set; }

        public AbstractMediator(State state)
        {
            State = state;
        }

        public void Add(AbstractCardPartner partner)
        {
            list.Add(partner);
        }

        public void Remove(AbstractCardPartner partner)
        {
            list.Remove(partner);
        }

        public void ChangeMoney(int money)
        {
            State.ChangeMoney(money);
        }
    }

	/// <summary>
    /// 中介者Pater
    /// </summary>
    public class MediatorPater : AbstractMediator
    {
        public MediatorPater(State state) : base(state)
        {
        }
    }

	/// <summary>
    /// 调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        State.Mediator.AbstractCardPartner A = new State.Mediator.PartnerA();
        State.Mediator.AbstractCardPartner B = new State.Mediator.PartnerB();
        // 初始钱
        A.Money = 20;
        B.Money = 20;

        State.Mediator.AbstractMediator mediator = new State.Mediator.MediatorPater(new State.Mediator.InitState());

        // A,B玩家进入平台进行游戏
        mediator.Add(A);
        mediator.Add(B);

        // A 赢了
        mediator.State = new State.Mediator.AWinState(mediator);
        mediator.ChangeMoney(5);
        Console.WriteLine("A 现在的钱是：{0}", A.Money);// 应该是25
        Console.WriteLine("B 现在的钱是：{0}", B.Money); // 应该是15

        // B 赢了
        mediator.State = new State.Mediator.BWinState(mediator);
        mediator.ChangeMoney(10);
        Console.WriteLine("A 现在的钱是：{0}", A.Money);// 应该是25
        Console.WriteLine("B 现在的钱是：{0}", B.Money); // 应该是15

        Console.ReadLine();
    }

### 状态者模式优缺点
**优点：**
- 将状态判断逻辑每个状态类里面，可以简化判断的逻辑。
- 当有新的状态出现时，可以通过添加新的状态类来进行扩展，扩展性好。

**缺点：** 如果状态过多的话，会导致有非常多的状态类，加大了开销

### 状态者模式适用场景
在以下情况下可以考虑使用状态者模式。
- 当一个对象状态转换的条件表达式过于复杂时可以使用状态者模式。把状态的判断逻辑转移到表示不同状态的一系列类中，可以把复杂的判断逻辑简单化。
- 当一个对象行为取决于它的状态，并且它需要在运行时刻根据状态改变它的行为时，就可以考虑使用状态者模式。