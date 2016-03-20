using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentApp
{
    class Mandolin : Instrument
    {
        #region Properties

        #endregion

        #region Initialization
        public Mandolin(string serialNumber,
                        double price,
                        MandolinSpec spec)
            : base(serialNumber, price, spec)
        {

        }
        #endregion
    }
}
