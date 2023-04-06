using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using packet;

namespace RemoteDesktopViewer
{
    public class SocketCommander
    {
        private string ip;
        private int port;

        public SocketCommander(string ip,int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public bool GetRemoteObject(Packet packet,ref byte[] obj)
        {
            bool res = false;

            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                s.Connect(this.ip, this.port);
                s.Send(packet.PacketToBytes());

                byte[] buffer = new byte[1024 * 4];
                List<byte> obj2 = new List<byte>();

                int len = 0;

                while((len = s.Receive(buffer))>0)
                {
                    byte[] temp = new byte[len];
                    Array.Copy(buffer, 0, temp, 0, len);
                    obj2.AddRange(temp);
                }

                s.Close();

                if(obj2.Count>0)
                {
                    obj = obj2.ToArray();
                    res = true;
                }
            }
            catch { }
            return res;
        }



    }
}
