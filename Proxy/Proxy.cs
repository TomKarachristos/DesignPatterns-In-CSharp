using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Skeleton {
    class Subject_Accessor {

        public interface ISubject {
            string Request();
        }

        // no outsider has access to this
        class Subject {
            public string Request() {
                return "Subject Request " + "Choose left door\n";
            }
        }

        // class inside class!!
        // by default is private
        // is public because the client is inherit this
        // and is the only way to have permission to use it!
        public class Virtual_Proxy : ISubject {
            Subject subject;

            // It is only when the Request method is called that the Subject reference is checked and, if
            // null, assigned to an instantiated object.
            public string Request() {
                // A virtual proxy creates the object only on its first method call
                if (subject == null) {
                    Console.WriteLine("Subject inactive");
                    subject = new Subject();
                }
                Console.WriteLine("Subject active");
                return subject.Request();
            }
        }


        public class Authentication_Proxy : ISubject {
            Subject subject;
            string password = "123456";

            public string Authenticate(string supplied) {
                if (supplied != password) {
                    return "no Access";
                } else {
                    subject = new Subject();
                    return "Access";
                }
            }
            public string Request() {
                if (subject == null) {
                    return "Authetication First";
                } else {
                    return subject.Request();
                }
            }
        }
    }

    // In order to gain access to the classes in SubjectAccessor,
    // the client inherits from it, thus giving it access to internal members
    // client
    class Program : Subject_Accessor {

        public static void Main() {
            ISubject subject = new Virtual_Proxy();
            Console.WriteLine(subject.Request());
            Console.WriteLine(subject.Request());

            Authentication_Proxy subject2 = new Authentication_Proxy();
            Console.WriteLine(subject2.Request());
            Console.WriteLine((subject2 as Authentication_Proxy).Authenticate("Secret"));
            Console.WriteLine((subject2 as Authentication_Proxy).Authenticate("123456"));
            Console.WriteLine(subject2.Request());
            Console.ReadLine();
        }

    }

    class With_Decorator : Subject_Accessor {

        // Decorator
        class GUI_Decorator : ISubject {
            ISubject mechanism;

            public GUI_Decorator(ISubject mechanism) {
                this.mechanism = mechanism;
            }

            public string Request() {
                string output = mechanism.Request();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(output);
                return "";
            }

        }

        public static void Main() {
            ISubject subject = new Virtual_Proxy();
            ISubject clinet_subject = new GUI_Decorator(subject);
            clinet_subject.Request();
            clinet_subject.Request();

            Authentication_Proxy subject2 = new Authentication_Proxy();
            clinet_subject = new GUI_Decorator(subject2);
            clinet_subject.Request();
            (subject2 as Authentication_Proxy).Authenticate("Secret");
            (subject2 as Authentication_Proxy).Authenticate("123456");
            Console.ReadLine();
        }


    }
}
