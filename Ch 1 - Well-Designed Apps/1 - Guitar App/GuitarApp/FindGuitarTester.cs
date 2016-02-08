using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp
{
    class FindGuitarTester
    {

        public static void testErin()
        {
            // Set up Rick's guitar inventory
            Inventory inventory = new Inventory();
            initializeInventory(inventory);

            Guitar whatErinLikes = new Guitar("", 0, "Fender", "Stratocastor", "electric", "Alder", "Alder");
            Guitar guitar = inventory.search(whatErinLikes);
            if (guitar != null)
            {
                string msgSuccess = "Erin, you might like this " +
                    guitar.builder + " " + guitar.model + " " +
                    guitar.type + " guitar:\n    " +
                    guitar.backWood + " back and sides,\n    " +
                    guitar.topWood + " top.\nYou can have it for only $" +
                    guitar.price + "!";

                Console.WriteLine(msgSuccess);
                Console.ReadKey();
            }
            else
            {
                string msgFail = "Sorry, Erin, we have nothing for you.";
                Console.WriteLine(msgFail);
                Console.ReadKey();
            }
        }

        private static void initializeInventory(Inventory inventory)
        {
            // Add Guitars to the inventory ...
            inventory.addGuitar("V12345", 0, "Fender", "Stratocastor", "electric", "Alder", "Pine");
            inventory.addGuitar("A21457", 0, "Blender", "OakTown Goove", "acoustic", "Oak", "Oak");
            inventory.addGuitar("V95693", 1499.95, "Fender", "Stratocastor", "electric", "Alder", "Alder");
            inventory.addGuitar("X54321", 0, "Fender Bender", "Stratocastor Light", "electric", "Balsa", "Bass");
            inventory.addGuitar("X99876", 0, "Fender Bender", "Stratocastor FeatherWeight", "electric", "Balsa", "Alder");
        }
    }
}
