using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objectville_Subway.SubwaySystem
{
    class Station
    {
        public string Name { get; }

        public Station(string name)
        {
            Name = name;
        }

        public int hashCode()
        {
            return Name.ToLower().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Station)
            {
                Station otherStation = (Station)obj;
                if (string.Compare(otherStation.Name, Name,ignoreCase:true) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Name.ToLower().GetHashCode();
        }
    }
}
