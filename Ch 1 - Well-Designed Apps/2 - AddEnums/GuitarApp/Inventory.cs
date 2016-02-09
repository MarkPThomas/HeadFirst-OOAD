using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp
{
    class Inventory
    {
        private List<Guitar> _guitars;

        #region Initialization
        public Inventory()
        {
            _guitars = new List<Guitar>();
        }

        #endregion

        #region Methods: Internal
        public void addGuitar(string serialNumber,
                                double price,
                                Builder builder,
                                string model,
                                Type type,
                                Wood backWood,
                                Wood topWood)
        {
            Guitar guitar = new Guitar(serialNumber, price, builder, model, type, backWood, topWood);
            _guitars.Add(guitar);
        }

        public Guitar getGuitar(string serialNumber)
        {
            for (int i = 0; i < _guitars.Count; i++)
            {
                Guitar guitar = _guitars[i];
                if (guitar.serialNumber.Equals(serialNumber))
                {
                    return guitar;
                }
            }
            return null;
        }

        public List<Guitar> search(Guitar searchGuitar)
        {
            List<Guitar> matchingGuitars = new List<Guitar>();
            for (int i = 0; i < _guitars.Count; i++)
            {
                Guitar guitar = _guitars[i];
                // Ignore serial # since that's unique
                // Ignore price since that's unique

                // Check if matches fail
                if (searchGuitar.builder != guitar.builder) { continue; }
                if (!stringsMatch(searchGuitar.model, guitar.model)) { continue; }
                if (searchGuitar.type != guitar.type) { continue; }
                if (searchGuitar.backWood != guitar.backWood) { continue; }
                if (searchGuitar.topWood != guitar.topWood) { continue; }

                matchingGuitars.Add(guitar);
            }
            return matchingGuitars;
        }
        #endregion

        #region Methods: Private
        private bool stringsMatch(string stringA, 
                                  string stringB)
        {
            if (!string.IsNullOrEmpty(stringA) &&
                !string.IsNullOrEmpty(stringB) &&
                string.Compare(stringA, stringB) == 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
