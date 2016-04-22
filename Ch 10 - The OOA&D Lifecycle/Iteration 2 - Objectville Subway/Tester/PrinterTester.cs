using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Objectville_Subway.Printer;
using Objectville_Subway.Loader;
using Objectville_Subway.SubwaySystem;

namespace Objectville_Subway.Tester
{
    class PrinterTester : Tester
    {
        public override void Run(string[] args = null)
        {
            if (args == null || args.Length != 2)
            {
                printFailure("Usage: SubwayTester [startStation] [endStation]");
            }
            else
            {
                try
                {
                    SubwayLoader loader = new SubwayLoader();
                    Subway objectville = loader.loadFromFile("ObjectvilleSubway.txt");

                    runTest("start/end station", validateStations(objectville, args[0], args[1]));

                    List<Connection> route = objectville.GetDirections(args[0], args[1]);
                    SubwayPrinter printer = new SubwayPrinter();
                    printer.PrintDirections(route);
                    Console.WriteLine(printer.output);
                }
                catch (Exception e)
                {
                    printFailure("Every");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
            
            Console.ReadKey();
        }

        private bool validateStations(Subway subway, string stationName1, string stationName2)
        {
            return (subway.HasStation(stationName1) &&
                    subway.HasStation(stationName2));
        }
    }
}
