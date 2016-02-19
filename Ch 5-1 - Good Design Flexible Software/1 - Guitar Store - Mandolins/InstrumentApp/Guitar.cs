using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentApp
{
    class Guitar : Instrument
    {
        #region Properties
        internal GuitarSpec spec { get; }
        #endregion

        #region Initialization
        public Guitar(string serialNumber,
                      double price,
                      GuitarSpec spec)
            : base(serialNumber, price)
        {         
            this.spec = spec;
        }
        #endregion


    }
}
