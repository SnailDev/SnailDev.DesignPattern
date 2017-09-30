# 桥接模式
### 什么是桥接模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/bridge4.gif)

**定义：将抽象部分与实现部分分离，使它们都可以独立的变化。**
看定义，可能有点懵，不过没关系，下面我们将通过一个例子展开说明。
例子：品牌汽车内置导航仪，但是希望实现每个品牌的导航仪都可以在任何一个品牌的汽车上安装并启动。
假设汽车品牌： 宝马、奔驰
假设导航仪品牌： 神行者、北斗、高德。

### 设计思路及代码实现
如下如图所示，来看一下一般设计思路：采用继承来实现每个组合的安装和启动处理的，每个品牌+导航都需要一个独立的类来实现功能。这里就会有一个问题，如果我们，每增加一个品牌汽车，就得再增加三个类，拓展和维护性非常差。
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/bridge1.png)

于是，我们将汽车品牌和导航仪品牌做个组合。
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/birdge2.png)

进一步演化，每增加一个汽车品牌时，就只需要增加一个品牌类就好，这个品牌和之前的导航仪组合就可以了。
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/bridge3.png)
我们可以看出导航仪和汽车其实是一种聚合关系，也就是导航仪只是汽车的一部分，而这一部分不随着汽车消亡而消失。所以他们之间是松耦合关系，聚合关系。
下面是具体代码实现：

 	/// <summary>
    /// 导航接口
    /// </summary>
    public interface INavigator
    {
        /// <summary>
        /// 导航工作方法
        /// </summary>
        void Work();
    }

	/// <summary>
    /// 北斗导航
    /// </summary>
    public class BDNavigator : INavigator
    {
        public void Work()
        {
            Console.WriteLine("我是北斗导航。");
        }
    }

	/// <summary>
    /// 高德导航
    /// </summary>
    public class GDNavigator : INavigator
    {
        public void Work()
        {
            Console.WriteLine("我是高德导航。");
        }
    }

	/// <summary>
    /// 汽车品牌抽象类
    /// </summary>
    public abstract class VehicleBrand
    {
        protected INavigator navigator;

        /// <summary>
        /// 安装导航
        /// </summary>
        /// <param name="navigator"></param>
        public abstract void InstallNavigator(INavigator navigator);

        /// <summary>
        /// 打开导航
        /// </summary>
        public abstract void OpenNavigator();
    }

	/// <summary>
    /// 宝马汽车
    /// </summary>
    public class BMWVehicle : VehicleBrand
    {
        public override void InstallNavigator(INavigator navigator)
        {
            this.navigator = navigator;
        }

        public override void OpenNavigator()
        {
            navigator.Work();
        }
    }

	/// <summary>
    /// 奔驰汽车
    /// </summary>
    public class BenzVehicle : VehicleBrand
    {
        public override void InstallNavigator(INavigator navigator)
        {
            this.navigator = navigator;
        }

        public override void OpenNavigator()
        {
            navigator.Work();
        }
    }

	/// <summary>
    /// 调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // 实现不同品牌的汽车，可以安装不同牌子的导航，也就是把汽车和导航聚合了起来。  
        // 通过桥接的方式完成了这种聚合，桥接方式比继承的方式要更灵活，它是汽车与配件可  以独立各自的发展。  
        // 可以实现的聚合关系：宝马+北斗，宝马+神行者，奔驰+北斗，奔驰+身形者  
        // 还可以给汽车配置更多不同的后装配件例如：空气净化器等。  
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

        Console.ReadLine();
    }

### 桥接模式的优缺点
介绍完桥接模式，让我们看看桥接模式具体哪些优缺点。
**优点**：
- 把抽象接口与其实现解耦。
- 抽象和实现可以独立扩展，不会影响到对方。
- 实现细节对客户透明。

**缺点**： 增加了系统的复杂度

### 桥接模式使用场景
在以下情况下应当使用桥接模式：
1. 如果一个系统需要在构件的抽象化角色和具体化角色之间添加更多的灵活性，避免在两个层次之间建立静态的联系。
2. 设计要求实现化角色的任何改变不应当影响客户端，或者实现化角色的改变对客户端是完全透明的。
3. 需要跨越多个平台的图形和窗口系统上。
4. 一个类存在两个独立变化的维度，且两个维度都需要进行扩展。

本文开头的三层模式架构图就是一个很好的桥接模式的使用例子，三层架构中的业务逻辑层BLL中通过桥接模式与数据操作层解耦（DAL），其实现方式就是在BLL层中引用了DAL层中一个引用。桥接模式实现了**抽象化与实现化的解耦，使它们相互独立互不影响到对方**。