using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer.Next
{
    public interface IObserver
    {
        void ReceiveAndPrint(AbstractGame game);
    }
}
