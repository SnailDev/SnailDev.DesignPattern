using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Facade
{
    /// <summary>
    /// 通知系统
    /// </summary>
    public class NotifySystem
    {
        /// <summary>
        /// 发起通知
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public bool Notify(string studentName)
        {
            Console.WriteLine($"正在向{studentName}发生通知");
            return true;
        }
    }
}
