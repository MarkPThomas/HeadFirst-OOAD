using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GSF.unit;

namespace GSF.board
{
    public class Tile
    {
        int Width { get; set; }
        int Height { get; set; }

        private List<Unit> _units = new List<Unit>();
        public List<Unit> units { get { return new List<Unit>(_units); } }

        public Tile(int height, int width)
        {
            Height = height;
            Width = width;
            _units = new List<Unit>();
        }

        internal protected void AddUnit(Unit unit)
        {
            units.Add(unit);
        }

        internal protected void RemoveUnit(Unit unit)
        {
            units.Remove(unit);
        }

        internal protected void RemoveUnits()
        {
            units.Clear();
        }
    }
}
