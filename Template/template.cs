using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
   interface IPrimitives {
        string Operation1();
        string Operation2();
    }

    class Algorithm {
        public void Template_Method(IPrimitives a) {
            var s = a.Operation1() + a.Operation2();
            Console.WriteLine(s);
        }
    }


    class Class_A : IPrimitives {
        public string Operation1() {
            return "ClassA:Op1 ";
        }

        public string Operation2() {
            return "ClassA:Op2 ";
        }
    }

    class Class_B : IPrimitives {
        public string Operation1() {
            return "ClassB:Op1 ";
        }

        public string Operation2() {
            return "ClassB.Op2 ";
        }
    }

    class Program {
        static void Main() {
            Algorithm m = new Algorithm();

            m.Template_Method(new Class_A());
            m.Template_Method(new Class_B());
        }
    }
}
