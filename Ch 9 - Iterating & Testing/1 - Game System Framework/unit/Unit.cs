using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GSF.unit
{
    public class Unit
    {
        public string Type { get; set; }
        public int ID { get; }
        public string Name { get; set; }

        public List<Weapon> Weapons { get; set; }

        private Dictionary<string, object> properties; 
   
        public Unit(int id)
        {
            ID = id;
        }

        public void addWeapon(Weapon weapon)
        {
            if (Weapons == null)
            {
                Weapons = new List<Weapon>();
            }
            Weapons.Add(weapon);
        }

        public object getProperties(string property)
        {
            if (properties == null)
            {
                return null;
            }
            return properties[property];
        }
        public void setProperties(string property, object value)
        {
            if (properties == null)
            { properties = new Dictionary<string, object>(); }
            if (!properties.Keys.Contains(property))
            {
                properties.Add(property, value);
            }
            else
            {
                properties[property] = value;
            }
        }
    }
}
