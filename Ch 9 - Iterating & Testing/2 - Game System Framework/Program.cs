using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSF.testing;
using GSF.unit;

namespace GSF
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester tester = new Tester();
            tester.runUnitTests();
            tester.runGroupTests();
            Console.ReadKey();
        }
    }
}

