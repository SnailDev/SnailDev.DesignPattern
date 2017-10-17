using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer.First
{
    /// <summary>
    /// 订阅者类
    /// </summary>
    public class Subscriber
    {
        public string Name { get; set; }

        public Subscriber(string name)
        {
            this.Name = name;
        }

        public void ReceiveAndPrintData(QQGame game)
        {
            Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, game.Symbol, game.Info);
        }
    }
}
