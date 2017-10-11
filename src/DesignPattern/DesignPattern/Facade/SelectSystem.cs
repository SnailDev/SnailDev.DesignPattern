using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Facade
{
    /// <summary>
    /// 选课系统
    /// </summary>
    public class SelectSystem
    {
        /// <summary>
        /// 验证是否可选
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine($"正在验证课程{courseName}是否人数已满");

            return true;
        }
    }
}
