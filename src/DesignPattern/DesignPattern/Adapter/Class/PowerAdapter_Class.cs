using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 定义电源适配器，继承适配的类和目标接口
    /// </summary>
    public class PowerAdapter_Class : Adaptee, ITarget
    {
        /// <summary>
        /// 实现目标接口方法
        /// </summary>
        public void Request()
        {
            this.SpecificRequest();
        }
    }
}
