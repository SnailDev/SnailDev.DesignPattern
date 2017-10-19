using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.State
{
    /// <summary>
    /// 具体状态类，每一个子类实现一个与Context的一个状态相关的行为
    /// </summary>
    public class ConcreteStateB : State
    {
        /// <summary>
        /// 设置ConcreteStateB的下一个状态是ConcreteSateA
        /// </summary>
        /// <param name="context"></param>
        public override void Handle(Context context)
        {
            Console.WriteLine("当前状态是 B.");
            context.State = new ConcreteStateA();
        }
    }
}
