using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    /// <summary>
    /// 单例模式（确保一个类只有一个实例，并提供一个全局访问点）
    /// </summary>
    public sealed class Singleton
    {
        /// <summary>
        /// 私有静态变量保存类的唯一实例
        /// </summary>
        private static Singleton uniqueInstance;

        /// <summary>
        /// 私有构造方法，避免外部 new
        /// </summary>
        private Singleton() { }

        /// <summary>
        /// 暴露全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance()
        {
            if (uniqueInstance == null)
                uniqueInstance = new Singleton();

            return uniqueInstance;
        }
    }
}
