using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDesktopViewer
{
    public partial class frmRemoteImageViewer : Form
    {
        private Station station;
        public frmRemoteImageViewer(Station station)
        {
            InitializeComponent();
            this.station = station;
            this.Text = station.Name;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetRemoteImage();
        }

        private async void GetRemoteImage()
        {
            SocketCommander sc = new SocketCommander(this.station.Name, 888);

            byte[] obj = new byte[] { 0 };

            if(sc.GetRemoteObject(new packet.Packet(packet.Command.Command1),ref obj))
            {
                Image i = await Task.Run(() => new RemoteImage(obj).GetImage);

                if (i != null)
                {
                    pictureBox1.Image = i;
                }
            }
        }
    }
}
