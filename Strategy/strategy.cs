using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Skeleton
{

    interface IStrategy {
        int Move(Context c);
    }

    class Context {
        public const int start = 5;
        public int Counter = 5;

        IStrategy strategy = new Strategy1();

        public int Algorithm() {
            return strategy.Move(this);
        }

        public void Switch_Strategy() {
            if(strategy is Strategy1) {
                strategy = new Strategy2();
            } else {
                strategy = new Strategy1();
            }
        }
    }

    class Strategy1 : IStrategy {
        public int Move(Context c) {
            return ++c.Counter;
        }
    }

    class Strategy2 : IStrategy {
        public int Move(Context c) {
            return --c.Counter;
        }
    }


    static class Program {
        static void Main() {
            Context context = new Context();
            context.Switch_Strategy();
            Random r = new Random(37);
            for( int i = Context.start; i <= Context.start+15; ++i) {
                if(r.Next(3) == 2) {
                    Console.Write("|| ");
                    context.Switch_Strategy();
                }
                Console.Write(context.Algorithm() + " ");
            }
            Console.WriteLine();
        }
    }
}
