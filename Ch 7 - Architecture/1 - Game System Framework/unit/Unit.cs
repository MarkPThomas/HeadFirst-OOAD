using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GSF.unit
{
    public class Unit
    {
        public string Type { get; set; }
        public Dictionary<string, object> Properties { get; set; }

        public Unit()
        {
        }
    }
}
