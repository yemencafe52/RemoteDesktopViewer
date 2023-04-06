using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDesktopViewerServer
{
    class clsEntryPoint
    {
        static void Main(string[] args)
        {
            Server s = new Server(888);
            if (s.Start())
            {
                Console.Write("Server is running ...");
            }
            else
            {
                Console.Write("OOPS, SOMETHING WENT WRONG :(");
            }
            
            Console.Read();
            s.Stop();
        }

    }
}
