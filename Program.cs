using System;

namespace MapExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Experimental JSON Map Exporter";
            Start();

            while (true)
                Console.ReadLine();
        }

        private static void Start()
        {           
            Console.WriteLine("Map Exporter Status [READY]");
            NewLine();
            Console.WriteLine("Available Commands:");
            NewLine();
            Console.WriteLine("> export");
            Console.WriteLine("> import");
            Console.WriteLine("> help");
            NewLine();

            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "export":
                    PrintExport();
                    break;

                case "import":
                    PrintImport();
                    break;

                case "help":
                    PrintHelp();
                    break;
            }
        }

        private static void PrintExport()
        {
            Console.Clear();
            Console.WriteLine("Export a Map");
            NewLine();
            Console.Write("Map Name: ");
            string name = Console.ReadLine();
            Console.Write("Map Width: ");
            string mw = Console.ReadLine();
            int width = int.Parse(mw);
            Console.Write("Map Height: ");
            string mh = Console.ReadLine();
            int height = int.Parse(mh);
            NewLine();
            Console.WriteLine("Map Details:");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Width: " + mw);
            Console.WriteLine("Height: " + mh);
            NewLine();
            Console.WriteLine("Confirm Map Details & Proceed to Export? Y/N");
            string input = Console.ReadLine();
            if (input.ToUpper() == "Y")            
                PrintExportDest(name, width, height);           
            else
                ReturnToStart();

        }

        private static void PrintImport()
        {

        }

        private static void PrintHelp()
        {

        }

        private static void NewLine()
        {
            Console.WriteLine("");
        }

        private static void PrintExportDest(string name, int width, int height)
        {
            World exportWorld = new World();
            exportWorld.Map = new Map(name, width, height);

            Console.Clear();
            Console.WriteLine("Export a Map to destination");
            NewLine();
            Console.Write("Export destination: ");
            string path = Console.ReadLine();
            Console.WriteLine("Confirm export destination path: " + path);
            Console.WriteLine("Y/N");
        }

        private static void ReturnToStart()
        {
            Console.Clear();
            Start();
        }
    }
}
