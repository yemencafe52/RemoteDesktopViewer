using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace RemoteDesktopViewerServer
{
    public class Server
    {
        private int port;
        private Socket s;
        private bool isRunning;

        public Server(int port)
        {
            this.port = port;
        }

        public bool Start()
        {
            bool res = false;

            try
            {
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                s.Bind(new IPEndPoint(IPAddress.Parse("0.0.0.0"), this.port));
                s.Listen(0);

                s.BeginAccept(new AsyncCallback(OnAccept), null);
                isRunning = true;
                res = true;

            }
            catch {
                s.Close();
                s = null;
                isRunning = false;
            }

            return res;
        }
        public bool Stop()
        {
            bool res = false;

            try
            {
                s.Close();
                s = null;
                isRunning = false;
                res = true;

            }
            catch { }
            return res;
        }

        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket c = s.EndAccept(ar);
                RequestProcessing rp = new RequestProcessing(c);
                s.BeginAccept(new AsyncCallback(OnAccept), null);
            }
            catch
            {
                s.Close();
                s = null;
                isRunning = false;
            }
        }
        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
        }
    }
}
