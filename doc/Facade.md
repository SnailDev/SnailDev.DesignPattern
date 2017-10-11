# 外观模式
### 什么是外观模式？
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Facade1.png)
外观模式提供了一个统一的接口，用来访问子系统中的一群接口。外观定义了一个高层接口，让子系统更容易使用。使用外观模式时，我们创建了一个统一的类，用来包装子系统中一个或多个复杂的类，客户端可以直接通过外观类来调用内部子系统中方法，从而外观模式让客户和子系统之间避免了紧耦合。
- 门面（Facade）角色：客户端调用这个角色的方法。该角色知道相关的一个或多个子系统的功能和责任，该角色会将从客户端发来的请求委派带相应的子系统中去。
- 子系统（subsystem）角色：可以同时包含一个或多个子系统。每个子系统都不是一个单独的类，而是一个类的集合。每个子系统都可以被客户端直接调用或被门面角色调用。对于子系统而言，门面仅仅是另外一个客户端，子系统并不知道门面的存在。

### 设计思路及代码实现
我们以大学生选课为例，该示例中涉及到两个子系统，一个是选课系统，一个是通知系统，一般的实现代码如下：

	/// <summary>
    /// 选课系统
    /// </summary>
    public class SelectSystem
    {
        /// <summary>
        /// 验证是否可选
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine($"正在验证课程{courseName}是否人数已满");

            return true;
        }
    }

	/// <summary>
    /// 通知系统
    /// </summary>
    public class NotifySystem
    {
        /// <summary>
        /// 发起通知
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public bool Notify(string studentName)
        {
            Console.WriteLine($"正在向{studentName}发生通知");
            return true;
        }
    }

	/// <summary>
    /// 客户端调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
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

        Console.ReadLine();
    }

这种代码客户端与子系统过度耦合， 而外观模式就是为了解决这一问题。
![](http://owvsetuqu.bkt.clouddn.com/image/designpattern/Facade2.png)

	/// <summary>
    /// 选课系统
    /// </summary>
    public class SelectSystem
    {
        /// <summary>
        /// 验证是否可选
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine($"正在验证课程{courseName}是否人数已满");

            return true;
        }
    }

	/// <summary>
    /// 通知系统
    /// </summary>
    public class NotifySystem
    {
        /// <summary>
        /// 发起通知
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public bool Notify(string studentName)
        {
            Console.WriteLine($"正在向{studentName}发生通知");
            return true;
        }
    }

	/// <summary>
    /// 选课外观模式（中间件）
    /// </summary>
    public class SelectCourseFacade
    {
        private SelectSystem selectSystem;
        private NotifySystem notifySystem;

        public SelectCourseFacade()
        {
            selectSystem = new SelectSystem();
            notifySystem = new NotifySystem();
        }

        /// <summary>
        /// 选课
        /// </summary>
        /// <param name="courseName"></param>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public bool SelectCourse(string courseName, string studentName)
        {
            if (!selectSystem.CheckAvailable(courseName))
            {
                return false;
            }

            return notifySystem.Notify(studentName);
        }
    }

	/// <summary>
    /// 客户端调用
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
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

        Console.ReadLine();
    }
使用了外观模式之后，客户端只依赖与外观类，从而将客户端与子系统的依赖解耦了，如果子系统发生改变，此时客户端的代码并不需要去改变。外观模式的实现核心主要是——由外观类去保存各个子系统的引用，实现由一个统一的外观类去包装多个子系统类，然而客户端只需要引用这个外观类，然后由外观类来调用各个子系统中的方法。然而这样的实现方式非常类似适配器模式，不同的是：适配器模式是将一个对象包装起来以改变其接口，而外观是将一群对象 ”包装“起来以简化其接口。它们的意图是不一样的，适配器是将接口转换为不同接口，而外观模式是提供一个统一的接口来简化接口。

### 外观模式的优缺点
**优点：**
- 外观模式对客户屏蔽了子系统组件，从而简化了接口，减少了客户处理的对象数目并使子系统的使用更加简单。
- 外观模式实现了子系统与客户之间的松耦合关系，而子系统内部的功能组件是紧耦合的。松耦合使得子系统的组件变化不会影响到它的客户。
 
**缺点：** 如果增加新的子系统可能需要修改外观类或客户端的源代码，这样就违背了”开——闭原则“（不过这点也是不可避免）。

### 外观模式的使用场景
在以下情况下可以考虑使用外观模式：
- 需要为一个复杂的子系统提供一个简单的接口
- 提供子系统的独立性
- 在层次化结构中，可以使用外观模式定义系统中每一层的入口。三层架构也是这样的一个例子。
