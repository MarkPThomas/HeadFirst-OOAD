using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentApp
{
    class GuitarSpec : InstrumentSpec
    {
        #region Properties
        internal int numStrings { get; }
        #endregion

        #region Methods
        public GuitarSpec(Builder builder,
                        string model,
                        Type type,
                        Wood backWood,
                        Wood topWood,
                        int numStrings)
            : base(builder, model, type, backWood, topWood)
        {
            this.numStrings = numStrings;
        }

        public override bool matches(InstrumentSpec spec)
        {
            if (!base.matches(spec)) { return false; }
            if (!(spec is GuitarSpec))  { return false; }
            GuitarSpec guitarSpec = (GuitarSpec)spec;
            if (!stringsMatch(model, guitarSpec.model)) { return false; }
            
            return true;
        }
        #endregion

        #region Methods: Private
        private bool stringsMatch(string stringA,
                                  string stringB)
        {
            if (!string.IsNullOrEmpty(stringA) &&
                !string.IsNullOrEmpty(stringB) &&
                string.Compare(stringA, stringB) == 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
