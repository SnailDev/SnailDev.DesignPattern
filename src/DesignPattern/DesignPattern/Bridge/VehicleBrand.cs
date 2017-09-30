using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Bridge
{
    /// <summary>
    /// 汽车品牌抽象类
    /// </summary>
    public abstract class VehicleBrand
    {
        protected INavigator navigator;

        /// <summary>
        /// 安装导航
        /// </summary>
        /// <param name="navigator"></param>
        public abstract void InstallNavigator(INavigator navigator);

        /// <summary>
        /// 打开导航
        /// </summary>
        public abstract void OpenNavigator();
    }
}
