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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Preparing();
        }
        private bool Preparing()
        {
            bool res = false;
            CenterToParent();

            new StationController().Add(new Station(1, "PC01", "123"));
            new StationController().Add(new Station(2, "PC02", "123"));
            new StationController().Add(new Station(3, "PC03", "123"));
            new StationController().Add(new Station(4, "PC21", "123"));

            Display(new StationController().GetStations);
            return res;
        }

        private void Clear()
        {
            listView1.Items.Clear();
            toolStripStatusLabel2.Text = "0";
        }

        private void Display(List<Station> stations)
        {
            Clear();

            foreach(Station s in stations)
            {
                ListViewItem lvi = new ListViewItem(s.Number.ToString());
                lvi.SubItems.Add(s.Name);
                listView1.Items.Add(lvi);
            }

            toolStripStatusLabel2.Text = stations.Count.ToString();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    int index = listView1.SelectedItems[0].Index;
                    byte number = byte.Parse(listView1.Items[index].Text);

                    Station s = new StationController().Find(number);

                    if (s != null)
                    {
                        frmRemoteImageViewer frv = new frmRemoteImageViewer(s);
                        frv.Show();
                    }
                }
            }
        }
    }
}
