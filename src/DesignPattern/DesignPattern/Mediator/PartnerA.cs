using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Mediator
{
    /// <summary>
    /// 牌友A
    /// </summary>
    public class PartnerA : AbstractCardPartner
    {
        public override void ChangeMoney(int money, AbstractMediator mediator)
        {
            mediator.AWin(money);
        }

        public override void ChangeMoney(int money, AbstractCardPartner other)
        {
            Money += money;
            other.Money -= money;
        }
    }
}
