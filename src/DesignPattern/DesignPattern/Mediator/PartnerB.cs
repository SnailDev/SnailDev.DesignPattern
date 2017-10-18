using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Mediator
{
    /// <summary>
    /// 牌友B
    /// </summary>
    public class PartnerB : AbstractCardPartner
    {
        public override void ChangeMoney(int money, AbstractMediator mediator)
        {
            mediator.BWin(money);
        }

        public override void ChangeMoney(int money, AbstractCardPartner other)
        {
            Money += money;
            other.Money -= money;
        }
    }
}
