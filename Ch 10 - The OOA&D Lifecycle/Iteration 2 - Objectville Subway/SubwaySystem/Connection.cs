using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objectville_Subway.SubwaySystem
{
    class Connection
    {
        private Station _station1;
        private Station _station2;

        public string LineName { get; }
        public Station Station1 { get { return _station1; } }
        public Station Station2 { get { return _station2; } }

        public Connection(string lineName, Station station1, Station station2)
        {
            LineName = lineName;
            _station1 = station1;
            _station2 = station2;
        }
    }
}
