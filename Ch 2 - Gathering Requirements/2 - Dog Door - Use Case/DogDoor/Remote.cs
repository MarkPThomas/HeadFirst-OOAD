using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DogDoor
{
    class Remote
    {
        private DogDoor _door;
        private Timer _timer = new Timer(5000);

        public Remote(DogDoor door)
        {
            _door = door;
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed_CloseDoor);
        }

        public void pressButton()
        {
            Console.WriteLine("Pressing the remote control button ...");
            toggleDoorState();
            autoCloseDoor();
        }

        private void toggleDoorState()
        {
            if (_door.isOpen)
            {
                _door.close();
            }
            else
            {
                _door.open();
            }
        }

        private void autoCloseDoor()
        {
            _timer.Enabled = true;
        }

        private void _timer_Elapsed_CloseDoor(object sender, ElapsedEventArgs e)
        {
            _door.close();
            _timer.Enabled = false;
        }
    }
}
