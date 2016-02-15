using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogDoor
{
    class BarkRecognizer
    {
        private DogDoor _door;
        public BarkRecognizer(DogDoor door)
        {
            _door = door;
        }

        public void recognize(Bark bark)
        {
            Console.WriteLine("    BarkRecognizer: Heard a '" + bark.sound + "'");
            foreach (Bark allowedBark in _door.allowedBarks)
            {
                if (allowedBark.Equals(bark))
                {
                    _door.Open();
                    return;
                }
            }
        }
    }
}
