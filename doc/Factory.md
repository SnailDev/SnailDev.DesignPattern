# 工厂模式
- #### 简单工厂模式 ####
- #### 工厂模式 ####
- #### 抽象工厂模式 ####

## 简单工厂模式
### 什么是简单工厂模式？
![](https://i.imgur.com/b7fl1lr.png)
 
在现实生活中工厂是负责生产产品的,同样在设计模式中,简单工厂模式我们也可以理解为负责生产对象的一个类, 我们平常编程中，当使用"new"关键字创建一个对象时，此时该类就依赖与这个对象，也就是他们之间的耦合度高，当需求变化时，我们就不得不去修改此类的源码，此时我们可以运用面向对象（OO）的很重要的原则去解决这一的问题，该原则就是——**封装改变，既然要封装改变，自然也就要找到改变的代码，然后把改变的代码用类来封装**，这样的一种思路也就是我们简单工厂模式的实现方式了。下面通过一个 现实生活中的例子来引出简单工厂模式。

一般情况下，如果我们想开什么车，只能自己去买，但是如今已是共享经济的时代，小到雨伞，中到自行车、电动自行车，大到汽车，如今都可以以租赁的形式使用。租车公司停了几辆车（奇瑞、路虎、兰博基尼），根据客户不同的意愿，租出去的车是不一样的，但是车都是在租车公司里有的。车都属于同一种抽象，租车公司里所有的车都有自己的特征，这些特征就是条件。租车公司根据客户不同的租车意愿，会租出不同的车。这就简单工厂模式的典型案例。

	/// <summary>
    /// 汽车类型
    /// </summary>
    public enum CarType
    {
        /// <summary>
        /// 奇瑞
        /// </summary>
        Chery = 0,

        /// <summary>
        /// 路虎
        /// </summary>
        LandRover = 1,

        /// <summary>
        /// 兰博基尼
        /// </summary>
        Lambo = 2
    }

	/// <summary>
    /// 汽车抽象类
    /// </summary>
    public abstract class Car
    {
        /// <summary>
        /// 输出自己是什么车
        /// </summary>
        public abstract void Print();
    }

	/// <summary>
    /// 奇瑞汽车
    /// </summary>
    public class CheryCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("我的品牌是奇瑞");
        }
    }

	/// <summary>
    /// 兰博基尼
    /// </summary>
    public class LamboCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("我的品牌是兰博基尼");
        }
    }

	/// <summary>
    /// 路虎
    /// </summary>
    public class LandRoverCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("我的品牌路虎");
        }
    }

	/// <summary>
    /// 简单工厂
    /// </summary>
    public class SimpleFactory
    {
        public static Car GetCar(CarType type)
        {
            switch (type)
            {
                case CarType.Chery:
                    return new CheryCar();
                case CarType.LandRover:
                    return new LandRoverCar();
                case CarType.Lambo:
                    return new LamboCar();
                default:
                    throw new Exception("未找到相应品牌汽车");
            }
        }
    }
	
    /// </summary>
	/// 调用
    /// </summary>
	static void Main(string[] args)
    {
        // 开兰博基尼
        Car car1 = SimpleFactory.GetCar(CarType.Lambo);
        car1.Print();
		
	    // 开路虎
        Car car2 = SimpleFactory.GetCar(CarType.LandRover);
        car2.Print();

        Console.Read();
    }

### 简单工厂模式的优缺点
看完简单工厂模式的实现之后，你和你的小伙伴们肯定会有这样的疑惑（因为我学习的时候也有）——这样我们只是把变化移到了工厂类中罢了，好像没有变化的问题，因为如果客户想租其他车时，此时我们还是需要修改工厂类中的方法（也就是多加case语句，没应用简单工厂模式之前，修改的是客户类）。我首先要说：你和你的小伙伴很对，这个就是简单工厂模式的缺点所在（这个缺点后面介绍的工厂方法可以很好地解决），然而，简单工厂模式与之前的实现也有它的优点：
-  简单工厂模式解决了客户端直接依赖于具体对象的问题，客户端可以消除直接创建对象的责任，而仅仅是消费产品。简单工厂模式实现了对责任的分割；
- 简单工厂模式也起到了代码复用的作用，所有客户有用车需求时，都不需要自己买车，只需要负责消费就可以了。此时简单工厂的租车方法就让所有客户共用了。（同时这点也是简单工厂方法的缺点——因为工厂类集中了所有产品创建逻辑，一旦不能正常工作，整个系统都会受到影响，也没什么不好理解的，就如事物都有两面性一样道理。

