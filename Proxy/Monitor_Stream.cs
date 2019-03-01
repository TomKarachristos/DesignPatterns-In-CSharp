using System;
using System.IO;

namespace Proxy.Monitor_Stream {

    interface IMonitorStream {

    }
    class File_Stream_Monitor {

    }


    class Program {

        static void Main() {

            using (FileStream fsSource = new FileStream(@"Proxy/Monitor_Me.txt",
                    FileMode.Open, FileAccess.Read)) {

                var bytes = new byte[fsSource.Length];
                var num_Bytes_To_Read = (int)fsSource.Length;
                var num_Bytes_Read = 0;
                var n = fsSource.Read(bytes, num_Bytes_Read, num_Bytes_To_Read).ToString();

                Console.WriteLine(n);

                num_Bytes_To_Read = bytes.Length;
            }
            System.Console.ReadKey();


        }
    }
}
