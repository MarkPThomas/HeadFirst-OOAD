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

        public List<Bark> allowedBarks { get; private set; } = new List<Bark>();

        public bool isOpen { get; private set; }


        public DogDoor()
        {
            isOpen = false;
            _timer.Elapsed += new ElapsedEventHandler(timer_Elapsed_CloseDoor);
        }

        public void AddAllowedBark(Bark bark)
        {
            allowedBarks.Add(bark);
        }

        public void Open()
        {
            isOpen = true;
            Console.WriteLine("The dog door opens.");
            AutoCloseDoor();
        }

        public void Close()
        {
            isOpen = false;
            Console.WriteLine("The dog door closes.");
        }

        private void AutoCloseDoor()
        {
            _timer.Enabled = true;
        }

        private void timer_Elapsed_CloseDoor(object sender, ElapsedEventArgs e)
        {
            Close();
            _timer.Enabled = false;
        }
    }
}
