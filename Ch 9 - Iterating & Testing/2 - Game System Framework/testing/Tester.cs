using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GSF.unit;

namespace GSF.testing
{
    public class Tester
    {
        private int _groupTestID;
        private int _testID;

        public void runUnitTests()
        {
            _groupTestID = 1;
            _testID = 0;
            printTestGroupSetup("Unit Tests");
            Unit unit;
            UnitTester unitTest = new UnitTester();

            // Tests
            _testID ++;
            printSetup("Set/get 'type' property");
            unit = new Unit(_testID);
            printResult(unitTest.setGetCommonProperty(unit, "infantry"));

            _testID ++;
            printSetup("Set/get unit-specific property");
            unit = new Unit(_testID);
            printResult(unitTest.setGetUnitSpecificProperty(unit, "hit points", 25));

            _testID ++;
            printSetup("Change existing property value");
            unit = new Unit(_testID);
            string property = "hit points";
            unit.setProperties(property, 25);
            printResult(unitTest.changeExistingPropertyValue(unit, property, 15));

            _testID ++;
            printSetup("Get a non-existing property value");
            unit = new Unit(_testID);
            printResult(unitTest.getNonExistentProperty(unit, "strength"));

            _testID ++;
            printSetup("Add an existing property.");
            unit = new Unit(_testID);
            printResult(unitTest.addExistingProperty(unit, property, 15));

            _testID ++;
            printSetup("Get the 'id' property");
            unit = new Unit(_testID);
            printResult(unitTest.getIDProperty(unit, _testID));

            _testID ++;
            printSetup("Set/get 'name' property");
            unit = new Unit(_testID);
            printResult(unitTest.setGetNameProperty(unit, "Chuck"));

            _testID ++;
            printSetup("Add/get 'weapon' property");
            unit = new Unit(_testID);
            string weaponName = "Axe";
            Weapon weapon = new Weapon(weaponName);
            printResult(unitTest.addGetWeapons(unit, weapon, weaponName));

            Console.WriteLine();
        }

        public void runGroupTests()
        {
            _groupTestID = 2;
            _testID = 0;
            printTestGroupSetup("Group Tests");
            Unit unit;
            
            UnitGroup unitGroup; 
            UnitGroupTester groupTest = new UnitGroupTester();

            // Tests
            _testID ++;
            printSetup("Initializing class with list of units");
            List<Unit> units = new List<Unit>() { new Unit(1000), new Unit(2000), new Unit(3000), new Unit(4000) };
            printResult(groupTest.initializeClass(units, units));

            _testID ++;
            printSetup("Adding a unit");
            unit = new Unit(_testID);
            unitGroup = new UnitGroup(new List<Unit>());
            printResult(groupTest.addUnit(unitGroup, unit, unit));

            _testID ++;
            printSetup("Adding a unit that already has been added");
            unit = new Unit(_testID);
            unit.Name = "Old Unit";
            Unit unitUpdated = new Unit(_testID);
            unitUpdated.Name = "New Unit";    
            unitGroup = new UnitGroup(new List<Unit>());
            printResult(groupTest.updateUnit(unitGroup, unit, unitUpdated));

            _testID ++;
            printSetup("Getting a unit by ID that exists");
            unitGroup = new UnitGroup(new List<Unit>());
            unit = new Unit(_testID);
            printResult(groupTest.getUnitByID(unitGroup, _testID, unit));

            _testID ++;
            printSetup("Getting a unit by ID that doesn't exist");
            unitGroup = new UnitGroup(new List<Unit>());
            unit = new Unit(_testID);
            printResult(groupTest.getUnitByNonExistingID(unitGroup, _testID));

            _testID ++;
            printSetup("Getting all units");
            units = new List<Unit>() { new Unit(1000), new Unit(2000), new Unit(3000), new Unit(4000) };
            unitGroup = new UnitGroup(units);
            printResult(groupTest.getAllUnits(unitGroup, units));

            _testID ++;
            printSetup("Removing a unit by ID that exists");
            unitGroup = new UnitGroup(new List<Unit>());
            // Units list that contains a unit with the supplied unit ID
            units = new List<Unit>() { new Unit(_testID), new Unit(_testID + 1), new Unit(_testID + 2), new Unit(_testID + 3), new Unit(_testID + 4) };
            printResult(groupTest.removeUnitByID(unitGroup, _testID, units));

            _testID ++;
            printSetup("Removing a unit by ID that doesn't exist");
            unitGroup = new UnitGroup(new List<Unit>());
            // Units list that doesn't contain any units with the supplied unit ID
            units = new List<Unit>() { new Unit(_testID+1), new Unit(_testID + 2), new Unit(_testID + 3), new Unit(_testID + 4) };
            printResult(groupTest.removeUnitByIDNonExisting(unitGroup, _testID, units));

            _testID ++;
            printSetup("Removing a unit that exists by the unit instance");
            unit = new Unit(_testID);
            unitGroup = new UnitGroup(new List<Unit>());
            // Units list that contains a unit with the supplied unit ID
            units = new List<Unit>() { new Unit(_testID), new Unit(_testID + 1), new Unit(_testID + 2), new Unit(_testID + 3), new Unit(_testID + 4) };
            printResult(groupTest.removeUnitByObjectInstance(unitGroup, unit, units));

            _testID ++;
            printSetup("Removing a unit that doesn't exist by the unit instance");
            unit = new Unit(_testID);
            unitGroup = new UnitGroup(new List<Unit>());
            // Units list that doesn't contain any units with the supplied unit ID
            units = new List<Unit>() { new Unit(_testID + 1), new Unit(_testID + 2), new Unit(_testID + 3), new Unit(_testID + 4) };
            printResult(groupTest.removeUnitByNonExistingObjectInstance(unitGroup, unit, units));

            Console.WriteLine();
        }
        
        public void printTestGroupSetup(string description)
        {
            Console.WriteLine("==================");
            printSetup(description);
            Console.WriteLine("==================");
            Console.WriteLine();
        }

        public void printSetup(string description)
        {
            Console.WriteLine("Test id " + _groupTestID + "." + _testID + ": ");
            Console.WriteLine(description);
        }

        public void printResult(bool result)
        {
            string fullTestID = _groupTestID + "." + _testID;
            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test " + fullTestID + " passed.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test " + fullTestID + " failed.");
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
