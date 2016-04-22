using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objectville_Subway.Tester;

namespace Objectville_Subway
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadTester loadTester = new LoadTester();
            loadTester.Run();

            PrinterTester printerTester = new PrinterTester();
            printerTester.Run(args);
            //printerTester.Run(args);
        }
    }
}
