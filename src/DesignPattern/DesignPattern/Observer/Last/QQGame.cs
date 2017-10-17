using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer.Last
{
    public class QQGame : AbstractGame
    {
        public QQGame(string symbol, string info)
            : base(symbol, info)
        {
        }
    }
}
