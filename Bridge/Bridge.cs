using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Skeleton {
    class Abstraction {
        Bridge bridge;

        public Abstraction(Bridge implementation) {
            bridge = implementation;
        }

        // bridge change the interface??? why???? its already a interaface common
        // CHECK Bridge can offering same, different or extended interface
        // kathe methodos mpori kiolas na elegxi pio bridge me simferi na sikoso?
        public string Operation() {
            // new functionality? yes
            // the Abstraction can examine
            // the properties of the one or more Bridge instances (drivers) it is holding and select
            // the most appropriate one for the task
            return "Abstraction" + " <<< BRidge >>> " + bridge.Operation_Imp();
        }
    }

    interface Bridge {
        string Operation_Imp();
    }

    // here is something we do eg. display graphics
    class ImplementationA : Bridge {
        public string Operation_Imp() {
            return "ImplementationA";
        }
    }

    // here is a OS or a driver for graphics
    class ImplementationB : Bridge {
        public string Operation_Imp() {
            return "ImplementationB";
        }
    }

    class Program {
        static void Main() {
            Console.WriteLine("Bridge Patter");
            Console.WriteLine(new Abstraction(
                    new ImplementationA()
                ).Operation());
            Console.WriteLine(new Abstraction(
                    new ImplementationB()
                ).Operation());
        }
    }
}
