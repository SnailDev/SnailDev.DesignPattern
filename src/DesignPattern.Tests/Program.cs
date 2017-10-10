using DesignPattern.Bridge;
using DesignPattern.Composite;
using DesignPattern.Decorator;
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
            CompositeInvoke();

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
            ConcretePrototype concretePrototypeA = new ConcretePrototype();
            concretePrototypeA.Attr = "Monkey";

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
    }
}
