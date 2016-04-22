using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Objectville_Subway.Loader;
using Objectville_Subway.SubwaySystem;

namespace Objectville_Subway.Tester
{
    class LoadTester : Tester
    {
        public override void Run(string[] args = null)
        {
            try
            {
                SubwayLoader loader = new SubwayLoader();
                Subway objectville = loader.loadFromFile("ObjectvilleSubway.txt");

                runTest("station", validateStations(objectville));
                runTest("connection", validateConnections(objectville));
            }
            catch (Exception e)
            {
                printFailure("All");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.ReadKey();
        }

        private bool validateStations(Subway subway)
        {
            return (subway.HasStation("DRY Drive") &&
                    subway.HasStation("Weather-O-Rama, Inc.") &&
                    subway.HasStation("Boards 'R' Us"));
        }

        private bool validateConnections(Subway subway)
        {
            return (subway.HasConnection("Meyer Line", "DRY Drive", "Head First Theater") &&
                    subway.HasConnection("Wirfs-Brock Line", "Weather-O-Rama, Inc.", "XHTML Expressway") &&
                    subway.HasConnection("Rumbaugh Line", "Head First Theater", "Infinite Circle"));
        }
    }
}
