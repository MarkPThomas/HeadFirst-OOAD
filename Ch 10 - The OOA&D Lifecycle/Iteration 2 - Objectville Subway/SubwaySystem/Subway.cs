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
        private Dictionary<Station, List<Station>> _network = new Dictionary<Station, List<Station>>();

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

        public Connection AddConnection(string lineName, string station1Name, string station2Name)
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

            AddToNetwork(station1, station2);
            AddToNetwork(station2, station1);

            return connection1;
        }

        private void AddToNetwork(Station station1, Station station2)
        {
            if (_network.ContainsKey(station1))
            {
                List<Station> connectingStations = _network[station1];
                if (!connectingStations.Contains(station2))
                {
                    connectingStations.Add(station2);
                }
            }
            else
            {
                List<Station> connectingStations = new List<Station>() { station2 };
                _network.Add(station1, connectingStations);
            }
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

        /// <summary>
        /// This method is based on a well-known bit of code called Dijkstra's Algorithm, which figures out the shortest path between two nodes on a graph.
        /// </summary>
        /// <param name="startStationName"></param>
        /// <param name="endStationName"></param>
        /// <returns></returns>
        public List<Connection> GetDirections(string startStationName,
                                              string endStationName)
        {
            if (!HasStation(startStationName)) { throw new ArgumentException("Invalid connection! Station " + startStationName + " does not exist."); }
            if (!HasStation(endStationName)) { throw new ArgumentException("Invalid connection! Station " + endStationName + " does not exist."); }

            Station start = new Station(startStationName);
            Station end = new Station(endStationName);

            List<Connection> route = new List<Connection>();
            List<Station> reachableStations = new List<Station>();
            Dictionary<Station, Station> previousStations = new Dictionary<Station, Station>();

            List<Station> neighbors = _network[start];
            for (int i = 0; i < neighbors.Count; i++)
            {
                Station station = neighbors[i];
                if (station == end)
                {
                    route.Add(GetConnection(start, end));
                    return route;
                }
                else
                {
                    reachableStations.Add(station);
                    previousStations.Add(station, start);
                }
            }

            List<Station> nextStations = new List<Station>();
            nextStations.AddRange(neighbors);
            Station currentStation = start;

            // searchLoop:
            for (int j = 1; j < _stations.Count; j++)
            {
                List<Station> tmpNextStations = new List<Station>();
                for (int k = 0; k < nextStations.Count; k++)
                {
                    Station searchStation = nextStations[k];
                    reachableStations.Add(searchStation);
                    currentStation = searchStation;

                    List<Station> currentNeighbors = _network[currentStation];
                    for (int l = 0; l < currentNeighbors.Count; l++)
                    {
                        Station neighbor = currentNeighbors[l];
                        if (neighbor == end)
                        {
                            reachableStations.Add(neighbor);
                            previousStations.Add(neighbor, currentStation);
                            break;
                        }
                        else if(!reachableStations.Contains(neighbor))
                        {
                            reachableStations.Add(neighbor);
                            tmpNextStations.Add(neighbor);
                            previousStations.Add(neighbor, currentStation);
                        }
                    }
                }
                nextStations = tmpNextStations; 
            }

            // We've found the path by now
            bool keepLooping = true;
            Station keyStation = end;
            Station loopingStation;

            while (keepLooping)
            {
                loopingStation = previousStations[keyStation];
                route.Add(GetConnection(loopingStation, keyStation));
                //route.Add(0, GetConnection(loopingStation, keyStation));
                if (start == loopingStation)
                {
                    keepLooping = false;
                }
                keyStation = loopingStation;
            }

            return route;
        }

        private Connection GetConnection(Station station1, Station station2)
        {
            foreach (Connection connection in _connections)
            {
                Station one = connection.Station1;
                Station two = connection.Station2;
                if ((station1.Name == one.Name) && (station2.Name == two.Name))
                {
                    return connection;
                }
            }
            return null;
        }
    }
}
