using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GSF.unit;

namespace GSF.testing
{
    public class UnitGroupTester
    {
        #region Methods: Public
        public bool initializeClass(List<Unit> inputUnits, List<Unit> expectedOutputUnits)
        {
            bool matchingID = false;
            UnitGroup unitGroup = new UnitGroup(inputUnits);
            List<Unit> outputUnits = unitGroup.getUnits();
            foreach (Unit unitOutput in outputUnits)
            {
                matchingID = false;
                foreach (Unit unitExpected in expectedOutputUnits)
                {
                    if (unitExpected.ID == unitOutput.ID)
                    {
                        matchingID = true;
                        break;
                    }
                }
                if (!matchingID) { break; }
            }

            return matchingID;
        }

        public bool addUnit(UnitGroup unitGroup, Unit inputUnit, Unit expectedOutputUnit)
        {
            unitGroup.addUnit(inputUnit);
            Unit returnedUnit = unitGroup.getUnit(inputUnit.ID);
            return (expectedOutputUnit.ID == returnedUnit.ID);
        }

        public bool updateUnit(UnitGroup unitGroup, Unit inputUnit, Unit expectedOutputUnit)
        {
            unitGroup.addUnit(inputUnit);
            unitGroup.addUnit(expectedOutputUnit);
            Unit returnedUnit = unitGroup.getUnit(inputUnit.ID);
            return (expectedOutputUnit.ID == returnedUnit.ID &&
                    expectedOutputUnit.Name == returnedUnit.Name);
        }

        public bool getUnitByID(UnitGroup unitGroup, int inputID, Unit expectedOutputUnit)
        {
            Unit startingUnit = new Unit(inputID);
            unitGroup = new UnitGroup(new List<Unit>() { startingUnit });

            Unit returnedUnit = unitGroup.getUnit(inputID);
            return (expectedOutputUnit.ID == returnedUnit.ID);
        }

        public bool getUnitByNonExistingID(UnitGroup unitGroup, int inputID)
        {
            Unit startingUnit = new Unit(inputID);
            unitGroup = new UnitGroup(new List<Unit>() { startingUnit });

            int nonExistingID = inputID + 1;

            try
            {
                Unit returnedUnit = unitGroup.getUnit(nonExistingID);
                return false;
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return true;
            }
        }

        public bool getAllUnits(UnitGroup unitGroup, List<Unit> expectedOutputUnits)
        {
            bool matchingID = false;
            List<Unit> outputUnits = unitGroup.getUnits();
            foreach (Unit unitOutput in outputUnits)
            {
                matchingID = false;
                foreach (Unit unitExpected in expectedOutputUnits)
                {
                    if (unitExpected.ID == unitOutput.ID)
                    {
                        matchingID = true;
                        break;
                    }
                }
                if (!matchingID) { break; }
            }

            return matchingID;
        }

        public bool removeUnitByID(UnitGroup unitGroup, int inputID, List<Unit> expectedOutputUnits)
        {
            unitGroup = new UnitGroup(expectedOutputUnits);
            unitGroup.removeUnit(inputID);
            List<Unit> units = unitGroup.getUnits();
            return !validateUnitInList(units, inputID);
        }

        public bool removeUnitByIDNonExisting(UnitGroup unitGroup, int inputID, List<Unit> expectedOutputUnits)
        {
            unitGroup = new UnitGroup(expectedOutputUnits);
            unitGroup.removeUnit(inputID);

            List<Unit> units = unitGroup.getUnits();

            // Check that unit no longer exists
            if (validateUnitInList(units, inputID)) { return false; }

            // Check that the list is unaltered
            if (!validateUnitsListUnaltered(units, expectedOutputUnits)) { return false; }

            return true;
        }

        public bool removeUnitByObjectInstance(UnitGroup unitGroup, Unit inputUnit, List<Unit> expectedOutputUnits)
        {
            unitGroup = new UnitGroup(expectedOutputUnits);
            unitGroup.removeUnit(inputUnit);
            List<Unit> units = unitGroup.getUnits();
            return !validateUnitInList(units, inputUnit.ID);
        }

        public bool removeUnitByNonExistingObjectInstance(UnitGroup unitGroup, Unit inputUnit, List<Unit> expectedOutputUnits)
        {
            unitGroup = new UnitGroup(expectedOutputUnits);
            unitGroup.removeUnit(inputUnit);

            List<Unit> units = unitGroup.getUnits();

            // Check that unit no longer exists
            if (validateUnitInList(units, inputUnit.ID)) { return false; }

            // Check that the list is unaltered
            if (!validateUnitsListUnaltered(units, expectedOutputUnits)) { return false; }

            return true;
        }
        #endregion



        #region Methods: Private
        private bool validateUnitInList(List<Unit> units, int inputID)
        {
            foreach (Unit unit in units)
            {
                if (unit.ID == inputID) { return true; }
            }
            return false;
        }

        private bool validateUnitsListUnaltered(List<Unit> unitsOutput, List<Unit> unitsExpected)
        {
            bool matchingUnit = false;
            foreach (Unit unit in unitsOutput)
            {
                matchingUnit = false;
                foreach (Unit unitExpected in unitsExpected)
                {
                    if (unit.ID == unitExpected.ID)
                    {
                        matchingUnit = true;
                        break;
                    }
                }
                if (!matchingUnit) { return false; }
            }
            return true;
        }
        #endregion
    }
}
