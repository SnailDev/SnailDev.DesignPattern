using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Command
{
    /// <summary>
    /// 具体命令类，实现具体命令。
    /// </summary>
    public class ConcereteCommand : ICommand
    {
        // 具体命令类包含有一个接收者，将这个接收者对象绑定于一个动作
        private Receiver receiver;

        public ConcereteCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        /// <summary>
        /// 说这个实现是“虚”的，因为它是通过调用接收者相应的操作来实现Execute的
        /// </summary>
        public void Execute()
        {
            receiver.Action();
        }
    }
}
