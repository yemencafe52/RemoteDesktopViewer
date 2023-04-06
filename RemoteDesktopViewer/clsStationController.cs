using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDesktopViewer
{
    public class StationController
    {
        private static List<Station> stations;

        public StationController()
        {
            if(stations is null)
            {
                stations = new List<Station>();
            }
        }

        public bool Add(Station station)
        {
            bool res = false;
            stations.Add(station);
            res = true;
            return res;
        }

        public bool Remove(Station station)
        {
            bool res = false;
            stations.Remove(station);
            return res;
        }

        public bool Remove(byte number)
        {
            bool res = false;
            return res;
        }

        public Station Find(byte number)
        {
            Station res = stations.Find(p => p.Number == number);
            return res;
        }
        public List<Station> GetStations
        {
            get
            {
                return stations;
            }
        }

    }
}
