using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Employees {
    public interface IEmployee {
        string Name { get; set; }
        void Add(IEmployee c);
        IEmployee Remove(IEmployee employee);
        IEmployee Find(IEmployee employee);
        String Display(int depth);
    }

    public class Employee : IEmployee {
        public string Name { get; set; }

        public Employee(string name) {
            this.Name = name;
        }

        public void Add(IEmployee c) {
            throw new NotImplementedException();
        }

        public IEmployee Remove(IEmployee employee) {
            throw new NotImplementedException();
        }

        public IEmployee Find(IEmployee employee) {
            throw new NotImplementedException();
        }

        public string Display(int depth) {
            return new String('-', depth) + Name + "\n";
        }
    }

    public class EmployeeComposite : IEmployee {
        public string Name { get; set; }
        public List<IEmployee> List { get; set; }

        public EmployeeComposite(string name) {
            this.Name = name;
            this.List = new List<IEmployee>();
        }

        public void Add(IEmployee c) {
            List.Add(c);
        }

        public IEmployee Remove(IEmployee employee) {
            throw new NotImplementedException();
        }

        public IEmployee Find(IEmployee employee) {
            throw new NotImplementedException();
        }

        public string Display(int depth) {
            StringBuilder s = new StringBuilder(new String('-', depth));
            s.Append("Set " + Name + " length :" + (List.Count - 1) + "\n");
            foreach (IEmployee component in List) {
                s.Append(component.Display(depth + 2));
            }
            return s.ToString();
        }
    }

    class Program {

        static void Main() {
            IEmployee root = null;
            var point = root;
            string[] s;
            string command, parameter;
            var instream = new StreamReader(@"Composite\Employments\Company_Hierarchy.dat");
            do {
                string t = instream.ReadLine();
                Console.WriteLine("\t\t\t\t" + t);
                s = t.Split();
                command = s[0];
                if (s.Length > 1) parameter = s[1]; else parameter = null;
                switch (command) {
                    case "AddSet":
                        if (root == null)
                            point = root = new EmployeeComposite(parameter);
                        else {
                            IEmployee c = new EmployeeComposite(parameter);
                            point.Add(c);
                            point = c;
                        }
                        break;
                    case "AddEmployee":
                        point.Add(new EmployeeComposite(parameter));
                        break;
                    case "Display":
                        Console.WriteLine(root.Display(0));
                        break;
                    case "Quit":
                        break;
                }
            } while (!command.Equals("Quit"));

            Console.ReadKey();
        }
    }

}
