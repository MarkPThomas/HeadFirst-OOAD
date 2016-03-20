using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentApp
{
    class FindInstrumentTester
    {

        public static void testInstrumentSearch()
        {
            // Set up Rick's instrument inventory
            Inventory inventory = new Inventory();
            initializeInventory(inventory);

            GuitarSpec whatErinLikes = new GuitarSpec(Builder.Fender, "Stratocastor", Type.electric, Wood.Alder, Wood.Alder, 6);
            findInstrument("Erin", whatErinLikes, inventory);

            MandolinSpec whatPhilLikes = new MandolinSpec(Builder.Fender, "Stratocastor", Type.acoustic, Wood.Alder, Wood.Alder, Style.A);
            findInstrument("Phil", whatPhilLikes, inventory);
        }

        private static void findInstrument(string name, InstrumentSpec instrumentSpec, Inventory inventory)
        {
            List<Instrument> instruments = inventory.search(instrumentSpec);
            string choiceInstrument = "";

            if (instruments.Count > 0)
            {
                try
                {
                    string msgSuccess = string.Format("{0}, you might like these instruments: ", name);
                    foreach (Instrument instrument in instruments)
                    {
                        InstrumentSpec spec = null;
                        if (instrumentSpec is GuitarSpec)
                        {
                            Guitar guitar = (Guitar)instrument;
                            spec = guitar.spec;
                            choiceInstrument = guitar.ToString().ToLower();
                        }
                        else if (instrumentSpec is MandolinSpec)
                        {
                            Mandolin mandolin = (Mandolin)instrument;
                            spec = mandolin.spec;
                            choiceInstrument = mandolin.ToString().ToLower();
                        }
                        if (spec == null) { messageFail(name); }

                        msgSuccess += "\nWe have a " +
                            Enumerations.GetEnumDescription(spec.builder) + " " + spec.model + " " +
                            Enumerations.GetEnumDescription(spec.type) + " " + choiceInstrument +":\n    " +
                            Enumerations.GetEnumDescription(spec.backWood) + " back and sides,\n    " +
                            Enumerations.GetEnumDescription(spec.topWood) + " top.\nYou can have it for only $" +
                            instrument.price + "!\n  ----";
                    }
                    Console.WriteLine(msgSuccess);
                    Console.ReadKey();

                    return;
                }
                catch (Exception)
                {
                    // No action taken. Default fail message will be triggered at end of method.
                }
            }
            messageFail(name);
        }

        private static void messageFail(string name)
        {
            string msgFail = string.Format("Sorry, {0}, we have nothing for you.", name);
            Console.WriteLine(msgFail);
            Console.ReadKey();
        }

        private static void initializeInventory(Inventory inventory)
        {
            initializeGuitarInventory(inventory);
            initializeMandolinInventory(inventory);
        }

        private static void initializeGuitarInventory(Inventory inventory)
        {
            // Add Guitars to the inventory ...
            inventory.addInstrument("V12345", 1345.55, new GuitarSpec(Builder.Fender, "Stratocastor", Type.electric, Wood.Alder, Wood.Adirondack, 6));
            inventory.addInstrument("A21457", 900.55, new GuitarSpec(Builder.Collings, "OakTown Goove", Type.acoustic, Wood.Brazilian_Rosewood, Wood.Cedar, 6));
            inventory.addInstrument("V95693", 1499.95, new GuitarSpec(Builder.Fender, "Stratocastor", Type.electric, Wood.Alder, Wood.Alder, 6));
            inventory.addInstrument("X54321", 430.54, new GuitarSpec(Builder.Martin, "Stratocastor Light", Type.electric, Wood.Indian_Rosewood, Wood.Maple, 6));
            inventory.addInstrument("X99876", 2000.00, new GuitarSpec(Builder.PRS, "Stratocastor FeatherWeight", Type.electric, Wood.Sitka, Wood.Cocobolo, 6));
            inventory.addInstrument("V9512", 1549.95, new GuitarSpec(Builder.Fender, "Stratocastor", Type.electric, Wood.Alder, Wood.Alder, 6));
        }

        private static void initializeMandolinInventory(Inventory inventory)
        {
            // Add Mandolins to the inventory ...
            inventory.addInstrument("X12345", 1745.55, new MandolinSpec(Builder.Fender, "Stratocastor", Type.electric, Wood.Alder, Wood.Adirondack, Style.A));
            inventory.addInstrument("Q21457", 1200.55, new MandolinSpec(Builder.Collings, "OakTown Goove", Type.acoustic, Wood.Brazilian_Rosewood, Wood.Cedar, Style.F));
            inventory.addInstrument("S95693", 1699.95, new MandolinSpec(Builder.Fender, "Stratocastor", Type.acoustic, Wood.Alder, Wood.Alder, Style.A));
        }
    }
}
