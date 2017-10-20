using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Strategy
{
    /// <summary>
    /// 抽象策略
    /// </summary>
    public interface ICommunication
    {
        bool Send(object data);
    }
}