虽然上面已经介绍了简单工厂模式的缺点，下面还是总结下简单工厂模式的缺点：
- 工厂类集中了所有产品创建逻辑，一旦不能正常工作，整个系统都会受到影响（通俗地意思就是：一旦租车公司没车或者关门了，很多不愿意买车的人就没车开了）
- 系统扩展困难，一旦添加新产品就不得不修改工厂逻辑，这样就会造成工厂逻辑过于复杂。

### 简单工厂的应用场景
- 当工厂类负责创建的对象比较少时可以考虑使用简单工厂模式
- 客户如果只知道传入工厂类的参数，对于如何创建对象的逻辑不关心时可以考虑使用简单工厂模式

## 工厂模式
### 什么是工厂模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/factory.png)
工厂方法模式之所以可以解决简单工厂的模式，是因为它的实现把具体产品的创建推迟到子类中，此时工厂类不再负责所有产品的创建，而只是给出具体工厂必须实现的接口，这样工厂方法模式就可以允许系统不修改工厂类逻辑的情况下来添加新产品，这样也就克服了简单工厂模式中缺点。

    /// <summary>
    /// 汽车类型
    /// </summary>
    public enum CarType
    {
        /// <summary>
        /// 奇瑞
        /// </summary>
        Chery = 0,

        /// <summary>
        /// 路虎
        /// </summary>
        LandRover = 1,

        /// <summary>
        /// 兰博基尼
        /// </summary>
        Lambo = 2
    }

	/// <summary>
    /// 汽车抽象类
    /// </summary>
    public abstract class Car
    {
        /// <summary>
        /// 输出自己是什么车
        /// </summary>
        public abstract void Print();
    }

	/// <summary>
    /// 奇瑞汽车
    /// </summary>
    public class CheryCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("我的品牌是奇瑞");
        }
    }

	/// <summary>
    /// 兰博基尼
    /// </summary>
    public class LamboCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("我的品牌是兰博基尼");
        }
    }

	/// <summary>
    /// 路虎
    /// </summary>
    public class LandRoverCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("我的品牌路虎");
        }
    }

	/// <summary>
    /// 汽车抽象工厂
    /// </summary>
    public abstract class CarFactory
    {
        /// <summary>
        /// 生产汽车
        /// </summary>
        /// <returns></returns>
        public abstract Car CreateCar();
    }

	/// <summary>
    /// 奇瑞工厂类
    /// </summary>
    public class CheryFactory : CarFactory
    {
        /// <summary>
        /// 生产奇瑞汽车
        /// </summary>
        /// <returns></returns>
        public override Car CreateCar()
        {
            return new CheryCar();
        }
    }

	/// <summary>
    /// 兰博基尼工厂
    /// </summary>
    public class LamboFactory : CarFactory
    {
        /// <summary>
        /// 生产汽车
        /// </summary>
        /// <returns></returns>
        public override Car CreateCar()
        {
            return new LamboCar();
        }
    }

	/// <summary>
    /// 路虎工厂
    /// </summary>
    public class LandRoverFactory : CarFactory
    {
        /// <summary>
        /// 生产汽车
        /// </summary>
        /// <returns></returns>
        public override Car CreateCar()
        {
            return new LandRoverCar();
        }
    }

	static void Main(string[] args)
    {
        // 初始化生产汽车的两个工厂
        CarFactory landRoverFactory = new LandRoverFactory();
        CarFactory lamboFactory = new LamboFactory();

        // 开始生产路虎
        Car landRover = landRoverFactory.CreateCar();
        landRover.Print();

        //开始生产兰博基尼
        Car lambo = lamboFactory.CreateCar();
        lambo.Print();

        Console.Read();
    }

