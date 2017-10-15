using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Command
{
    /// <summary>
    /// 抽象命令类，用来声明执行操作的接口
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }
}
