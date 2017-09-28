using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
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
}
