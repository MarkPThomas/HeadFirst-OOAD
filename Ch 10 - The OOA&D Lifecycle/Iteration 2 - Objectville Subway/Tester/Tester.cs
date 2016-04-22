using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objectville_Subway.Tester
{
    abstract class Tester
    {
        public abstract void Run(string[] args = null);
        
        protected void runTest(string testName, bool testResult)
        {
            Console.WriteLine("Testing {0}s ...", testName);
            if (testResult)
            {
                printSuccess(testName);
            }
            else
            {
                printFailure(testName);
            }
            Console.WriteLine();
        }

        protected void printSuccess(string testName)
        {
            Console.WriteLine("... {0} test passed successfully.", testName);
        }

        protected void printFailure(string testName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("... {0} test Failed", testName);
            Console.ResetColor();
        }
    }
}
