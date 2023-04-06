using packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDesktopViewerServer
{
    public class RequestProcessing
    {
        public RequestProcessing(Socket s)
        {
            byte[] buffer = new byte[] { 0 };

            try
            {
                int len = s.Receive(buffer);

                if (len > 0)
                {
                    Packet packet = new Packet(buffer);

                    if(packet.CommandInfo == Command.Command1)
                    {
                        byte[] buffer2 = new DeskTopImage().ToBytes();

                        int index = 0;

                        int bufferSize = 1024 * 4;

                        while(index < buffer2.Length)
                        {
                            byte[] buffer3;
                            if (buffer2.Length - index > bufferSize)
                            {
                                buffer3 = new byte[1024 * 4];
                            }
                            else
                            {
                                buffer3 = new byte[buffer2.Length - index];
                            }

                            Array.Copy(buffer2, index, buffer3, 0, buffer3.Length);

                            index += (s.Send(buffer3));
                        }
                    }
                }

                s.Close();
            }
            catch { }
        }
    }
}
