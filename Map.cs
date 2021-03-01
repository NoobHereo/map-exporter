using System;

namespace MapExporter
{
    /// <summary>
    /// The Map class holds information regarding the properties of a World's map.
    /// </summary>
    public class Map
    {
        public string Name { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Map(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
        }
    }
}