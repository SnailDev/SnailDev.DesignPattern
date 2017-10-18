using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Mediator
{
    /// <summary>
    /// 中介者Pater
    /// </summary>
    public class MediatorPater : AbstractMediator
    {
        public MediatorPater(AbstractCardPartner a, AbstractCardPartner b) 
            : base(a, b)
        {

        }

        public override void AWin(int money)
        {
            A.Money += money;
            B.Money -= money;
        }

        public override void BWin(int money)
        {
            A.Money -= money;
            B.Money += money;
        }
    }
}
