using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.State.Mediator
{
    /// <summary>
    /// 中介者Pater
    /// </summary>
    public class MediatorPater : AbstractMediator
    {
        public MediatorPater(State state) : base(state)
        {
        }
    }
}
