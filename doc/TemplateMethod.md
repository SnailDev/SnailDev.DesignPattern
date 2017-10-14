# 模板方法模式
### 什么是模板方法模式?
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/TemplateMethod.png)
模板方法模式——在一个抽象类中定义一个操作中的算法骨架（对应于生活中的大家下载的模板），而将一些步骤延迟到子类中去实现（对应于我们根据自己的情况向模板填充内容）。模板方法使得子类可以不改变一个算法的结构前提下，重新定义算法的某些特定步骤，模板方法模式把不变行为搬到超类中，从而去除了子类中的重复代码。
- 抽象类（AbstractClass）：定义了一个或多个抽象操作，以便让子类实现，这些抽象操作称为基本操作。
- 具体类（ConcreteClass)：实现父类所定义的一个或多个抽象方法。

### 代码实现

	/// <summary>
    /// 抽象类
    /// </summary>
    public abstract class AbstractClass
    {
        // 一些抽象行为，放到子类去实现
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        /// <summary>
        /// 模板方法，给出了逻辑的骨架，而逻辑的组成是一些相应的抽象操作，它们推迟到子类去实现。
        /// </summary>
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("Done the method.");
        }
    }

	/// <summary>
    /// 具体类，实现了抽象类中的特定步骤
    /// </summary>
    public class ConcreteClassA : AbstractClass
    {
        /// <summary>
        /// 与ConcreteClassB中的实现逻辑不同
        /// </summary>
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("Implement operation 1 in Concreate class A.");
        }

        /// <summary>
        /// 与ConcreteClassB中的实现逻辑不同
        /// </summary>
        public override void PrimitiveOperation2()
        {
            Console.WriteLine("Implement operation 2 in Concreate class A.");
        }
    }

	/// <summary>
    /// 具体类，实现了抽象类中的特定步骤
    /// </summary>
    public class ConcreteClassB : AbstractClass
    {
        /// <summary>
        /// 与ConcreteClassA中的实现逻辑不同
        /// </summary>
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("Implement operation 1 in Concreate class B.");
        }

        /// <summary>
        /// 与ConcreteClassA中的实现逻辑不同
        /// </summary>
        public override void PrimitiveOperation2()
        {
            Console.WriteLine("Implement operation 2 in Concreate class B.");
        }
    }

	/// <summary>
    /// 调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // 声明抽象类
        AbstractClass ac;

        // 用ConcreteClassA实例化ac
        ac = new ConcreteClassA();
        ac.TemplateMethod();

        // 用ConcreteClassB实例化ac
        ac = new ConcreteClassB();
        ac.TemplateMethod();

        Console.ReadLine();
    }

把相同的部分抽象出来到抽象类中去定义，具体子类来实现具体的不同部分，这个思路也正式模板方法的实现精髓所在。

### 模板方法模式的优缺点
**优点：**
- 实现了代码复用
- 能够灵活应对子步骤的变化，符合开放-封闭原则


**缺点：** 因为引入了一个抽象类，如果具体实现过多的话，需要用户或开发人员需要花更多的时间去理清类之间的关系。

### 模板方法模式的使用场景
在以下情况下可以考虑使用模板方法模式：
1. 对一些复杂的算法进行分割，将其算法中固定不变的部分设计为模板方法和父类具体方法，而一些可以改变的细节由其子类来实现。即：一次性实现一个算法的不变部分，并将可变的行为留给子类来实现。
2. 各子类中公共的行为应被提取出来并集中到一个公共父类中以避免代码重复。
3. 需要通过子类来决定父类算法中某个步骤是否执行，实现子类对父类的反向控制。