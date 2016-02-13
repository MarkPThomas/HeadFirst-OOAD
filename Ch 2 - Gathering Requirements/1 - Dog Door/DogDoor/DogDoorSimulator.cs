using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogDoor
{
    class DogDoorSimulator
    {
        public static void dogDoorTest()
        {
            DogDoor door = new DogDoor();
            Remote remote = new Remote(door);

            Console.WriteLine("Fido barks to go outside ...");
            remote.pressButton();
            Console.WriteLine("\nFido has gone outside ...");
            remote.pressButton();
            Console.WriteLine("\nFido's all done ...");
            remote.pressButton();
            Console.WriteLine("\nFido's back inside ...");
            remote.pressButton();
            Console.ReadKey();
        }
    }
}
