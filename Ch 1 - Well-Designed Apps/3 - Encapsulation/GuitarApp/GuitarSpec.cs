using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp
{
    class GuitarSpec
    {
        #region Properties
        internal Builder builder { get; }
        internal string model { get; }
        internal Type type { get; }
        internal Wood backWood { get; }
        internal Wood topWood { get; }
        #endregion

        #region Methods
        public GuitarSpec(Builder builder,
                        string model,
                        Type type,
                        Wood backWood,
                        Wood topWood)
        {
            this.builder = builder;
            this.model = model;
            this.type = type;
            this.backWood = backWood;
            this.topWood = topWood;
        }
        #endregion
    }
}
