using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    public sealed class Singleton_LazyInit
    {
        private Singleton_LazyInit()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Singleton_LazyInit Instance { get { return Nested._instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Singleton_LazyInit _instance = new Singleton_LazyInit();
        }
    }
}
