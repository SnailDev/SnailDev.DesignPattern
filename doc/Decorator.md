# 装饰者模式
### 什么是装饰者模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Decorator1.png)

装饰者模式以对客户透明的方式动态地给一个对象附加上更多的责任，装饰者模式相比生成子类可以更灵活地增加功能。
- Component:一般是一个抽象类（也有可能不是），是一组有着某种用途类的基类，包含着这些类最基本的特性。
- ConcreteComponent：继承自Component，一般是一个有实际用途的类，这个类就是我们以后要装饰的对象。
- Decorator：继承自Component，装饰者需要共同实现的接口（也可以是抽象类），用来保证装饰者和被装饰者有共同的超类，并保证每一个装饰者都有一些必须具有的性质，如每一个装饰者都有一个实例变量（instance  variable）用来保存某个Component类型的类的引用。
- ConcreteDecorator：继承自Decorator，用来装饰Component类型的类（不能装饰抽象类），为其添加新的特性，可以在委托被装饰者的行为完成之前或之后的任意时候。

下面我们以星巴兹咖啡订单管理系统 管理、计算各种饮料的售价为例，对装饰者模式展开讨论。

### 设计思路及代码实现
#### 继承
可能我们的第一印象就是继承。
1. 首先定义一个咖啡基类 
2. 对于加糖的，加牛奶的，加摩卡的 ，加奶泡的，分别写一个子类继承 
3. 对于加糖，又加奶的写一个类，对于对于加糖，又摩卡的写一个类，对于对于加糖、又奶泡的写一个类，对于加糖，又加奶、摩卡的写一个类。

于是子类爆炸如下图：
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Decorator2.png)

#### 冗余
当然我们也可把调料都写在作为超类Beverage里，但是这样的话会造成数据的大量冗余，这是一个解决办法，但是还不够好。

![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Decorator3.png)

#### 装饰者模式
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Decorator6.png)
- Beverage（饮料类）：相当与Component
- HouseBlend、DarkRoast...（混合咖啡类、礁炒咖啡类...）：相当于ConcreteComponent
- CondimentDecorator（调料装饰者类）：相当于Decorator
- Milk、Mocha...（牛奶类、摩卡类...）：相当于ConcreteDecorator

装饰者模式的特点，一个ConcreteComponent可以被任意个ConcreteDecorator装饰。
结合实例就来解释，一种咖啡可以和任意种调料搭配。
下面就是我C#实现的代码：

	/// <summary>
    /// 饮品
    /// </summary>
    public abstract class Beverage
    {
        /// <summary>
        /// 描述
        /// </summary>
        /// <returns></returns>
        public abstract string GetDescription();

        /// <summary>
        /// 定价
        /// </summary>
        /// <returns></returns>
        public abstract double Cost();
    }

	/// <summary>
    /// 焦烤咖啡
    /// </summary>
	public class DarkRoast : Beverage
    {
        public override double Cost()
        {
            return 2.5;
        }

        public override string GetDescription()
        {
            return "我是焦烤咖啡";
        }
    }

	/// <summary>
    /// 家庭混合咖啡
    /// </summary>
	public class HouseBlend : Beverage
    {
        public override double Cost()
        {
            return 2.3;
        }

        public override string GetDescription()
        {
            return "我是家庭混合咖啡";
        }
    }

	/// <summary>
    /// 调料装饰者基类
    /// </summary>
    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage Beverage { get; set; }
    }

	/// <summary>
    /// 摩卡
    /// </summary>
	public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage)
        {
            this.Beverage = beverage;
        }

        public override double Cost()
        {
            return Beverage.Cost() + 0.7;
        }

        public override string GetDescription()
        {
            return Beverage.GetDescription() + "，加了摩卡";
        }
    }

	/// <summary>
    /// 牛奶
    /// </summary>
	public class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage)
        {
            this.Beverage = beverage;
        }

        public override double Cost()
        {
            return Beverage.Cost() + 0.2;
        }

        public override string GetDescription()
        {
            return Beverage.GetDescription() + "，加了牛奶";
        }
    }

	/// <summary>
	/// 调用
	/// </summary>
	/// <param name="args"></param>
	static void Main(string[] args)
	{
	    Beverage beverage = new DarkRoast(); // 焦烤咖啡
        Console.WriteLine(beverage.GetDescription() + " $" + beverage.Cost());
        beverage = new Mocha(beverage); //添加摩卡
        Console.WriteLine(beverage.GetDescription() + " $" + beverage.Cost());
        beverage = new Milk(beverage);  //添加牛奶
        Console.WriteLine(beverage.GetDescription() + " $" + beverage.Cost());
        Beverage beverage2 = new Milk(new HouseBlend()); // 家庭混合咖啡加摩卡加牛奶
        Console.WriteLine(beverage2.GetDescription() + " $" + beverage2.Cost());
	 
	    Console.ReadLine();
	}

### 装饰者模式的优缺点
**优点：**
- 装饰这模式和继承的目的都是扩展对象的功能，但装饰者模式比继承更灵活
- 通过使用不同的具体装饰类以及这些类的排列组合，设计师可以创造出很多不同行为的组合
- 装饰者模式有很好地可扩展性

**缺点：** 装饰者模式会导致设计中出现许多小对象，如果过度使用，会让程序变的更复杂。并且更多的对象会是的差错变得困难，特别是这些对象看上去都很像。

### 装饰者模式的使用场景
在以下情况下应当使用装饰者模式：
1. 需要扩展一个类的功能或给一个类增加附加责任。
2. 需要动态地给一个对象增加功能，这些功能可以再动态地撤销。
3. 需要增加由一些基本功能的排列组合而产生的非常大量的功能

.NET FrameWork 中的 System.IO.Stream 就用到了装饰者模式。