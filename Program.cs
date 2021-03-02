using Newtonsoft.Json;
using System;
using System.IO;

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
            Console.Write("Map Width: ");
            string mw = Console.ReadLine();
            int width = int.Parse(mw);
            Console.Write("Map Height: ");
            string mh = Console.ReadLine();
            int height = int.Parse(mh);
            NewLine();
            Console.WriteLine("Map Details:");
            Console.WriteLine("Width: " + mw);
            Console.WriteLine("Height: " + mh);
            NewLine();
            Console.WriteLine("Confirm Map Details & Proceed to Export? Y/N");
            string input = Console.ReadLine();
            if (input.ToUpper() == "Y")            
                PrintExportDest(width, height);           
            else
                ReturnToStart();

        }

        /// <summary>
        /// Prints the screen text for importing a map.
        /// </summary>
        private static void PrintImport()
        {
            Console.Clear();
            Console.WriteLine("Import a Map");
            NewLine();
            Console.Write("Resource Path: ");
            string path = Console.ReadLine();
            Console.WriteLine("Confirm Resource Path: " + path);
            Console.WriteLine("Y/N");
            string input = Console.ReadLine();
            if (input.ToUpper() == "Y")
                LoadMap(path);
            else
            {
                Console.WriteLine("Resource not found. Restart? Y/N");
                string reInput = Console.ReadLine();
                if (reInput.ToUpper() == "Y")
                    PrintImport();
                else
                    ReturnToStart();
            }
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
            Start();
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
        private static void PrintExportDest(int width, int height)
        {
            World exportWorld = new World();
            exportWorld.Map = new Map(width, height);

            Console.Clear();
            Console.WriteLine("Export a Map to destination");
            NewLine();
            Console.Write("Export destination: ");
            string path = Console.ReadLine();
            Console.WriteLine("Confirm export destination path: " + path);
            Console.WriteLine("Y/N");
            string input = Console.ReadLine();
            Console.Write("File Name: ");
            string name = Console.ReadLine();
            if (input.ToUpper() == "Y")
                Export(exportWorld.Map, path, name);
            else
                ReturnToStart();
        }

        /// <summary>
        /// Returns to the exporter start menu.
        /// </summary>
        private static void ReturnToStart()
        {
            Console.Clear();
            Start();
        }

        /// <summary>
        /// Serializes and loads the specified resource.
        /// </summary>
        private static void LoadMap(string path)
        {
            Console.Clear();
            Console.WriteLine("Importing Map...");

            Map map = JsonConvert.DeserializeObject<Map>(File.ReadAllText(path));
            //using (StreamReader rdr = File.OpenText(path))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    Map mapS = (Map)serializer.Deserialize(rdr, typeof(Map));
            //}
            Console.WriteLine("Map Succesfully Imported.");
            NewLine();
            Console.WriteLine("Map Data:");
            Console.WriteLine("Map Width: " + map.Width);
            Console.WriteLine("Map Height: " + map.Height);
            NewLine();
            Console.WriteLine("Type [C] to continue.");
            string input = Console.ReadLine();
            if (input.ToUpper() == "C")
                ReturnToStart();
        }

        /// <summary>
        /// Serializes and exports the map to the specified destination.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="path"></param>
        private static void Export(Map map, string path, string fileName)
        {
            Console.Clear();
            Console.WriteLine("Exporting Map...");
            NewLine();

            File.WriteAllText(path + fileName + "_export.json", JsonConvert.SerializeObject(map));

            Console.WriteLine("Map Exported Succesfully.");
            Console.WriteLine("Type [C] to continue.");
            string input = Console.ReadLine();
            if (input.ToUpper() == "C")
                ReturnToStart();
        }
    }
}
