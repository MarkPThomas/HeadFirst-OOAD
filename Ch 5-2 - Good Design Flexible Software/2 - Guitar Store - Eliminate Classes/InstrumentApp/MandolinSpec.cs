using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentApp
{
    class MandolinSpec : InstrumentSpec
    {
        #region Properties
        public Style style{ get;}

        #endregion

        #region Methods
        public MandolinSpec(Builder builder,
                            string model,
                            Type type,
                            Wood backWood,
                            Wood topWood,
                            Style style)
            :base(builder, model, type, backWood, topWood)
        {
            this.style = style;
        }

        public override bool matches(InstrumentSpec spec)
        {
            if (!base.matches(spec)) { return false; }
            if (!(spec is MandolinSpec)) { return false; }
            MandolinSpec mandolinSpec = (MandolinSpec)spec;
            if (style != mandolinSpec.style) { return false; }

            return true;
        }
        #endregion
    }
}
