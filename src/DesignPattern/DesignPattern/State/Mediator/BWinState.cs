using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.State.Mediator
{
    public class BWinState : State
    {
        public BWinState(AbstractMediator concretemediator)
        {
            meditor = concretemediator;
        }

        public override void ChangeMoney(int money)
        {
            foreach (AbstractCardPartner p in meditor.list)
            {
                PartnerB b = p as PartnerB;
                // 如果集合对象中时B对象，则对B的钱添加
                if (b != null)
                {
                    b.Money += money;
                }
                else
                {
                    p.Money -= money;
                }
            }
        }
    }
}
