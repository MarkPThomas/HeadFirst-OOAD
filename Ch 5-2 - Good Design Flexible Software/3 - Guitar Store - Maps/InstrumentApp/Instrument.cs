using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentApp
{
    class Instrument
    {
        #region Properties
        internal string serialNumber { get; }
        internal double price { get; set; }
        internal InstrumentSpec spec { get; }

        internal InstrumentType instrumentType { get; }
        #endregion

        private InstrumentType getInstrumentType(InstrumentSpec spec)
        {
            object instrumentType = spec.getProperty("instrumentType");
            if (instrumentType is InstrumentType)
            {
                return (InstrumentType)instrumentType;
            }
            return InstrumentType.Unspecified;
        }

        #region Initialization
        public Instrument(string serialNumber,
                          double price,
                          InstrumentSpec spec)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.spec = spec;
            this.instrumentType = getInstrumentType(spec);
        }
        #endregion

    }
}
