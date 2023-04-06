using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDesktopViewer
{
    public class RemoteImage
    {
        private Image image;  
        public RemoteImage(byte []ar)
        {
            BytesToImage(ar);
        }
      
        private Image BytesToImage(byte[] ar)
        {
            try
            {
                this.image = Image.FromStream(new MemoryStream(ar));
            }
            catch { }
            return this.image;
        }

        public Image GetImage
        {
            get
            {
                return this.image;
            }
        }
      
    }
}
