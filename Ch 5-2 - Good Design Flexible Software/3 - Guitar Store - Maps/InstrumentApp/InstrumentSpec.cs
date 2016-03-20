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
        private Dictionary<string, object> _properties = new Dictionary<string, object>();
        internal Dictionary<string, object> properties { get { return _properties; } }
        #endregion

        #region Methods
        public InstrumentSpec(Dictionary<string, object> properties)
        {
            if (properties != null) { _properties = properties; }
        }

        public object getProperty(string propertyName)
        {
            if (properties.ContainsKey(propertyName))
            {
                return properties[(propertyName)];
            }
            else
	        {
                return null;
            }
            
        }

        public bool matches(InstrumentSpec spec)
        {
            // Ignore serial # since that's unique
            // Ignore price since that's unique

            // Check if matches fail
            foreach (string propertyName in spec.properties.Keys)
            {
                if (!properties[propertyName].Equals(spec.getProperty(propertyName)))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}
