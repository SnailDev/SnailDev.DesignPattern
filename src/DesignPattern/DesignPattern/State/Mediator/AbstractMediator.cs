using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.State.Mediator
{
    /// <summary>
    /// 抽象中介者类
    /// </summary>
    public abstract class AbstractMediator
    {
        public List<AbstractCardPartner> list = new List<AbstractCardPartner>();

        public State State { get; set; }

        public AbstractMediator(State state)
        {
            State = state;
        }

        public void Add(AbstractCardPartner partner)
        {
            list.Add(partner);
        }

        public void Remove(AbstractCardPartner partner)
        {
            list.Remove(partner);
        }

        public void ChangeMoney(int money)
        {
            State.ChangeMoney(money);
        }
    }
}
