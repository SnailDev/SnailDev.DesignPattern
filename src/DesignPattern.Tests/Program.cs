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
            //Console.WriteLine(Singleton.GetInstance());
            //var haha = 123456;
            //Console.WriteLine($"Excuted Failed,Message: ({haha})");

            //BuilderInvoke();
            PrototypeInvoke();
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
    }
}
