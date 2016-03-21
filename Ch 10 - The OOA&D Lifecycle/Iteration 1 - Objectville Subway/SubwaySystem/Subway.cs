using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objectville_Subway.SubwaySystem
{
    class Subway
    {
        private List<Station> _stations = new List<Station>();
        private List<Connection> _connections = new List<Connection>();

        public Subway()
        {

        }

        public void AddStation(string stationName)
        {
            if (!HasStation(stationName))
            {
                Station station = new Station(stationName);
                _stations.Add(station);
            }
        }

        public void AddConnection(string lineName, string station1Name, string station2Name)
        {
            if (!HasStation(station1Name)) { throw new ArgumentException("Invalid connection! Station " + station1Name + " does not exist."); }
            if (!HasStation(station2Name)) { throw new ArgumentException("Invalid connection! Station " + station2Name + " does not exist."); }

            Station station1 = new Station(station1Name);
            Station station2 = new Station(station2Name);

            // Direction 1
            Connection connection1 = new Connection(lineName, station1, station2);
            _connections.Add(connection1);

            // Direction 2
            Connection connection2 = new Connection(lineName, station2, station1);
            _connections.Add(connection2);
        }


        public bool HasStation(string stationName)
        {
            return _stations.Contains(new Station(stationName));
        }

        public bool HasConnection(string lineName, string station1Name, string station2Name)
        {
            Station station1 = new Station(station1Name);
            Station station2 = new Station(station2Name);

            foreach (Connection connection in _connections)
            {
                if (string.Compare(connection.LineName, lineName) == 0)
                {
                    if ((connection.Station1.Equals(station1)) &&
                        (connection.Station2.Equals(station2)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
