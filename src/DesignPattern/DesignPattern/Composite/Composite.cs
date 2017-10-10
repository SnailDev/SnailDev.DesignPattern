using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Composite
{
    /// <summary>
    /// 定义有枝节点的行为，用来存储部件，实现在Component接口中对子部件有关的操作
    /// </summary>
    public class Composite : Component
    {
        public Composite(string name)
            : base(name)
        { }

        /// <summary>
        /// 一个子对象集合，用来存储其下属的枝节点和叶节点
        /// </summary>
        private List<Component> children = new List<Component>();

        /// <summary>
        /// 增加子节点
        /// </summary>
        /// <param name="component"></param>
        public  void Add(Component component)
        {
            children.Add(component);
        }

        /// <summary>
        /// 移除子节点
        /// </summary>
        /// <param name="component"></param>
        public  void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int level)
        {
            Console.WriteLine(new string('-', level) + name);

            // 遍历其子节点并显示
            foreach (Component component in children)
            {
                component.Display(level + 2);
            }
        }
    }
}
