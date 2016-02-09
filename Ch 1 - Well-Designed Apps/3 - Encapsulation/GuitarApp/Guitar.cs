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
                        Builder builder,
                        string model,
                        Type type,
                        Wood backWood,
                        Wood topWood)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.spec = new GuitarSpec(builder, model, type, backWood, topWood);
        }
        #endregion


    }
}
