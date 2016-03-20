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

            Dictionary<string, object> guitarSpec = new Dictionary<string, object>{
                                                                { "instrumentType", InstrumentType.Guitar },
                                                                { "builder", Builder.Fender},
                                                                { "model", "Stratocastor" },
                                                                { "type", Type.electric},
                                                                { "topWood", Wood.Alder},
                                                                { "backWood", Wood.Adirondack},
                                                                { "numStrings", 6}
                                                        };
            InstrumentSpec whatErinLikes = new InstrumentSpec(guitarSpec);
            findInstrument("Erin", whatErinLikes, inventory);


            Dictionary<string, object> mandolinSpec = new Dictionary<string, object>{
                                                                { "instrumentType", InstrumentType.Mandolin },
                                                                { "builder", Builder.Fender},
                                                                { "model", "Stratocastor" },
                                                                { "type", Type.acoustic},
                                                                { "topWood", Wood.Alder},
                                                                { "backWood", Wood.Alder},
                                                                { "style", Style.A}
                                                        };
            InstrumentSpec whatPhilLikes = new InstrumentSpec(mandolinSpec);
            findInstrument("Phil", whatPhilLikes, inventory);

            Dictionary<string, object> multiInstrumentSpec = new Dictionary<string, object>{
                                                                { "builder", Builder.Gibson},
                                                                { "backWood", Wood.Maple},
                                                        };
            InstrumentSpec whatSallyLikes = new InstrumentSpec(multiInstrumentSpec);
            findInstrument("Sally", whatSallyLikes, inventory);
        }

        private static void findInstrument(string name, InstrumentSpec instrumentSpec, Inventory inventory)
        {
            List<Instrument> instruments = inventory.search(instrumentSpec);

            if (instruments.Count > 0)
            {
                try
                {
                    string msgSuccess = string.Format("{0}, you might like these instruments: ", name);
                    foreach (Instrument instrument in instruments)
                    {
                        InstrumentSpec spec = instrument.spec;
                        if (spec == null) { messageFail(name); }

                        string instrumentType = Enumerations.GetEnumDescription((InstrumentType)spec.getProperty("instrumentType"));

                        msgSuccess += "\nWe have a " + instrumentType +
                            " with the following properties: ";

                        foreach (string propertyName in spec.properties.Keys)
                        {
                            if (propertyName.CompareTo("instrumentType") == 0) { continue; }
                            msgSuccess += "\n    " + propertyName + ": " + spec.getProperty(propertyName);
                        }
                        msgSuccess += "\nYou can have this " + instrumentType + " for $" +
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
            initializeBanjosInventory(inventory);
        }

        private static void initializeGuitarInventory(Inventory inventory)
        {
            // Add Guitars to the inventory ...
            inventory.addInstrument("V12345", 1345.55, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Guitar },
                                                                            { "builder", Builder.Fender},
                                                                            { "model", "Stratocastor" },
                                                                            { "type", Type.electric},
                                                                            { "topWood", Wood.Alder},
                                                                            { "backWood", Wood.Adirondack},
                                                                            { "numStrings", 6} }));
            inventory.addInstrument("A21457", 900.55, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Guitar },
                                                                            { "builder", Builder.Collings},
                                                                            { "model", "OakTown Goove" },
                                                                            { "type", Type.acoustic},
                                                                            { "topWood", Wood.Brazilian_Rosewood},
                                                                            { "backWood", Wood.Cedar},
                                                                            { "numStrings", 6} }));
            inventory.addInstrument("V95693", 1499.95, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Guitar },
                                                                            { "builder", Builder.Fender},
                                                                            { "model", "Stratocastor" },
                                                                            { "type", Type.electric},
                                                                            { "topWood", Wood.Alder},
                                                                            { "backWood", Wood.Adirondack},
                                                                            { "numStrings", 6} }));
            inventory.addInstrument("X54321", 430.54, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Guitar },
                                                                            { "builder", Builder.Martin},
                                                                            { "model", "Stratocastor Light" },
                                                                            { "type", Type.electric},
                                                                            { "topWood", Wood.Indian_Rosewood},
                                                                            { "backWood", Wood.Maple},
                                                                            { "numStrings", 6} }));
            inventory.addInstrument("X99876", 2000.00, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Guitar },
                                                                            { "builder", Builder.PRS},
                                                                            { "model", "Stratocastor FeatherWeight" },
                                                                            { "type", Type.electric},
                                                                            { "topWood", Wood.Sitka},
                                                                            { "backWood", Wood.Cocobolo},
                                                                            { "numStrings", 6} }));
            inventory.addInstrument("V9512", 1549.95, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Guitar },
                                                                            { "builder", Builder.Fender},
                                                                            { "model", "Stratocastor" },
                                                                            { "type", Type.electric},
                                                                            { "topWood", Wood.Alder},
                                                                            { "backWood", Wood.Adirondack},
                                                                            { "numStrings", 6} }));
            inventory.addInstrument("11277", 3999.95, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Guitar },
                                                                            { "builder", Builder.Collings},
                                                                            { "model", "CJ" },
                                                                            { "type", Type.acoustic},
                                                                            { "topWood", Wood.Spruce},
                                                                            { "backWood", Wood.Indian_Rosewood },
                                                                            { "numStrings", 6} }));
            inventory.addInstrument("122784", 5495.95, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Guitar },
                                                                            { "builder", Builder.Martin},
                                                                            { "model", "D-18" },
                                                                            { "type", Type.acoustic},
                                                                            { "topWood", Wood.Adirondack},
                                                                            { "backWood", Wood.Mahogany },
                                                                            { "numStrings", 6} }));
            inventory.addInstrument("82765501", 1890.95, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Guitar },
                                                                            { "builder", Builder.Gibson},
                                                                            { "model", "SG'61" },
                                                                            { "type", Type.electric},
                                                                            { "topWood", Wood.Mahogany},
                                                                            { "backWood", Wood.Mahogany },
                                                                            { "numStrings", 6} }));
            inventory.addInstrument("70108276", 2295.95, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Guitar },
                                                                            { "builder", Builder.Gibson},
                                                                            { "model", "Les Paul" },
                                                                            { "type", Type.electric},
                                                                            { "topWood", Wood.Maple},
                                                                            { "backWood", Wood.Maple },
                                                                            { "numStrings", 6} }));
        }

        private static void initializeMandolinInventory(Inventory inventory)
        {
            // Add Mandolins to the inventory ...
            inventory.addInstrument("X12345", 1745.55, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Mandolin },
                                                                            { "builder", Builder.Fender},
                                                                            { "model", "Stratocastor" },
                                                                            { "type", Type.electric},
                                                                            { "topWood", Wood.Alder},
                                                                            { "backWood", Wood.Adirondack},
                                                                            { "style", Style.A} }));
            inventory.addInstrument("Q21457", 1200.55, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Mandolin },
                                                                            { "builder", Builder.Collings},
                                                                            { "model", "OakTown Goove" },
                                                                            { "type", Type.acoustic},
                                                                            { "topWood", Wood.Brazilian_Rosewood},
                                                                            { "backWood", Wood.Cedar},
                                                                            { "style", Style.F} }));
            inventory.addInstrument("S95693", 1699.95, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Mandolin },
                                                                            { "builder", Builder.Fender},
                                                                            { "model", "Stratocastor" },
                                                                            { "type", Type.acoustic},
                                                                            { "topWood", Wood.Alder},
                                                                            { "backWood", Wood.Alder},
                                                                            { "style", Style.A} }));
            inventory.addInstrument("9019920", 5495.99, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Mandolin },
                                                                            { "builder", Builder.Gibson},
                                                                            { "model", "F5-G" },
                                                                            { "type", Type.acoustic},
                                                                            { "topWood", Wood.Maple},
                                                                            { "backWood", Wood.Maple},
                                                                            { "style", Style.F} }));
        }

        private static void initializeBanjosInventory(Inventory inventory)
        {
            inventory.addInstrument("8900231", 2945.95, new InstrumentSpec(new Dictionary<string, object> {
                                                                            { "instrumentType", InstrumentType.Banjo },
                                                                            { "builder", Builder.Gibson},
                                                                            { "model", "RB-3" },
                                                                            { "type", Type.acoustic},
                                                                            { "backWood", Wood.Maple},
                                                                            { "style", Style.F} }));
        }
    }
}
