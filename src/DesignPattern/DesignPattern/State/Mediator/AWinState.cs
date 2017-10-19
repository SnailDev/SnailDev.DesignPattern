using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.State.Mediator
{
    public class AWinState : State
    {
        public AWinState(AbstractMediator concretemediator)
        {
            meditor = concretemediator;
        }

        public override void ChangeMoney(int money)
        {
            foreach (AbstractCardPartner p in meditor.list)
            {
                PartnerA a = p as PartnerA;
                if (a != null)
                {
                    a.Money += money;
                }
                else
                {
                    p.Money -= money;
                }
            }
        }
    }
}
