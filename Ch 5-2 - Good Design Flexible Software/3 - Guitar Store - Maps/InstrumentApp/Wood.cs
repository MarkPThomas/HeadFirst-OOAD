using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace InstrumentApp
{
    public enum Wood
    {
        [Description("Indian Rosewood")]Indian_Rosewood,
        [Description("Brazilian Rosewood")]Brazilian_Rosewood,
        Mahogany,
        Maple,
        Cocobolo,
        Cedar,
        Adirondack,
        Alder,
        Sitka,
        Spruce
    }
}
