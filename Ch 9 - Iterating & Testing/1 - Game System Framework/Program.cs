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
            Unit unit;
            int testID;
            UnitTester tester = new UnitTester();

            // ID 1
            testID = 1;
            unit = new Unit(testID);
            printResult(tester.setGetCommonProperty(unit, "infantry"), testID);

            // ID 2
            testID = 2;
            unit = new Unit(testID);
            printResult(tester.setGetUnitSpecificProperty(unit, "hit points", 25), testID);

            // ID 3
            testID = 3;
            unit = new Unit(testID);
            string property = "hit points";
            unit.setProperties(property, 25);
            printResult(tester.changeExistingPropertyValue(unit, property, 15), testID);

            // ID 4
            testID = 4;
            unit = new Unit(testID);
            printResult(tester.getNonExistentProperty(unit, "strength"), testID);

            // ID 5: Add an existing item
            testID = 5;
            unit = new Unit(testID);
            printResult(tester.addExistingProperty(unit, property, 15), testID);

            // ID 6
            testID = 6;
            unit = new Unit(testID);
            printResult(tester.getIDProperty(unit, testID), testID);
            
            // ID 7
            testID = 7;
            unit = new Unit(testID);
            printResult(tester.setGetNameProperty(unit, "Chuck"), testID);

            // ID 8
            testID = 8;
            unit = new Unit(testID);
            Weapon weapon = new Weapon();
            printResult(tester.addGetWeapons(unit, weapon), testID);

            Console.ReadKey();
            }

        public static void printResult(bool result, int testID)
        {
            if (result)
            {
                Console.WriteLine("Test {0} passed.", testID);
            }
            else
            {
                Console.WriteLine("Test {0} failed.", testID);
            }
        }
    }
}

