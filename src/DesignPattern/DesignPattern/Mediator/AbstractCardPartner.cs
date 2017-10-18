using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Mediator
{
    /// <summary>
    /// 抽象牌友类
    /// </summary>
    public abstract class AbstractCardPartner
    {
        public int Money { get; set; }

        public abstract void ChangeMoney(int money, AbstractCardPartner other);

        public abstract void ChangeMoney(int money, AbstractMediator mediator);
    }
}
