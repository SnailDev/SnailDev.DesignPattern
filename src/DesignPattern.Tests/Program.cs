using DesignPattern.Bridge;
using DesignPattern.Chain;
using DesignPattern.Command;
using DesignPattern.Composite;
using DesignPattern.Decorator;
using DesignPattern.Facade;
using DesignPattern.FlyWeight;
using DesignPattern.Iterator;
using DesignPattern.Mediator;
using DesignPattern.Proxy;
using DesignPattern.State;
using DesignPattern.TemplateMethod;
using DesignPattern.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Tests
{
    class Program
    {
        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Console.WriteLine(Singleton.GetInstance());
            // var haha = 123456;
            // Console.WriteLine($"Excuted Failed,Message: ({haha})");

            // BuilderInvoke();
            // PrototypeInvoke();
            // BridgeInvoke();
            // DecoratorInvoke();
            // CompositeInvoke();
            // FacadeInvoke();
            // FlyWeightInvoke();
            // ProxyInvoke();
            // TemplateMethodInvoke();
            // CommandInvoke();
            // IteratorInvoke();
            // ObserverInvoke();
            // MediatorInvoke();
            // StateInvoke();
            // MediatorWithStateInvoke();
            // StrategyInvoke();
            // ChainInvoke();

            VisitorInvoke();

            Console.ReadLine();
        }

        static void BuilderInvoke()
        {
            // 创建一个指挥者和两个建造者
            Director director = new Director();
            Builder b1 = new BuilderA();
            Builder b2 = new BuilderB();

            // 指挥者指挥建造者A去组装汽车
            director.AssemblyCar(b1);
            var car1 = b1.GetCar();
            car1.DoAssembly();

            // 指挥者指挥建造者B去组装汽车
            director.AssemblyCar(b2);
            var car2 = b2.GetCar();
            car2.DoAssembly();
        }

        static void PrototypeInvoke()
        {
            ConcretePrototype concretePrototypeA = new ConcretePrototype
            {
                Attr = "Monkey"
            };

            var ConcretePrototypeB = (ConcretePrototype)concretePrototypeA.Clone();
            Console.WriteLine(concretePrototypeA == ConcretePrototypeB);
            Console.WriteLine(concretePrototypeA.Attr == ConcretePrototypeB.Attr);
        }

        static void BridgeInvoke()
        {
            // 我们现在是实现不同品牌的汽车，可以安装不同牌子的导航，也就是把汽车和导航聚合了起来。  
            // 我们是通过桥接的方式完成了这种聚合，桥接方式比继承的方式要更灵活，它是汽车与配件可  以独立各自的发展。  
            // 我们可以实现的聚合关系：宝马+北斗，宝马+神行者，奔驰+北斗，奔驰+身形者  
            // 当然我们还可以给汽车配置更多不同的后装配件例如：空气净化器等。  
            INavigator bdNavigator = new BDNavigator();
            INavigator gdNavigator = new GDNavigator();

            //宝马安装北斗导航  
            VehicleBrand bmw = new BMWVehicle();
            bmw.InstallNavigator(bdNavigator);
            bmw.OpenNavigator();

            //奔驰安装了高德导航  
            VehicleBrand benz = new BenzVehicle();
            benz.InstallNavigator(gdNavigator);
            benz.OpenNavigator();
        }

        static void DecoratorInvoke()
        {
            Beverage beverage = new DarkRoast(); // 焦烤咖啡
            Console.WriteLine(beverage.GetDescription() + " $" + beverage.Cost());
            beverage = new Mocha(beverage); //添加摩卡
            Console.WriteLine(beverage.GetDescription() + " $" + beverage.Cost());
            beverage = new Milk(beverage);  //添加牛奶
            Console.WriteLine(beverage.GetDescription() + " $" + beverage.Cost());
            Beverage beverage2 = new Milk(new HouseBlend()); // 家庭混合咖啡加摩卡加牛奶
            Console.WriteLine(beverage2.GetDescription() + " $" + beverage2.Cost());
        }

        static void CompositeInvoke()
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

        static void FacadeInvoke()
        {
            string courseName = "设计模式";
            string studentName = "小明";
            SelectSystem selectSystem = new SelectSystem();
            NotifySystem notifySystem = new NotifySystem();
            if (selectSystem.CheckAvailable(courseName))
            {
                Console.WriteLine($"{courseName}课程已经不可选");
            }
            else
            {
                Console.WriteLine($"{courseName}课程选择成功");
                if (notifySystem.Notify(studentName))
                    Console.WriteLine($"通知学生{studentName}成功");
                else
                    Console.WriteLine($"通知学生{studentName}失败");
            }

            //Facade pattern
            SelectCourseFacade facade = new SelectCourseFacade();
            if (facade.SelectCourse(courseName, studentName))
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }

        }

        static void FlyWeightInvoke()
        {
            int externalstate = 10; // 定义外部状态，如字母的位置等信息
            FlyweightFactory factory = new FlyweightFactory(); // 初始化享元工厂

            Flyweight fa = factory.GetFlyweight("A");
            fa.Operation(--externalstate);

            Flyweight fb = factory.GetFlyweight("B");
            fb.Operation(--externalstate);

            Flyweight fd = factory.GetFlyweight("D");
            fd.Operation(--externalstate);
        }

        static void ProxyInvoke()
        {
            // 创建一个代理对象并发出请求
            InternetShop proxy = new InternetShop();
            proxy.Sell();
        }

        static void TemplateMethodInvoke()
        {
            // 声明抽象类
            AbstractClass ac;

            // 用ConcreteClassA实例化ac
            ac = new ConcreteClassA();
            ac.TemplateMethod();

            // 用ConcreteClassB实例化ac
            ac = new ConcreteClassB();
            ac.TemplateMethod();
        }

        static void CommandInvoke()
        {
            Receiver receiver = new Receiver();
            ICommand command = new ConcereteCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }

        static void IteratorInvoke()
        {
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "xiaoming";
            a[1] = "xiaohong";

            Iterator.Iterator i = a.CreateIterator();
            object item = i.First();
            while (!i.IsDone())
            {
                Console.WriteLine("{0}请Say Hi！", i.CurrentItem());
                i.Next();
            }
        }

        static void ObserverInvoke()
        {
            // 第一种方式
            Observer.First.Subscriber XiaoMingSub = new Observer.First.Subscriber("XiaoMing");
            Observer.First.QQGame qqGame1 = new Observer.First.QQGame("QQ Game", "Have a new game published ....");
            qqGame1.Subscriber = XiaoMingSub;
            qqGame1.Update();

            // 第二种方式
            Observer.Next.QQGame qqGame2 = new Observer.Next.QQGame("QQ Game", "Have a new game published ....");
            qqGame2.AddObserver(new Observer.Next.Subscriber("XiaoMing"));
            qqGame2.Update();

            // 第三种方式
            Observer.Last.QQGame qqGame3 = new Observer.Last.QQGame("QQ Game", "Have a new game published ....");
            var xiaoming = new Observer.Last.Subscriber("XiaoMing");
            var xiaohong = new Observer.Last.Subscriber("XiaoHong");

            qqGame3.AddObserver(new Observer.Last.AbstractGame.NotifyEventHandler(xiaoming.ReceiveAndPrint));
            qqGame3.AddObserver(new Observer.Last.AbstractGame.NotifyEventHandler(xiaohong.ReceiveAndPrint));

            qqGame3.Update();
        }

        static void MediatorInvoke()
        {

            #region 简单实现

            //AbstractCardPartner A = new PartnerA();
            //A.Money = 20;
            //AbstractCardPartner B = new PartnerB();
            //B.Money = 20;

            //// A赢了B的钱减少
            //A.ChangeMoney(5, B);
            //Console.WriteLine("A 现在的钱是：{0}", A.Money); // 应该是25
            //Console.WriteLine("B 现在的钱是：{0}", B.Money); // 应该是15

            //// B赢了A的钱减少
            //B.ChangeMoney(10, A);
            //Console.WriteLine("A 现在的钱是：{0}", A.Money); // 应该是15
            //Console.WriteLine("B 现在的钱是：{0}", B.Money); // 应该是25 

            #endregion

            #region 

            AbstractCardPartner A = new PartnerA();
            AbstractCardPartner B = new PartnerB();
            A.Money = 20;
            B.Money = 20;

            AbstractMediator mediator = new MediatorPater(A, B);

            // A赢了
            A.ChangeMoney(5, mediator);
            Console.WriteLine("A 现在的钱是：{0}", A.Money); // 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.Money); // 应该是15

            // B赢了A的钱减少
            B.ChangeMoney(10, mediator);
            Console.WriteLine("A 现在的钱是：{0}", A.Money); // 应该是15
            Console.WriteLine("B 现在的钱是：{0}", B.Money); // 应该是25 

            #endregion
        }

        static void StateInvoke()
        {
            // 设置Context的初始状态为ConcreteStateA
            Context context = new Context(new ConcreteStateA());

            // 不断地进行请求，同时更改状态
            for (int i = 0; i < 10; i++)
            {
                context.Request();
            }
        }

        static void MediatorWithStateInvoke()
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

            // A赢了
            mediator.State = new State.Mediator.AWinState(mediator);
            mediator.ChangeMoney(5);
            Console.WriteLine("A 现在的钱是：{0}", A.Money);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.Money); // 应该是15

            // B 赢了
            mediator.State = new State.Mediator.BWinState(mediator);
            mediator.ChangeMoney(10);
            Console.WriteLine("A 现在的钱是：{0}", A.Money);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.Money); // 应该是15
        }

        static void StrategyInvoke()
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
        }

        static void ChainInvoke()
        {
            PurchaseRequest requestTelphone = new PurchaseRequest("Telphone", 8000.0);
            PurchaseRequest requestSoftware = new PurchaseRequest("Ms System", 60000.0);
            PurchaseRequest requestComputers = new PurchaseRequest("Computers", 80000.0);

            Approver manager = new Manager("XiaoJun");
            Approver vp = new VicePresident("XiaoHong");
            Approver pre = new President("XiaoMing");

            manager.NextApprover = vp;
            vp.NextApprover = pre;

            manager.ProcessRequest(requestTelphone);
            manager.ProcessRequest(requestSoftware);
            manager.ProcessRequest(requestComputers);
        }

        static void VisitorInvoke()
        {
            ObjectStructure objectStructure = new ObjectStructure();
            foreach (var e in objectStructure.Elements)
            {
                // e.Print();

                e.Accept(new ConcreteVisitor());
            }
        }
    }
}
