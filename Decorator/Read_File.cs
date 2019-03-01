using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Read_File_With_Progress {

    // kano interface Mono auto pou thelo na kano ovveride
    // san interface
    interface IStream_Reader {
        string ReadLine();
    }

    // edo ftiaxno ena interface gia tin streamreader
    class Progress_File_I : IStream_Reader {
        System.IO.StreamReader stream_read;

        public Progress_File_I(System.IO.StreamReader stream) {
            this.stream_read = stream;
        }

        public string ReadLine() {
            Console.ForegroundColor = ConsoleColor.Red;
            // not working, boring to make it.
            Console.WriteLine(stream_read.BaseStream.Position / stream_read.BaseStream.Length + "%");
            Console.ResetColor();
            return this.stream_read.ReadLine();
        }

    }

    /*
     *  The decorators can inherit directly from the component and maintain an object of that class as well.
        We see  now that Drawer is the operation that is to be called from one decorator
        to the next. However, this code does rely on the original Component declaring Drawer
        as virtual. If this is not the case, and we cannot go in and change the Component class, an interface
        is necessary.
    */
    // edo epektino tin klasi
    class Progress_File : System.IO.StreamReader {
        public System.IO.StreamReader stream_read; // kapoious nomous paraviazi tora auto
        private int progress = 0;

        // We cant mock the constructor of stream
        // without to loose something(e.g. performance)
        public Progress_File(System.IO.StreamReader stream, string path) : base(path) {
            this.stream_read = stream;
        }

        public override string ReadLine() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(progress++ + "%");
            Console.ResetColor();
            return this.stream_read.ReadLine();
        }

    }

    static class Program {
        private static readonly string path= @"D:\Code\Design__Pattern_in_C#_#_bishop\Design_Patterns\Execution\Decorator\Text.txt";

        public static void Main() {
            var counter = 0;
            string line;

            // Read the file and display it line by line.
            var file =
               new System.IO.StreamReader(path);

            // To decorator den einai replacement tou kanonikou
            // epektini mia sigkekrimeni litourgikotita
            // mpori na gini replacement se sigkekrimenes periptosis
            // i ama katsis kai ftiaksis ena interface gia oles tis methodous 
            var file_decorator_I = new Progress_File_I(file);
            while ((line = file_decorator_I.ReadLine()) != null) {
                Console.WriteLine(line);
                counter++;
            }

            file.Close();

            Console.WriteLine("Now try to inherit");

            counter = 0;
            line = "";

            // Read the file and display it line by line.
            file =
              new System.IO.StreamReader(path);

            // To decorator den einai replacement tou kanonikou
            // epektini mia sigkekrimeni litourgikotita
            // mpori na gini replacement se sigkekrimenes periptosis
            // i ama katsis kai ftiaksis ena interface gia oles tis methodous 
            using (var file_decorator = new Progress_File(file,path)) {
                while ((line = file_decorator.ReadLine()) != null) {
                    Console.WriteLine(line);
                    counter++;
                }

                // i make public the internal state
                file_decorator.stream_read.Close();

                // Suspend the screen.
            }
            Console.ReadKey();
        }

    }
}
