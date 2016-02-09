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

        public Guitar search(Guitar searchGuitar)
        {
            for (int i = 0; i < _guitars.Count; i++)
            {
                Guitar guitar = _guitars[i];
                // Ignore serial # since that's unique
                // Ignore price since that's unique

                // Check if matches fail
                if (searchGuitar.builder == guitar.builder) { continue; }
                if (stringsMatch(searchGuitar.model, guitar.model)) { continue; }
                if (searchGuitar.type == guitar.type) { continue; }
                if (searchGuitar.backWood == guitar.backWood) { continue; }
                if (searchGuitar.topWood == guitar.topWood) { continue; }

                // Head First example never returns the 'guitar' object if this part of the code is reached.
                // Main reason for failure in the first example. It works if the following is used:
                // return guitar;
                // This would also have failed if I had copied the Java more literally: 
                //      'string.Compare' is case is case insensitive, and this was reasonable to apply
                //      since I had refactored all of the string comparisons into a single method.
            }
            return null;
        }
        #endregion

        #region Methods: Private
        private bool stringsMatch(string stringA, 
                                  string stringB)
        {
            if (!string.IsNullOrEmpty(stringA) &&
                !string.IsNullOrEmpty(stringB) &&
                string.Compare(stringA, stringB) != 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
