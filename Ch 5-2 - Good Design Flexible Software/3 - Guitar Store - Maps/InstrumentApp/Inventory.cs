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
            Instrument instrument = new Instrument(serialNumber, price, spec);
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

        public List<Instrument> search(InstrumentSpec searchSpec)
        {
            List<Instrument> matchingInstruments = new List<Instrument>();
            for (int i = 0; i < _inventory.Count; i++)
            {
                Instrument instrument = _inventory[i];
                if (instrument.spec.matches(searchSpec))
                {
                    matchingInstruments.Add(instrument);
                }
                
            }
            return matchingInstruments;
        }
        #endregion


    }
}
