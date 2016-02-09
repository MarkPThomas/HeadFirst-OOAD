using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp
{
    class Guitar
    {
        #region Fields
        

        #endregion

        #region Properties
        internal string serialNumber { get; }
        internal double price { get; set; }
        
        internal GuitarSpec spec { get; }
        #endregion

        #region Initialization
        public Guitar(string serialNumber,
                        double price,
                        GuitarSpec spec)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.spec = spec;
        }
        #endregion


    }
}
