﻿using System;

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

        /// <summary>
        /// Prints the start screen text.
        /// </summary>
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

        /// <summary>
        /// Prints the screen text for exporting a map and filling in the blanks for needed map information.
        /// </summary>
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

        /// <summary>
        /// Prints the screen text for importing a map.
        /// </summary>
        private static void PrintImport()
        {

        }

        /// <summary>
        /// Prints available commands for the exporter.
        /// </summary>
        private static void PrintHelp()
        {
            NewLine();
            Console.WriteLine("Available Commands:");
            NewLine();
            Console.WriteLine("> export");
            Console.WriteLine("> import");
            Console.WriteLine("> help");
            NewLine();
        }

        /// <summary>
        /// Prints a newline. This is very janky :)
        /// </summary>
        private static void NewLine()
        {
            Console.WriteLine("");
        }

        /// <summary>
        /// Prints the screen text needed for specifying the destination path that the map file is exported to.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
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

        /// <summary>
        /// Returns to the exporter start menu.
        /// </summary>
        private static void ReturnToStart()
        {
            Console.Clear();
            Start();
        }
    }
}
