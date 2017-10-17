using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer.First
{
    /// <summary>
    /// QQ游戏公众号
    /// </summary>
    public class QQGame
    {
        /// <summary>
        /// 订阅对象
        /// </summary>
        public Subscriber Subscriber { get; set; }

        public string Symbol { get; set; }

        public string Info { get; set; }

        public QQGame(string symbol,string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        public void Update()
        {
            if (Subscriber!=null)
            {
                Subscriber.ReceiveAndPrintData(this);
            }
        }
    }
}
