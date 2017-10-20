using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Strategy
{
    /// <summary>
    /// 上下文环境
    /// </summary>
    public class Context
    {
        private ICommunication _communication;

        public void SetStrategy(ICommunication communication)//传递具体的策略
        {
            this._communication = communication;
        }

        public bool Send(object data)
        {
            return this._communication.Send(data);
        }
    }
}
