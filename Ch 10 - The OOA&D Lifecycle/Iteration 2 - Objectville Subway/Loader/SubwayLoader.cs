using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Objectville_Subway.SubwaySystem;

namespace Objectville_Subway.Loader
{
    class SubwayLoader
    {
        private Subway subway = new Subway();

        public SubwayLoader()
        {

        }

        public Subway loadFromFile(string subwayFilePath)
        {
            using (StreamReader reader = new StreamReader(subwayFilePath))
            {
                loadStations(subway, reader);
                string lineName = reader.ReadLine();
                while ((lineName != null) && (lineName.Length > 0))
                {
                    loadLine(subway, reader, lineName);
                    lineName = reader.ReadLine();
                }
            }
            return subway;
        }

        private void loadStations(Subway subway, StreamReader reader)
        {
            string currentLine = reader.ReadLine();
            while (currentLine.Length > 0)
            {
                subway.AddStation(currentLine);
                currentLine = reader.ReadLine();
            }
        }

        private void loadLine(Subway subway, StreamReader reader, string lineName)
        {
            string station1Name = reader.ReadLine();
            string station2Name = reader.ReadLine();
            while ((station2Name != null) && (station2Name.Length > 0))
            {
                subway.AddConnection(lineName, station1Name, station2Name);
                station1Name = station2Name;
                station2Name = reader.ReadLine();
            }

        }
    }
}
