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
        internal string builder { get; }
        internal string model { get; }
        internal string type { get; }
        internal string backWood { get; }
        internal string topWood { get; }

        #endregion

        #region Initialization
        public Guitar(string serialNumber,
                        double price,
                        string builder,
                        string model,
                        string type,
                        string backWood,
                        string topWood)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.builder = builder;
            this.model = model;
            this.backWood = backWood;
            this.topWood = topWood;
        }
        #endregion


    }
}
