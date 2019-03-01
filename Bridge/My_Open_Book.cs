using Proxy.Space_Book_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.My_Open_Book{

    class My_Open_Book {
    }

    // Bridge defines the operations that will be supported by all Portal members
    interface IBridge {
        void Add(string message);
        void Add(string friend, string message);
        void Poke(string who);
    }

    // To portal(abstraction) periexei oli tin litourgikotita pou theloume
    // to bridge periexei mono auti pou pernoume.
    class Portal {
        IBridge bridge;

        public Portal(IBridge aSpaceBook) {
            this.bridge = aSpaceBook;

        }

        public void Add(string message) { bridge.Add(message); }
        public void Add(string friend, string message) { bridge.Add(friend, message); }
        public void Poke(string who) { bridge.Poke(who); }

        // Add the new operation to the Portal (Abstraction), but not to the Bridge, so it
        // does not affect other implementations
    }

    // Add the new operation to the Portal (Abstraction), 
    // but not to the Bridge, so it does not affect other implementations
    public class MyOpenBook : IBridge {

        // Combination of a virtual and authentication proxy
        Space_Book_Community mySpaceBook;
        string name;
        static int users;
        public MyOpenBook(string n) {
            name = n;
            users++;
            mySpaceBook = new Space_Book_Community(name + "-" + users);
        }
        public void Add(string message) {
            mySpaceBook.Add(message);
        }
        public void Add(string friend, string message) {
            mySpaceBook.Add(friend, name + " said: " + message);
        }
        public void Poke(string who) {
            mySpaceBook.Poke(who, name);
        }
    }

    // If we cannot alter the Portal, we can create an extension method to extend it as follows
    static class OpenBookExtensions {
        public static void SuperPoke(this Portal me, string who, string what) {
            me.Add(who, what + " you");
        }
    }

    class Program {

        public static void main() {
            // change this
            var me = new Space_Book_Community("tommas");
            me.Add("Hello world");
            me.Add("Today I worked 18 hours");

            var tom = new Portal(new MyOpenBook("Tom"));
            tom.Poke("tommas");
            tom.SuperPoke("tommas","hugged");
            tom.Add("tommas", "Poor you");
            tom.Add("Off to see the Lion King tonight");

            Console.ReadKey();
        }
    }

}
