/*
 * The singleton pattern is one of the best-known patterns in software engineering. 
 * Essentially, a singleton is a class which only allows a single instance of itself to be created,
 * and usually gives simple access to that instance. 
 * http://csharpindepth.com/Articles/General/Singleton.aspx
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Typically a requirement of singletons is that they are created lazily - 
    // i.e. that the instance isn't created until it is first needed.

    /*
     * not quite as lazy, but thread-safe without using locks
     */
    public sealed class SingletonNoLazy
    {
        private static readonly SingletonNoLazy instance = new SingletonNoLazy();

        // static constructors in C# are specified to execute only when an instance of the class
        // is created or a static member is referenced, and to execute only once per AppDomain. 
        static SingletonNoLazy()
        {
            // not to mark type as beforefieldinit
            // http://csharpindepth.com/Articles/General/BeforeFieldInit.aspx
        }

        private SingletonNoLazy()
        {
        }

        public static SingletonNoLazy Instance
        {
            get
            {
                return instance;
            }
        }
    }


    public sealed class SingletonBest
    {
        private SingletonBest()
        {
        }

        public static SingletonBest Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly SingletonBest instance = new SingletonBest();
        }
    }


    public sealed class SingletonNet4
    {
        private static readonly Lazy<SingletonNet4> lazy =
            new Lazy<SingletonNet4>(() => new SingletonNet4());

        public static SingletonNet4 Instance { get { return lazy.Value; } }

        private SingletonNet4()
        {
        }
    }
}
