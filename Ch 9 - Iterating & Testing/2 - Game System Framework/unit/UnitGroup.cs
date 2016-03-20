using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSF.unit
{
    public class UnitGroup
    {
        private Dictionary<int, Unit> _units;

        public UnitGroup(List<Unit> units)
        {
            _units = new Dictionary<int, Unit>();
            foreach (Unit unit in units)
            {
                _units.Add(unit.ID, unit);
            }
        }


        public void addUnit(Unit unit)
        {
            if (_units.Keys.Contains(unit.ID))
            {
                _units[unit.ID] = unit;
            }
            else
            {
                _units.Add(unit.ID, unit);
            }
        }

        
        public Unit getUnit(int id)
        {
            if (!_units.Keys.Contains(id))
            {
                throw new KeyNotFoundException("Unit id not fond in group.");
            }
            return _units[id];
        }

        public List<Unit> getUnits()
        {
            return _units.Values.ToList();
        }


        public void removeUnit(Unit unit)
        {
            _units.Remove(unit.ID);
        }

        public void removeUnit(int id)
        {
            _units.Remove(id);
        }
    }
}
