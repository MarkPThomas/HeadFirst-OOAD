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

            Guitar whatErinLikes = new Guitar("", 0, Builder.Fender, "Stratocastor", Type.electric, Wood.Alder, Wood.Alder);
            Guitar guitar = inventory.search(whatErinLikes);
            if (guitar != null)
            {
                string msgSuccess = "Erin, you might like this " +
                    Enumerations.GetEnumDescription(guitar.builder) + " " + guitar.model + " " +
                    Enumerations.GetEnumDescription(guitar.type) + " guitar:\n    " +
                    Enumerations.GetEnumDescription(guitar.backWood) + " back and sides,\n    " +
                    Enumerations.GetEnumDescription(guitar.topWood) + " top.\nYou can have it for only $" +
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
            inventory.addGuitar("V12345", 0, Builder.Fender, "Stratocastor", Type.electric, Wood.Alder, Wood.Adirondack);
            inventory.addGuitar("A21457", 0, Builder.Collings, "OakTown Goove", Type.acoustic, Wood.Brazilian_Rosewood, Wood.Cedar);
            inventory.addGuitar("V95693", 1499.95, Builder.Fender, "Stratocastor", Type.electric, Wood.Alder, Wood.Alder);
            inventory.addGuitar("X54321", 0, Builder.Martin, "Stratocastor Light", Type.electric, Wood.Indian_Rosewood, Wood.Maple);
            inventory.addGuitar("X99876", 0, Builder.PRS, "Stratocastor FeatherWeight", Type.electric, Wood.Sitka, Wood.Cocobolo);
        }
    }
}
