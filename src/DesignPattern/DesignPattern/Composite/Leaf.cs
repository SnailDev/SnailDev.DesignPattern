using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Composite
{
    /// <summary>
    /// 叶子节点
    /// </summary>
    public class Leaf : Component
    {
        public Leaf(string name)
            : base(name)
        { }

        ///// <summary>
        ///// 由于叶子节点没有子节点，所以Add和Remove方法对它来说没有意义，但它继承自Component，这样做可以消除叶节点和枝节点对象在抽象层次的区别，它们具备完全一致的接口。
        ///// </summary>
        ///// <param name="component"></param>
        //public override void Add(Component component)
        //{
        //    Console.WriteLine("Can not add a component to a leaf.");
        //}

        ///// <summary>
        ///// 实现它没有意义，只是提供了一个一致的调用接口
        ///// </summary>
        ///// <param name="component"></param>
        //public override void Remove(Component component)
        //{
        //    Console.WriteLine("Can not remove a component to a leaf.");
        //}

        public override void Display(int level)
        {
            Console.WriteLine(new string('-', level) + name);
        }
    }
}
