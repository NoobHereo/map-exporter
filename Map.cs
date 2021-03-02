using System;

namespace MapExporter
{
    /// <summary>
    /// The Map class holds information regarding the properties of a World's map.
    /// </summary>
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}