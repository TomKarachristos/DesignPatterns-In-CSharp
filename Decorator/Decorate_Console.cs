using Decorator.Skeleton;
using System;

namespace Decorator.New_Console {
    // faild try, decoratero console 
    interface I_New_Console {
        void Wrtie_Line(string value);
        void Write(string value);
    }

    // failed try
    class Background_Color_I : I_New_Console {
        // pos tha to perasis san metavliti afou to console einai static?

        public void Write(string value) {
            //To provlima me to interface einai oti tora
            // prepei na kaleso to Console.write
            // Alla ama exou dio decorator, tha to kaloune kai ta
            // dio arra den eiani decorator einai proxy
            // kai den mporis na vazis dinamika pragmata
            // prepei na exeis ena interface na kalis
            // alla episis prepei na exeis mia aggragate metavliti
            // na kanis decorator
        }

        public void Wrtie_Line(string value) {

        }
    }

    class New_Console {

        public virtual void WriteLine(string value) {
            Console.WriteLine(value);
        }

        public virtual void Write(string value) {
            Console.WriteLine(value);
        }
    }

    class Background_Color : New_Console {
        private New_Console decorate_console;

        public Background_Color(New_Console console) {
            this.decorate_console = console;
        }

        public override void Write(string value) {
            Console.BackgroundColor = ConsoleColor.Blue;
            decorate_console.Write(value);
        }

        public override void WriteLine(string value) {
            Console.BackgroundColor = ConsoleColor.Red;
            decorate_console.WriteLine(value);
        }
    }

    class Text_Color : New_Console {
        private New_Console decorate_console;

        public Text_Color(New_Console console) {
            decorate_console = console;
        }

        public override void WriteLine(string value) {
            Console.ForegroundColor = ConsoleColor.Blue;
            decorate_console.WriteLine(value);
        }
    }

    class Program {
        private static New_Console new_Console;

        static void Display(string s, IComponent c) {
            new_Console.WriteLine(s + c.Operation());
        }

        public static void Main() {
            new_Console = new Background_Color(new New_Console());
            new_Console = new Text_Color(new_Console);
            new_Console.WriteLine("Decorator Pattern\n");

            IComponent component = new Component();
            Display("1. Basic component: ", component);
            Display("2. A-decorated : ", new DecoratorA(component));
            Display("3. B-decorated : ", new DecoratorB(component));
            Display("4. B-A-decorated : ", new DecoratorB(
            new DecoratorA(component)));
            // Explicit DecoratorB
            DecoratorB b = new DecoratorB(new Component());
            Display("5. A-B-decorated : ", new DecoratorA(b));
            // Invoking its added state and added behavior
            new_Console.WriteLine("\t\t\t" + b.add_state + b.Added_Behavior());
            Console.ReadKey();

        }
    }

}