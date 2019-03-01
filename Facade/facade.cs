using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Facade.Skeleton {

    namespace Library {
        internal class SubsystemA {
            internal string A1() {
                return "Subsystem A, Method A1\n";
            }
            internal string A2() {
                return "Subsystem A, Method A2\n";
            }
        }
        internal class SubsystemB {
            internal string B1() {
                return "Subsystem B, Method B1\n";
            }
        }
        internal class SubsystemC {
            internal string C1() {
                return "Subsystem C, Method C1\n";
            }
        }
    }

    public static class Facade {
        static Library.SubsystemA a = new Library.SubsystemA();
        static Library.SubsystemB b = new Library.SubsystemB();
        static Library.SubsystemC c = new Library.SubsystemC();
        public static void Operation1() {
            Console.WriteLine("Operation 1\n" +
            a.A1() +
            a.A2() +
            b.B1());
        }
        public static void Operation2() {
            Console.WriteLine("Operation 2\n" +
            b.B1() +
            c.C1());
        }
    }

    class Program {

        static void Main() {
            Facade.Operation1();
            Facade.Operation2();
        }
    }
}
