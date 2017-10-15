using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Command
{
    /// <summary>
    /// 调度类，要求该命令执行这个请求
    /// </summary>
    public class Invoker
    {
        private ICommand command;

        /// <summary>
        /// 设置命令
        /// </summary>
        /// <param name="command"></param>
        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}
