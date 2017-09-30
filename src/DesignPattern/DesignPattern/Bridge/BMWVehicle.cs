using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Bridge
{
    /// <summary>
    /// 宝马汽车
    /// </summary>
    public class BMWVehicle : VehicleBrand
    {
        public override void InstallNavigator(INavigator navigator)
        {
            this.navigator = navigator;
        }

        public override void OpenNavigator()
        {
            navigator.Work();
        }
    }
}
