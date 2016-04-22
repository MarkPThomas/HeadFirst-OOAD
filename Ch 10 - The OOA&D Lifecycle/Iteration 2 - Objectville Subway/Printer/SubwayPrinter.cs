using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Objectville_Subway.SubwaySystem;

namespace Objectville_Subway.Printer
{
    class SubwayPrinter
    {
        public string output{get; set;}

        public void PrintDirections(List<Connection> route)
        {
            Connection currentLine = route[0];
            Connection priorLine = currentLine;

            output = "Start out at " + currentLine.Station1 + ".";
            output += "\nGet on the " + NewLineMessage(currentLine.LineName, currentLine.Station2.Name);

            for (int i = 1; i < route.Count; i++)
            {
                priorLine = currentLine;
                currentLine = route[i];

                if (currentLine.LineName == priorLine.LineName)
                {
                    output += "\n   Continue past " + currentLine.Station1.Name + " ...";
                }
                else
                {
                    // Switching lines 
                    output += "\nWhen you get to " + currentLine.Station1.Name + ", get off the " + priorLine.LineName + ".";
                    output += "\nSwitch over to the " + NewLineMessage(currentLine.LineName, currentLine.Station2.Name); ;
                }
            }

            output += "\nGet off at " + currentLine.Station2.Name + " and enjoy yourself!";
        }

        private string NewLineMessage(string nextLine, string nextStation)
        {
            return nextLine + ", heading towards " + nextStation + ".";
        }
    }
}
