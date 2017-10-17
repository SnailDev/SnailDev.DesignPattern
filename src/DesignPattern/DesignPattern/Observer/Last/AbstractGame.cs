using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer.Last
{
    public abstract class AbstractGame
    {
        // 委托充当订阅者接口类
        public delegate void NotifyEventHandler(object sender);

        public NotifyEventHandler NotifyEvent;

        public string Symbol { get; set; }

        public string Info { get; set; }

        public AbstractGame(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        public void AddObserver(NotifyEventHandler ob)
        {
            NotifyEvent += ob;
        }

        public void RemoveObserver(NotifyEventHandler ob)
        {
            NotifyEvent -= ob;
        }

        public void Update()
        {
            if (NotifyEvent != null)
            {
                NotifyEvent(this);
            }
        }
    }
}
