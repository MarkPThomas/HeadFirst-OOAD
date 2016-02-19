using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentApp
{
    class Inventory
    {
        private List<Instrument> _inventory;

        #region Initialization
        public Inventory()
        {
            _inventory = new List<Instrument>();
        }

        #endregion

        #region Methods: Internal
        public void addInstrument(string serialNumber,
                                  double price,
                                  InstrumentSpec spec)
        {
            Instrument instrument = null;
            if (spec is GuitarSpec)
            {
                instrument  = new Guitar(serialNumber, price, (GuitarSpec)spec);
            }
            else if (spec is MandolinSpec)
            {
                instrument = new Mandolin(serialNumber, price, (MandolinSpec)spec);
            }
            
            _inventory.Add(instrument);
        }

        public Instrument get(string serialNumber)
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                Instrument instrument = _inventory[i];
                if (instrument.serialNumber.Equals(serialNumber))
                {
                    return instrument;
                }
            }
            return null;
        }

        public List<Guitar> search(GuitarSpec searchSpec)
        {
            List<Guitar> matchingGuitars = new List<Guitar>();
            for (int i = 0; i < _inventory.Count; i++)
            {
                if (!(_inventory[i] is Guitar)) { continue; }
                Guitar guitar = (Guitar)_inventory[i];
                if (guitar.spec.matches(searchSpec))
                {
                    matchingGuitars.Add(guitar);
                }
                
            }
            return matchingGuitars;
        }

        public List<Mandolin> search(MandolinSpec searchSpec)
        {
            List<Mandolin> matchingMandolins = new List<Mandolin>();
            for (int i = 0; i < _inventory.Count; i++)
            {
                if (!(_inventory[i] is Mandolin)) { continue; }
                Mandolin mandolin = (Mandolin)_inventory[i];
                if (mandolin.spec.matches(searchSpec))
                {
                    matchingMandolins.Add(mandolin);
                }

            }
            return matchingMandolins;
        }
        #endregion


    }
}
