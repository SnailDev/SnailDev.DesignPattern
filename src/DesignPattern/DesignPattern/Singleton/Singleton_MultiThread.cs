using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    /// <summary>
    /// 单例模式（确保一个类只有一个实例，并提供一个全局访问点，线程同步）
    /// </summary>
    public sealed class Singleton_MultiThread
    {
        /// <summary>
        /// 私有静态变量保存类的唯一实例
        /// </summary>
        private static Singleton_MultiThread uniqueInstance;

        /// <summary>
        /// 锁，确保线程同步
        /// </summary>
        private static readonly object locker = new object();

        /// <summary>
        /// 私有构造方法，避免外部 new
        /// </summary>
        private Singleton_MultiThread() { }

        /// <summary>
        /// 暴露全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton_MultiThread GetInstance1()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            lock (locker)
            {
                if (uniqueInstance == null)
                    uniqueInstance = new Singleton_MultiThread();
            }

            return uniqueInstance;
        }

        /// <summary>
        /// 暴露全局访问点(双重锁定，减小开销，提升性能)
        /// </summary>
        /// <returns></returns>
        public static Singleton_MultiThread GetInstance2()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要加一句判断就可以了
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    if (uniqueInstance == null)
                        uniqueInstance = new Singleton_MultiThread();
                }
            }

            return uniqueInstance;
        }
    }
}
