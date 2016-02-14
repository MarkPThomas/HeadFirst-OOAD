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
        public static void DogDoorTestPath(int dogOutsideTime, bool ownersResponsive)
        {
            DogDoor door = new DogDoor();
            BarkRecognizer recognizer = new BarkRecognizer(door);
            Remote remote = new Remote(door);

            Console.WriteLine("\nFido barks to go outside ...");
            InitiateDoorOpen(ownersResponsive, remote, recognizer);

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
                    InitiateDoorOpen(ownersResponsive, remote, recognizer);
                }
            }

            Console.WriteLine("\nFido's back inside ...");

            while(door.isOpen)
            {
                // Wait
            }
        }

        private static void InitiateDoorOpen(bool ownersResponsive, Remote remote, BarkRecognizer recognizer)
        {
            if (ownersResponsive)
            {
                Console.WriteLine("\nSo Gina grabs the remote control ...");
                remote.pressButton();
            }
            else
            {
                recognizer.recognize("Woof");
                Console.WriteLine("\nThe door hears the dog and opens ...");
            }
        }

    }
}
