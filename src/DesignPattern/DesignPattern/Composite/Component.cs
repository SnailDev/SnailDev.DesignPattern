using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Composite
{
    /// <summary>
    /// 一个抽象构件，声明一个接口用于访问和管理Component的子部件
    /// </summary>
    public abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        ///// <summary>
        ///// 增加一个节点
        ///// </summary>
        ///// <param name="component"></param>
        //public abstract void Add(Component component);

        ///// <summary>
        ///// 移除一个节点
        ///// </summary>
        ///// <param name="component"></param>
        //public abstract void Remove(Component component);

        /// <summary>
        /// 显示层级结构
        /// </summary>
        public abstract void Display(int level);
    }
}
