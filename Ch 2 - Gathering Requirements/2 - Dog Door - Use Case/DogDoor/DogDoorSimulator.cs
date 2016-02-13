using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DogDoor
{
    class DogDoorSimulator
    {
        public static void DogDoorTestPath(int dogOutsideTime)
        {
            DogDoor door = new DogDoor();
            Remote remote = new Remote(door);

            Console.WriteLine("\nFido barks to go outside ...");
            remote.pressButton();

            Console.WriteLine("\nFido has gone outside for " + dogOutsideTime/1000 + " seconds ...");
            System.Threading.Thread.Sleep(dogOutsideTime);
            Console.WriteLine("\nFido's all done ...");

            bool firstBark = true;
            while (!door.isOpen)
            {
                if (firstBark)
                {
                    Console.WriteLine("\n... But he's stuck outside!");
                    Console.WriteLine("\nFido starts barking ...");
                    firstBark = false;
                    Console.WriteLine("\nSo Gina grabs the remote control ...");
                    remote.pressButton();
                }
            }

            Console.WriteLine("\nFido's back inside ...");

            while(door.isOpen)
            {
                // Wait
            }
            Console.WriteLine("\nTest passed! Press any key to continue.\n");
            
            Console.ReadKey();
        }
    }
}
