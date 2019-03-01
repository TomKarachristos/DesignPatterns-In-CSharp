using System;

namespace Decorator.Skeleton {
    public interface IComponent {
        string Operation();
    }

    class Component : IComponent {
        public string Operation() {
            return "I am walking";
        }
    }

    // and interface
    class DecoratorA : IComponent {
        // and Aggregation
        IComponent component;

        public DecoratorA(IComponent c) {
            component = c;
        }

        public string Operation() {
            string s = component.Operation();
            s += "and listening to Classic FM";
            return s;
        }
    }

    class DecoratorB : IComponent {
        IComponent component;
        public string add_state = "past the coffe shop";

        public DecoratorB(IComponent c) {
            component = c;
        }

        public string Operation() {
            string s = component.Operation();
            s += "to school";
            return s;
        }

        public string Added_Behavior() {
            return "and I bought a cappucino";
        }
    }

    public class Program {
        static void Display(string s, IComponent c) {
            Console.WriteLine(s + c.Operation());
        }

        public static void Main() {
            Console.WriteLine("Decorator Pattern");
            IComponent component = new Component();
            Display("1. Basic component: ", component);
            Display("2. A-decorated : ", new DecoratorA(component));
            Display("3. B-decorated : ", new DecoratorB(component));
            Display("4. B-A-decorated : ", new DecoratorB(
                new DecoratorA(component))
            );
            // Explicit DecoratorB
            DecoratorB b = new DecoratorB(new Component());
            Display("5. A-B-decorated : ", new DecoratorA(b));
            Console.ReadKey();
        }
    }
}