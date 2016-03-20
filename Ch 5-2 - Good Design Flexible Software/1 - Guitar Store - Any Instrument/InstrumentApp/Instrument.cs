using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentApp
{
    abstract class Instrument
    {
        #region Properties
        internal string serialNumber { get; }
        internal double price { get; set; }
        internal InstrumentSpec spec { get; }
        #endregion

        #region Initialization
        public Instrument(string serialNumber,
                          double price,
                          InstrumentSpec spec)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.spec = spec;
        }
        #endregion

    }
}
