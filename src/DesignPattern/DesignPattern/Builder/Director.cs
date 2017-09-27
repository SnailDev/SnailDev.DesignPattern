using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 指挥者
    /// </summary>
    public class Director
    {
        /// <summary>
        /// 组装汽车
        /// </summary>
        /// <param name="builder"></param>
        public void AssemblyCar(Builder builder)
        {
            builder.AssemblyEngines();
            builder.AssemblyTransmissions();
        }
    }
}
