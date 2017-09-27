# 建造者模式
如果再次取名“一个建造者能写出花来？”，估计真的就变成写花系列了。本篇还是中规中矩：设计模式之建造者模式
### 什么是建造者模式？
在软件系统中，有时需要创建一个复杂对象，并且这个复杂对象由其各部分子对象通过一定的步骤组合而成。例如一个租车公司需要采购一批车时，在这个实际需求中，车就是一个复杂的对象，它是由方向盘、轮胎、发动机、传动系统、空调系统等多个零部件构成，如果让采购员一辆一辆车去组装的话真是要累死采购员了，这里可以采用建造者模式来解决这个问题，**我们可以把车的各个部件封装到一个建造者类对象里，建造者只要负责返还给客户端全部组件都建造完毕的产品对象就可以了**。然而现实生活中也是如此的，如果租车公司要采购一批汽车，此时采购员不可能自己去买各个部件并把它们组织起来，此时采购员只需要向汽车店的老板说自己要采购什么样的电脑就可以了，汽车店的老板自然会把组装好的汽车送到公司。
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/builder.png)


**建造者模式（Builder Pattern）:将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示。**

![](https://i.imgur.com/WfmAo1F.png)

在建造者模式中，有如下4个角色：
- Product产品类：通常是实现了模板方法的模式，也就是有模板方法和基本方法；
- Builder抽象建造者：规范产品的组建，一般是由子类实现；
- ConcreteBuilder具体建造者：实现抽象类定义的所有方法，并且返回一个组建好的对象；
- Director导演类：负责安排已有模块的顺序，然后告诉Builder开始建造；

### 建造者模式的具体实现
 	/// <summary>
    /// 大型汽车
    /// </summary>
    public class BigCar
    {
        /// <summary>
        /// 汽车零部件集合
        /// </summary>
        private IList<string> parts = new List<string>();

        /// <summary>
        /// 汽车零部件组装
        /// </summary>
        /// <param name="part"></param>
        public void AddPart(string part)
        {
            parts.Add(part);
        }

        /// <summary>
        /// 执行组装动作
        /// </summary>
        public void DoAssembly()
        {
            Console.WriteLine("汽车开始组装......");

            foreach (var part in parts)
            {
                Console.WriteLine("部件：" + part + "----已装好");
            }

            Console.WriteLine("汽车组装完成");
        }
    }

	/// <summary>
    /// 指挥者
    /// </summary>
    public class Director
    {
        /// <summary>
        /// 组装汽车
        /// </summary>
        /// <param name="builder"></param>
        public void AssemblyCar(Builder builder)
        {
            builder.AssemblyEngines();
            builder.AssemblyTransmissions();
        }
    }

	/// <summary>
    /// 建造者抽象类
    /// </summary>
    public abstract class Builder
    {
        /// <summary>
        /// 组装引擎
        /// </summary>
        public abstract void AssemblyEngines();

        /// <summary>
        /// 组装传动系统
        /// </summary>
        public abstract void AssemblyTransmissions();

        /// <summary>
        /// 获取组装好的汽车
        /// </summary>
        /// <returns></returns>
        public abstract BigCar GetCar();
    }

	/// <summary>
    /// 建造者A
    /// </summary>
    public class BuilderA : Builder
    {
        BigCar car = new BigCar();
        public override void AssemblyEngines()
        {
            car.AddPart("enginesA");
        }

        public override void AssemblyTransmissions()
        {
            car.AddPart("transmissionsA");
        }

        public override BigCar GetCar()
        {
            return car;
        }
    }

	/// <summary>
    /// 建造者B
    /// </summary>
    public class BuilderB : Builder
    {
        BigCar car = new BigCar();
        public override void AssemblyEngines()
        {
            car.AddPart("enginesB");
        }

        public override void AssemblyTransmissions()
        {
            car.AddPart("transmissionsB");
        }

        public override BigCar GetCar()
        {
            return car;
        }
    }

	/// <summary>
    /// 调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
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

        Console.ReadLine();
    }

代码写起来就感觉小领导指挥普通员工完成任务一样。

### 建造者模式的总结
1. 在建造者模式中，指挥者是直接与客户端打交道的，指挥者将客户端创建产品的请求划分为对各个部件的建造请求，再将这些请求委派到具体建造者角色，具体建造者角色是完成具体产品的构建工作的，却不为客户所知道。
2. 建造者模式主要用于“分步骤来构建一个复杂的对象”，其中“分步骤”是一个固定的组合过程，而复杂对象的各个部分是经常变化的（也就是说汽车的内部组件是经常变化的，这里指的的变化如发动机型号，前驱还是后驱等）。
3. 产品不需要抽象类，由于建造模式的创建出来的最终产品可能差异很大，所以不大可能提炼出一个抽象产品类。
4. 在前面文章中介绍的抽象工厂模式解决了“系列产品”的需求变化，而建造者模式解决的是 “产品部分” 的需要变化。
5. 由于建造者隐藏了具体产品的组装过程，所以要改变一个产品的内部表示，只需要再实现一个具体的建造者就可以了，从而能很好地应对产品组成组件的需求变化。

到这里,建造者模式就结束了,建造者模式(Builder Pattern)，将一个复杂对象的构建与它的表示分离，使的同样的构建过程可以创建不同的表示。建造者模式的本质是使组装过程（用指挥者类进行封装，从而达到解耦的目的）和创建具体产品解耦,使我们不用去关心每个组件是如何组装的。