使用工厂方法实现的系统，如果系统需要添加新产品时，我们可以利用多态性来完成系统的扩展，对于抽象工厂类和具体工厂中的代码都不需要做任何改动。例如，我们我们还想要一个“奥迪汽车”，此时我们只需要定义一个奥迪汽车具体工厂类和奥迪汽车子类就可以。而不用像简单工厂模式中那样去修改工厂类中的实现（具体指添加case语句)。具体代码为：

	/// <summary>
    /// 奥迪汽车
    /// </summary>
    public class AodiCar : Car
    {
        /// <summary>
        /// 重写抽象类中的方法
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("我的品牌是奥迪");
        }
    }

	/// <summary>
    /// 奥迪汽车工厂类，负责生产奥迪汽车
    /// </summary>
    public class AodiFactory : CarFactory
    {
        /// <summary>
        /// 生产汽车
        /// </summary>
        /// <returns></returns>
        public override Car CreateCar()
        {
            return new AodiCar();
        }
    }

    /// <summary>
    /// 调用
    /// </summary>
    static void Main(string[] args)
    {
       
        // 如果客户想租一辆奥迪车
        // 再另外初始化一个奥迪车工厂
        CarFactory aodiFactory = new AodiFactory();

        // 利用奥迪车工厂来生产奥迪汽车
        Car aodi = aodiFactory.CreateCar();
        aodi.Print();

        Console.Read();
    }
 
### 工厂模式的优缺点
工厂方法模式通过面向对象编程中的多态性来将对象的创建延迟到具体工厂中，从而解决了简单工厂模式中存在的问题，也很好地符合了开放封闭原则（即对扩展开发，对修改封闭）。
优点：
- 子类提供挂钩。基类为工厂方法提供缺省实现，子类可以重写新的实现，也可以继承父类的实现。-- 加一层间接性，增加了灵活性
- 屏蔽产品类。产品类的实现如何变化，调用者都不需要关心，只需关心产品的接口，只要接口保持不变，系统中的上层模块就不会发生变化。
- 典型的解耦框架。高层模块只需要知道产品的抽象类，其他的实现类都不需要关心，符合迪米特法则，符合依赖倒置原则，符合里氏替换原则。
- 多态性：客户代码可以做到与特定应用无关，适用于任何实体类。

缺点：需要指定工厂和相应的子类作为factory method的载体，如果应用模型确实需要指定工厂和子类存在，则很好；否则的话，需要增加一个类层次。(不过说这个缺点好像有点吹毛求疵了)

## 抽象工厂模式
### 什么是抽象工厂模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/AbstractFactory.png)

