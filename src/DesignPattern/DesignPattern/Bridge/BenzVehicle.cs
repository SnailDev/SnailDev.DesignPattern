using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Bridge
{
    /// <summary>
    /// 奔驰汽车
    /// </summary>
    public class BenzVehicle : VehicleBrand
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
