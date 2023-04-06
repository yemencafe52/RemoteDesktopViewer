using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace RemoteDesktopViewerServer
{
    public class DeskTopImage:IDisposable
    {
        private Image image;
        public DeskTopImage()
        {
            this.image = GetDesktopImage();
        }

        private Image GetDesktopImage()
        {
            Rectangle r = Screen.PrimaryScreen.Bounds;
            Bitmap b = new Bitmap(r.Width, r.Height);

            using(Graphics g= Graphics.FromImage(b))
            {
                g.CopyFromScreen(0, 0, 0, 0, r.Size);
                g.Dispose();
            }


            return b;
        }

        public byte[] ToBytes()
        {
            byte[] res;

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    this.image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    res = ms.ToArray();
                }
            }
            catch {
                res = new byte[] { 0 };
            }

            return res;
        }

        public void Dispose()
        {
            if(this.image != null)
            {
                this.image.Dispose();
            }
        }
        ~DeskTopImage()
        {
            Dispose();
        }
    }
}
