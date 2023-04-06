using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace packet
{
    public enum Command:byte
    {
        Command1 = 1,
        Command2,
        Command3
    }
    public class Packet
    {
        private Command cmd;
        private byte[] buffer;

        public Packet(Command cmd)
        {
            this.cmd = cmd;
            this.buffer = new byte[0];
        }

        public Packet(Command cmd,byte[] ar)
        {
            this.cmd = cmd;
            this.buffer = new byte[ar.Length];
            Array.Copy(ar, 0, this.buffer,0, ar.Length);        
        }

        public Packet(byte[] ar)
        {
            this.cmd = (Command)ar[0];

            this.buffer = new byte[ar.Length - 1];

            Array.Copy(ar, 1, this.buffer, 0, this.buffer.Length);
                
        }

        public byte[] PacketToBytes()
        {
            byte[] res = new byte[this.buffer.Length + 1];
            res[0] = (byte)this.cmd;

            Array.Copy(this.buffer, 0,res,1 ,this.buffer.Length);

            return res;

        }
        public Command CommandInfo
        {
            get
            {
                return this.cmd;
            }
        }

        public byte[] Buffer
        {
            get
            {
                return this.buffer;
            }
        }
    }
}
