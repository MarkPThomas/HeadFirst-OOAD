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
        public static int DogDoorTestPath(int dogOutsideTime, bool ownersResponsive)
        {
            DogDoor door = new DogDoor();
            door.AddAllowedBark(new Bark("rowlf"));
            door.AddAllowedBark(new Bark("rooowlf"));
            door.AddAllowedBark(new Bark("rawlf"));
            door.AddAllowedBark(new Bark("woof"));
            BarkRecognizer recognizer = new BarkRecognizer(door);
            Remote remote = new Remote(door);

            bool isOwnersDog = true;

            Console.WriteLine("\nBruce barks to go outside ...");
            InitiateDoorOpen(ownersResponsive, isOwnersDog, remote, recognizer);

            Console.WriteLine("\nBruce has gone outside for " + dogOutsideTime/1000 + " seconds ...");
            System.Threading.Thread.Sleep(dogOutsideTime);
            Console.WriteLine("\nBruce is all done ...");

            bool firstBark = true;
            while (!door.isOpen)
            {
                if (firstBark)
                {
                    Console.WriteLine("\n... But he's stuck outside!");
                    firstBark = false;

                    // A different dog barks
                    if (!ownersResponsive)
                    {
                        InitiateDoorOpen(ownersResponsive, !isOwnersDog, remote, recognizer);
                        if (door.isOpen)
                        {
                            Console.WriteLine("\nAnother dog besides Bruce has come inside! ...");
                            return 1;
                        }
                        Console.WriteLine("\nThis dog is not allowed ...");
                    }
                    

                    // Bruce barks
                    InitiateDoorOpen(ownersResponsive, isOwnersDog, remote, recognizer);
                    if (door.isOpen)
                    {
                        Console.WriteLine("\nBruce is back inside ...");
                    }
                }
            }

            while(door.isOpen)
            {
                // Wait
            }

            return 0;
        }

        private static void InitiateDoorOpen(bool ownersResponsive, bool isOwnersDog, Remote remote, BarkRecognizer recognizer)
        {
            if (ownersResponsive)
            {
                Console.WriteLine("\nSo Gina grabs the remote control ...");
                remote.pressButton();
            }
            else
            {
                if (isOwnersDog)
                {
                    // Now Bruce starts barking
                    Console.WriteLine("\nBruce starts barking ...");
                    recognizer.recognize(new Bark("rooowlf"));
                }
                else
                {
                    // Begin with another dog barking
                    Bark smallDogBark = new Bark("yip");
                    Console.WriteLine("\nBitsie starts barking ...");
                    recognizer.recognize(smallDogBark);
                }
            }
        }

    }
}
