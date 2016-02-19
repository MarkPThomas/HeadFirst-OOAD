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
        #endregion

        #region Initialization
        public Instrument(string serialNumber,
                          double price)
        {
            this.serialNumber = serialNumber;
            this.price = price;
        }
        #endregion

    }
}
