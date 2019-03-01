using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Skeleton {
    public interface IComponent<T> {
        void Add(IComponent<T> c);
        IComponent<T> Remove(T s);
        IComponent<T> Find(T s);
        String Display(int depth);
        T Name { get; set; }
    }

    public class Component<T> : IComponent<T> {
        public T Name { get; set; }

        public Component(T name) {
            this.Name = name;
        }

        public void Add(IComponent<T> c) {
            Console.WriteLine("Cant add");
        }

        public IComponent<T> Remove(T s) {
            Console.WriteLine("i dont remove");
            return this;
        }

        public string Display(int depth) {
            return new String('-', depth) + Name + "\n";
        }

        public IComponent<T> Find(T s) {
            if (s.Equals(Name)) {
                return this;
            } else {
                return null;
            }
        }
    }


    public class Composite<T> : IComponent<T> {
        public T Name { get; set; }
        private List<IComponent<T>> list;

        public Composite(T name) {
            this.Name = name;
            this.list = new List<IComponent<T>>();
        }

        public void Add(IComponent<T> c) {
            list.Add(c);
        }

        public string Display(int depth) {
            StringBuilder s = new StringBuilder(new String('-', depth));
            s.Append("Set " + Name + " length :" + list.Count + "\n");
            foreach (IComponent<T> component in list) {
                s.Append(component.Display(depth + 2));
            }
            return s.ToString();
        }

        public IComponent<T> Find(T s) {
            if (this.Name.Equals(s)) {
                return this;
            } else {
                IComponent<T> found = null;
                foreach (IComponent<T> item in list) {
                    found = item.Find(s);
                    if (found != null) break;
                }
                return found;
            }
        }

        public IComponent<T> Remove(T s) {
            var found = this.Find(s);
            if (found != null) {
                this.list.Remove(found);
            }
            return this;
        }
    }


    class Program {
        static void Main() {
            IComponent<string> album = new Composite<string>("Album");
            var point = album;
            string[] s;
            string command, parameter;
            // Create and manipulate a structure
            var instream = new StreamReader(@"Composite\Composite.dat");
            do {
                string t = instream.ReadLine();
                Console.WriteLine("\t\t\t\t" + t);
                s = t.Split();
                command = s[0];
                if (s.Length > 1) parameter = s[1]; else parameter = null;
                switch (command) {
                    case "AddSet":
                        IComponent<string> c = new Composite<string>(parameter);
                        point.Add(c);
                        point = c;
                        break;
                    case "AddPhoto":
                        point.Add(new Component<string>(parameter));
                        break;
                    case "Remove":
                        point = point.Remove(parameter);
                        break;
                    case "Find":
                        point = album.Find(parameter);
                        break;
                    case "Display":
                        Console.WriteLine(album.Display(0));
                        break;
                    case "Quit":
                        break;
                }
            } while (!command.Equals("Quit"));

            Console.ReadKey();
        }
    }
}