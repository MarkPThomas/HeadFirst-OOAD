using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentApp
{
    class InstrumentSpec
    {
        #region Properties
        internal Builder builder { get; }
        internal string model { get; }
        internal Type type { get; }
        internal Wood backWood { get; }
        internal Wood topWood { get; }
        #endregion

        #region Methods
        public InstrumentSpec(Builder builder,
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

        public virtual bool matches(InstrumentSpec spec)
        {
            // Ignore serial # since that's unique
            // Ignore price since that's unique

            // Check if matches fail
            if (builder != spec.builder) { return false; }
            if (type != spec.type) { return false; }
            if (backWood != spec.backWood) { return false; }
            if (topWood != spec.topWood) { return false; }

            return true;
        }
        #endregion
    }
}
