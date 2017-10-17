using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer.Next
{
    public class Subscriber : IObserver
    {
        public string Name { get; set; }

        public Subscriber(string name)
        {
            this.Name = name;
        }

        public void ReceiveAndPrint(AbstractGame game)
        {
            Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, game.Symbol, game.Info);
        }
    }
}
