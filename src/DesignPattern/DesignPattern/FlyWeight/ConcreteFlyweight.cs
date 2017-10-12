using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FlyWeight
{
    /// <summary>
    /// 具体享元对象
    /// </summary>
    public class ConcreteFlyweight : Flyweight
    {
        /// <summary>
        /// 内部状态
        /// </summary>
        private string intrinsicstate;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="innerState"></param>
        public ConcreteFlyweight(string innerState)
        {
            this.intrinsicstate = innerState;
        }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="extrinsicaste">外部状态</param>
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine($"具体实现类: intrinsicstate {intrinsicstate}, extrinsicstate {extrinsicstate}");
        }
    }
}
