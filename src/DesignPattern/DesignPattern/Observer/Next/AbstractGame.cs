using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer.Next
{
    public abstract class AbstractGame
    {
        // 订阅者列表
        private List<IObserver> observers = new List<IObserver>();

        public string Symbol { get; set; }

        public string Info { get; set; }

        public AbstractGame(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }

        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }

        public void Update()
        {
            foreach (var ob in observers)
            {
                if (ob != null)
                {
                    ob.ReceiveAndPrint(this);
                }
            }
        }
    }
}
