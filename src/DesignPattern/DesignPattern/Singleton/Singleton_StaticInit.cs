using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    public sealed class Singleton_StaticInit
    {
        private static readonly Singleton_StaticInit _instance = new Singleton_StaticInit();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton_StaticInit()
        {
        }

        /// <summary>
        /// Prevents a default instance of the 
        /// <see cref="Singleton_StaticInit"/> class from being created.
        /// </summary>
        private Singleton_StaticInit()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Singleton_StaticInit GetInstance
        {
            get
            {
                return _instance;
            }
        }
    }
}
