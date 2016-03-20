using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSF.unit;

namespace GSF.testing
{
    public class UnitTester
    {

        #region Tests for Unit Class
        public bool getIDProperty(Unit unit, int id)
        {
            return (unit.ID == id);
        }

        public bool setGetCommonProperty(Unit unit, string type)
        {
            unit.Type = type;
            return (unit.Type == type);
        }

        public bool setGetUnitSpecificProperty(Unit unit, string property, object value)
        {
            unit.setProperties(property, value);
            return (unit.getProperties(property) == value);
        }

        public bool setGetNameProperty(Unit unit, string name)
        {
            unit.Name = name;
            return (unit.Name == name);
        }

        public bool changeExistingPropertyValue(Unit unit, string property, object newValue)
        {
            unit.setProperties(property, newValue);
            return (unit.getProperties(property) == newValue);
        }

        public bool getNonExistentProperty(Unit unit, string property)
        {
            try
            {
                return (unit.getProperties(property) == null);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return true;
            }
        }

        public bool addExistingProperty(Unit unit, string property, object newValue)
        {
            try
            {
                unit.setProperties(property, newValue);
                unit.setProperties(property, newValue);
                return (unit.getProperties(property) == newValue);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool addGetWeapons(Unit unit, Weapon weapon, string expectedValue)
        {
            unit.addWeapon(weapon);
            List<Weapon> weapons = unit.Weapons;
            Weapon returnedWeapon = weapons[weapons.IndexOf(weapon)];
            return (returnedWeapon.name == expectedValue);
        }
        #endregion
    }
}
