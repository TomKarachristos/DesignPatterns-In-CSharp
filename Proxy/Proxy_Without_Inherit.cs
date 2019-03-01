using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Without_Inherit {
    class Subject_Accessor {

        //  make and this class intead of interface just for fun
        public abstract class ISubject {
            public abstract string Request();
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
            public override string Request() {
                // A virtual proxy creates the object only on its first method call
                if (subject == null) {
                    Console.WriteLine("Subject inactive");
                    subject = new Subject();
                }
                Console.WriteLine("Subject active");
                return subject.Request();
            }

        }

        // factory or proxy to proxy?
        public Virtual_Proxy get_Virtual_Proxy() {
            return new Virtual_Proxy();
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
            public override string Request() {
                if (subject == null) {
                    return "Authetication First";
                } else {
                    return subject.Request();
                }
            }
        }

       public Authentication_Proxy get_Authentication_Proxy (){
            return new Authentication_Proxy();
        }
    }

    // In order to gain access to the classes in SubjectAccessor,
    // the client inherits from it, thus giving it access to internal members
    // client
    class Program {

        public static void Main() {
            // no meaning? or we can make it a factory like
            Subject_Accessor Subject_Accessor = new Subject_Accessor();

            Subject_Accessor.ISubject subject = Subject_Accessor.get_Virtual_Proxy();
            Console.WriteLine(subject.Request());
            Console.WriteLine(subject.Request());

            Subject_Accessor.ISubject subject2 = Subject_Accessor.get_Authentication_Proxy();
            Console.WriteLine(subject2.Request());
            Console.WriteLine((subject2 as Subject_Accessor.Authentication_Proxy).Authenticate("Secret"));
            Console.WriteLine((subject2 as Subject_Accessor.Authentication_Proxy).Authenticate("123456"));
            Console.WriteLine(subject2.Request());
            Console.ReadLine();
        }

    }

}
