using DesignPattern.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.State.Mediator
{
    // 抽象状态类
    public abstract class State
    {
        protected AbstractMediator meditor;

        public abstract void ChangeMoney(int money);
    }
}
