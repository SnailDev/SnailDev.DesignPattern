using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    /// <summary>
    /// .NET 4's Lazy<T> type
    /// </summary>
    public sealed class Singleton_LazyType
    {
        private static readonly Lazy<Singleton_LazyType> lazy =
            new Lazy<Singleton_LazyType>(() => new Singleton_LazyType());

        public static Singleton_LazyType Instance { get { return lazy.Value; } }

        private Singleton_LazyType()
        {
        }
    }
}