工厂方法模式是为了克服简单工厂模式的缺点而设计出来的,简单工厂模式的工厂类随着产品类的增加需要增加额外的代码，而工厂方法模式每个具体工厂类只完成单个实例的创建,所以它具有很好的可扩展性。但是在现实生活中，一个工厂只创建单个产品这样的例子很少，因为现在的工厂都多元化了，一个工厂创建一系列的产品，如果我们要设计这样的系统时，工厂方法模式显然在这里不适用，然后抽象工厂模式却可以很好地解决一系列产品创建的问题。

    /// <summary>
    /// 汽车类型
    /// </summary>
    public enum CarType
    {
        /// <summary>
        /// 奇瑞
        /// </summary>
        Chery = 0,

        /// <summary>
        /// 路虎
        /// </summary>
        LandRover = 1,

        /// <summary>
        /// 兰博基尼
        /// </summary>
        Lambo = 2
    }

	/// <summary>
    /// 汽车抽象类
    /// </summary>
    public abstract class Car
    {
        /// <summary>
        /// 输出自己是什么车
        /// </summary>
        public abstract void Print();
    }

	/// <summary>
    /// 奇瑞汽车
    /// </summary>
    public class CheryCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("我的品牌是奇瑞");
        }
    }

	/// <summary>
    /// 兰博基尼
    /// </summary>
    public class LamboCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("我的品牌是兰博基尼");
        }
    }

	/// <summary>
    /// 路虎
    /// </summary>
    public class LandRoverCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("我的品牌路虎");
        }
    }

	/// <summary>
    /// 售后服务抽象类
    /// </summary>
    public abstract class CustomerService
    {
        /// <summary>
        /// 打印售后服务
        /// </summary>
        public abstract void Print();
    }

	/// <summary>
    /// 奇瑞售后服务
    /// </summary>
    public class CheryService : CustomerService
    {
        public override void Print()
        {
            Console.WriteLine("我是奇瑞售后服务");
        }
    }

	/// <summary>
    /// 兰博基尼售后服务
    /// </summary>
    public class LamboService : CustomerService
    {
        public override void Print()
        {
            Console.WriteLine("我是兰博基尼售后服务");
        }
    }

	/// <summary>
    /// 路虎售后服务
    /// </summary>
    public class LandRoverService : CustomerService
    {
        public override void Print()
        {
            Console.WriteLine("我是路虎售后服务");
        }
    }

	/// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class AbstractFactory
    {
        /// <summary>
        /// 生产汽车
        /// </summary>
        /// <returns></returns>
        public abstract Car CreateCar();

        /// <summary>
        /// 提供售后服务
        /// </summary>
        /// <returns></returns>
        public abstract CustomerService Service();
    }

	/// <summary>
    /// 奇瑞抽象工厂类
    /// </summary>
    public class CheryAbFactory : AbstractFactory
    {
        public override Car CreateCar()
        {
            return new CheryCar();
        }

        public override CustomerService Service()
        {
            return new CheryService();
        }
    }

	/// <summary>
    /// 兰博基尼抽象工厂
    /// </summary>
    public class LamboAbFactory : AbstractFactory
    {
        public override Car CreateCar()
        {
            return new LamboCar();
        }

        public override CustomerService Service()
        {
            return new LamboService();
        }
    }

	/// <summary>
    /// 路虎抽象工厂
    /// </summary>
    public class LandRoverAbFactory : AbstractFactory
    {
        public override Car CreateCar()
        {
            return new LandRoverCar();
        }

        public override CustomerService Service()
        {
            return new LandRoverService();
        }
    }

	/// <summary>
    /// 调用
    /// </summary>
	static void Main(string[] args)
    {
        // 路虎汽车及售后
        AbstractFactory landRoverAbFactory = new LandRoverAbFactory();
        landRoverAbFactory.CreateCar().Print();
        landRoverAbFactory.Service().Print();

        // 兰博基尼汽车及售后
        AbstractFactory lamboAbFactory = new LamboAbFactory();
        lamboAbFactory.CreateCar().Print();
        lamboAbFactory.Service().Print();

        Console.Read();
    }

抽象工厂允许客户使用抽象的接口来创建一组相关产品，而不需要知道或关心实际生产出的具体产品是什么。这样客户就可以从具体产品中被解耦。
看完上面抽象工厂的实现之后，如果租车公司又加了一个品牌车奥迪怎么办呢？此时，只需要添加三个类：一个是奥迪具体工厂类，负责生产奥迪和提供售后服务，另外两个类是奥迪售后服务类和奥迪车类。代码就不赘述。

### 抽象工厂模式的优缺点
**优点**：抽象工厂模式将具体产品的创建延迟到具体工厂的子类中，这样将对象的创建封装起来，可以减少客户端与具体产品类之间的依赖，从而使系统耦合度低，这样更有利于后期的维护和扩展。
**缺点**：抽象工厂模式很难支持新种类产品的变化。这是因为抽象工厂接口中已经确定了可以被创建的产品集合，如果需要添加新产品，此时就必须去修改抽象工厂的接口，这样就涉及到抽象工厂类的以及所有子类的改变，这样也就违背了“开发——封闭”原则。

### 抽象工厂模式的使用前提
知道了抽象工厂的优缺点之后，也就能很好地把握什么情况下考虑使用抽象工厂模式了，下面就具体看看使用抽象工厂模式的系统应该符合那几个前提：
- 一个系统不要求依赖产品类实例如何被创建、组合和表达的表达，这点也是所有工厂模式应用的前提。
- 这个系统有多个系列产品，而系统中只消费其中某一系列产品
- 系统要求提供一个产品类的库，所有产品以同样的接口出现，客户端不需要依赖具体实现。

## 总结
本文总结了三种工厂模式，逐层递进，希望大家通过本文有所得。我们使用设计模式目的无非只有三个：a)缩短开发时间；b)降低维护成本；c)在应用程序之间和内部轻松集成，但是具体什么时候使用何种设计模式还得因项目而异。