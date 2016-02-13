using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogDoor
{
    class DogDoor
    {
        public bool isOpen { get; private set; }


        public DogDoor()
        {
            isOpen = false;
        }

        public void open()
        {
            isOpen = true;
            Console.WriteLine("The dog door opens.");
        }

        public void close()
        {
            isOpen = false;
            Console.WriteLine("The dog door closes.");
        }
    }
}
