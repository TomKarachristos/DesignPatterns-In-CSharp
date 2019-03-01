using System;
using System.Collections.Generic;

namespace Proxy.Space_Book_System {

    interface IInteract {
        void Add(string s);
        void Add(string frind, string message);
        void Poke(string who, string friend);
    }

    public class Space_Book_Person {
        string pages;
        string name;
        string gap = "\n\t\t\t\t";
        public string Pages { get => pages; set => pages = value; }
        public string Name { get => name; set => name = value; }

        public Space_Book_Person(string name) {
            this.name = name;
        }

        public void Add(string s) {
            Pages += gap + s;
            Console.WriteLine(gap + "======== " + Name + "'s SpaceBook =========");
            Console.WriteLine(Pages);
            Console.WriteLine(gap + "==========================");
        }
    }

    public class Space_Book_Community : IInteract {
        static SortedList<string, Space_Book_Person> community =
            new SortedList<string, Space_Book_Person>(100);
        public Space_Book_Person person;
        string gap = "\n\t\t\t\t";

        static public bool Is_Unique(string name) {
            return community.ContainsKey(name);
        }

        internal Space_Book_Community(string name) {
            person = new Space_Book_Person(name);
            community[name] = person;
        }

        public void Add(string friend, string message) {
            community[friend].Add(message);
        }

        public void Poke(string who, string friend) {
            community[who].Pages += gap + friend + "poked you";
        }

        public void Add(string s) {
            person.Add(s);
        }
    }

    // The Proxy, my space book name in the book
    public class Proxy_Space_Book : IInteract {
        // Combination of a virtual and authentication proxy
        Space_Book_Community mySpaceBook;
        string password;
        string name;
        bool loggedIn = false;

        void Register() {
            Console.WriteLine("Let's register you for SpaceBook");
            do {
                Console.WriteLine("All SpaceBook names must be unique");
                Console.Write("Type in a user name: ");
                name = Console.ReadLine();
            } while (Space_Book_Community.Is_Unique(name));
            Console.Write("Type in a password: ");
            password = Console.ReadLine();
            Console.WriteLine("Thanks for registering with SpaceBook");
        }

        bool Authenticate() {
            Console.Write("Welcome " + name + ". Please type in your password: ");
            var supplied = Console.ReadLine();
            if (supplied == password) {
                loggedIn = true;
                Console.WriteLine("Logged into SpaceBook");
                if (mySpaceBook == null)
                    mySpaceBook = new Space_Book_Community(name);
                return true;
            }
            Console.WriteLine("Incorrect password");
            return false;
        }

        public void Add(string message) {
            Check();
            if (loggedIn) mySpaceBook.Add(message);
        }

        public void Add(string friend, string message) {
            Check();
            if (loggedIn)
                mySpaceBook.Add(friend, name + " said: " + message);
        }

        public void Poke(string who) {
            Check();
            if (loggedIn)
                mySpaceBook.Poke(who, name);
        }

        void Check() {
            if (!loggedIn) {
                if (password == null)
                    Register();
                if (mySpaceBook == null)
                    Authenticate();
            }
        }

        // Beacuse the proxy_Space_book dont have the same interface
        // cause he is know that 
        public void Poke(string who, string friend) {
            throw new NotImplementedException();
        }
    }
}

namespace Proxy.Space_Book_System {

    // or using static Space_Book_System
    // using static Space_Book_System;
    class Program {

        public static void Main() {
            // write tommas for your first name
            var me = new Proxy_Space_Book();
            me.Add("Hello world");
            me.Add("Today I worked 18 hours");
            var tom = new Proxy_Space_Book();
            tom.Poke("tommas");
            tom.Add("tommas", "Poor you");
            tom.Add("Off to see the Lion King tonight");
            Console.ReadKey();
        }
    }
}