using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogDoor
{
    class Bark
    {
        public string sound { get; }

        public Bark(string sound)
        {
            this.sound = sound;
        }

        public bool Equals(Bark bark)
        {
            if (sound.CompareTo(bark.sound) == 0)
            {
                return true;
            }
            return false;
        }

    }
}
