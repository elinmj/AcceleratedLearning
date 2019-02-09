namespace M6_Classes
{
    class SimpleCuboid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }

        public double CalculateVolume()
        {
            return Width * Height * Depth;
        }

        public void WriteVolume()
        {
            double area = CalculateVolume();
            System.Console.WriteLine($"The volume of the cuboid is {area}");
        }
    }
}
