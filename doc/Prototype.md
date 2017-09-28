# 原型模式
### 什么是原型模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/prototype1.gif)

《西游记》中，孙悟空可以根据自己的形状复制（克隆）出多个身外身，如上图所示，这种技巧在面向对象软件设计领域被称之为原型模式，孙悟空被称之为原型对象。**原型模式通过复制一个原型对象得到多个与原型对象一模一样的新对象**。
原型模式：**使用原型实例指定待创建对象的类型，并且通过复制这个原型来创建新的对象**。

原型模式结构如下图所示
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/prototype2.gif)

### 原型模式代码实现
#### 通用实现方法
通用的克隆实现方法是在具体原型类的克隆方法中实例化一个与自身类型相同的对象并将其返回，并将相关的参数传入新创建的对象中，保证它们的成员变量相同。示意代码如下：

	/// <summary>
    /// 原型抽象类
    /// </summary>
    public abstract class Prototype
    {
        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public abstract Prototype Clone();
    }

	/// <summary>
    /// 创建具体原型
    /// </summary>
    public class ConcretePrototype : Prototype
    {
        // 成员变量
        public string Attr { get; set; }

        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public override Prototype Clone()
        {
            ConcretePrototype prototype = new ConcretePrototype();
        	prototype.Attr = attr;
        	return prototype;
        }
    }
 在客户类中只需要创建一个ConcretePrototype对象作为原型对象，然后调用其Clone()方法即可得到对应的克隆对象，如下代码片段所示：

	ConcretePrototype prototype = new ConcretePrototype();
	ConcretePrototype copy = (ConcretePrototype)prototype.Clone();
此方法是原型模式的通用实现，它与编程语言本身的特性无关，除C#外，其他面向对象编程语言也可以使用这种形式来实现对原型的克隆。
在原型模式的通用实现方法中，可通过手工编写Clone()方法来实现浅克隆和深克隆。对于引用类型的对象，可以在Clone()方法中通过赋值的方式来实现复制，这是一种浅克隆实现方案；如果在Clone()方法中通过创建一个全新的成员对象来实现复制，则是一种深克隆实现方案。C#语言中的字符串(string/String)对象存在特殊性，只要两个字符串的内容相同，无论是直接赋值还是创建新对象，它们在内存中始终只有一份。

#### C#中的MemberwiseClone()方法和ICloneable接口
在C#语言中，提供了一个MemberwiseClone()方法用于实现浅克隆，该方法使用起来很方便，直接调用一个已有对象的MemberwiseClone()方法即可实现克隆。如下代码所示：

	/// <summary>
    /// 原型抽象类
    /// </summary>
    public abstract class Prototype
    {
        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public abstract Prototype Clone();
    }

	/// <summary>
    /// 创建具体原型
    /// </summary>
    public class ConcretePrototype : Prototype
    {
        // 成员变量
        public string Attr { get; set; }

        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public override Prototype Clone()
        {
            // 调用MemberwiseClone方法实现的是浅拷贝，另外还有深拷贝
            return (Prototype)this.MemberwiseClone();
        }
    }
在客户类中可以直接调用原型对象的Clone()方法来创建新的对象，如下代码片段所示：

    ConcretePrototype concretePrototypeA = new ConcretePrototype();
    concretePrototypeA.Attr = "Monkey";

    var ConcretePrototypeB = (ConcretePrototype)concretePrototypeA.Clone();
    Console.WriteLine(concretePrototypeA == ConcretePrototypeB);
    Console.WriteLine(concretePrototypeA.Attr == ConcretePrototypeB.Attr);

在上述客户类代码片段中，输出语句“Console.WriteLine(concretePrototypeA == ConcretePrototypeB);”的输出结果为“False”，输出语句“Console.WriteLine(concretePrototypeA.Member == ConcretePrototypeB.Member);”的输出结果为“True”，表明此处的克隆方法为浅克隆。
除了MemberwiseClone()方法，在C#语言中还提供了一个ICloneable接口，它也可以用来创建当前对象的拷贝，其代码如下：

	//
    // 摘要:
    //     Supports cloning, which creates a new instance of a class with the same value
    //     as an existing instance.
    [ComVisible(true)]
    public interface ICloneable
    {
        //
        // 摘要:
        //     Creates a new object that is a copy of the current instance.
        //
        // 返回结果:
        //     A new object that is a copy of this instance.
        object Clone();
    }
ICloneable接口充当了抽象原型类的角色，具体原型类通常作为实现该接口的子类，如下代码所示：

	public class ConcretePrototypeDeepClone : ICloneable
    {
        public CheryCar SmallCar { get; set; }

        public object Clone()
        {
            ConcretePrototypeDeepClone copy = (ConcretePrototypeDeepClone)this.MemberwiseClone();
            CheryCar newSmallCar = new CheryCar();
            copy.SmallCar = newSmallCar;
            return copy;
        }
    }

客户类代码片段如下：

    ConcretePrototypeDeepClone concretePrototypeA = new ConcretePrototypeDeepClone();
    concretePrototypeA.SmallCar = new CheryCar();

    var ConcretePrototypeB = (ConcretePrototypeDeepClone)concretePrototypeA.Clone();
    Console.WriteLine(concretePrototypeA == ConcretePrototypeB);
    Console.WriteLine(concretePrototypeA.SmallCar == ConcretePrototypeB.SmallCar);

在此客户类代码片段中，输出语句“Console.WriteLine(concretePrototypeA == ConcretePrototypeB);”的输出结果为“False”，输出语句“Console.WriteLine(concretePrototypeA.SmallCar == ConcretePrototypeB.SmallCar);”的输出结果也为“False”，表明此处的克隆方法为深克隆。
在实现ICloneable接口时，通常提供的是除MemberwiseClone()以外的深克隆方法。除了通过直接创建新的成员对象来手工实现深克隆外，还可以通过反射、序列化等方式来实现深克隆，在使用序列化实现时要求所有被引用的对象都必须是可序列化的(Serializable)。此处不在赘述。

### 原型模式的优缺点
**原型模式的优点有**：
- 原型模式向客户隐藏了创建新实例的复杂性
- 原型模式允许动态增加或较少产品类。
- 原型模式简化了实例的创建结构，工厂方法模式需要有一个与产品类等级结构相同的等级结构，而原型模式不需要这样。
- 产品类不需要事先确定产品的等级结构，因为原型模式适用于任何的等级结构

**原型模式的缺点有**：
- 每个类必须配备一个克隆方法
- 配备克隆方法需要对类的功能进行通盘考虑，这对于全新的类不是很难，但对于已有的类不一定很容易，特别当一个类引用不支持串行化的间接对象，或者引用含有循环结构的时候。

### 总结
到这里关于原型模式的介绍就结束了，原型模式用一个原型对象来指明所要创建的对象类型，然后用复制这个原型对象的方法来创建出更多的同类型对象，它与工厂方法模式的实现非常相似，其中原型模式中的Clone方法就类似工厂方法模式中的工厂方法，只是工厂方法模式的工厂方法是通过new运算符重新创建一个新的对象（相当于原型模式的深拷贝实现），而原型模式是通过调用MemberwiseClone方法来对原来对象进行拷贝，也就是复制，同时在原型模式优点中也介绍了与工厂方法的区别（第三点）。