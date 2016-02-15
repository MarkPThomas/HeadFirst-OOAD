using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogDoor
{
    class Remote
    {
        private DogDoor _door;

        public Remote(DogDoor door)
        {
            _door = door;
        }

        public void pressButton()
        {
            Console.WriteLine("Pressing the remote control button ...");
            toggleDoorState();
        }

        private void toggleDoorState()
        {
            if (_door.isOpen)
            {
                _door.Close();
            }
            else
            {
                _door.Open();
            }
        }
    }
}
