using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 大型汽车
    /// </summary>
    public class BigCar
    {
        /// <summary>
        /// 汽车零部件集合
        /// </summary>
        private IList<string> parts = new List<string>();

        /// <summary>
        /// 汽车零部件组装
        /// </summary>
        /// <param name="part"></param>
        public void AddPart(string part)
        {
            parts.Add(part);
        }

        /// <summary>
        /// 执行组装动作
        /// </summary>
        public void DoAssembly()
        {
            Console.WriteLine("汽车开始组装......");

            foreach (var part in parts)
            {
                Console.WriteLine("部件：" + part + "----已装好");
            }

            Console.WriteLine("汽车组装完成");
        }
    }
}
