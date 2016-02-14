using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DogDoor
{
    class DogDoor
    {
        private Timer _timer = new Timer(5000);

        public bool isOpen { get; private set; }


        public DogDoor()
        {
            isOpen = false;
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed_CloseDoor);
        }

        public void open()
        {
            isOpen = true;
            Console.WriteLine("The dog door opens.");
            autoCloseDoor();
        }

        public void close()
        {
            isOpen = false;
            Console.WriteLine("The dog door closes.");
        }

        private void autoCloseDoor()
        {
            _timer.Enabled = true;
        }

        private void _timer_Elapsed_CloseDoor(object sender, ElapsedEventArgs e)
        {
            close();
            _timer.Enabled = false;
        }
    }
}
