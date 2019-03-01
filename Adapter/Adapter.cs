using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Skeleton {
    class Adaptee {
        public double Specific_Request(double a, double b) {
            return a / b;
        }
    }

    interface ITarget {
        string Request(int i);
    }

    class Adapter : Adaptee, ITarget {
        public string Request(int i) {
            return "Rough estimate is " + 
                (int)Math.Round(Specific_Request(i, 3));
        }
    }

    class Adapter_Skeleton {
        public static void main() {
            Adaptee first = new Adaptee();
            Console.Write("Before the new standard\nPrecise reading: ");
            Console.WriteLine(first.Specific_Request(5,3));

            ITarget second = new Adapter();
            Console.Write("nMoving to the new standard");
            Console.WriteLine(second.Request(5));

            Console.ReadKey();
        }
    }
}
