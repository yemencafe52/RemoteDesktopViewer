using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDesktopViewer
{
    public class Station
    {
        private byte number;
        private string name;
        private string password;

        public Station(
             byte number,
             string name,
             string password
        )
        {

            this.number = number;
            this.name = name;
            this.password = password;
        }

        public byte Number
        {
            get
            {
                return this.number;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
        }


    }
}
