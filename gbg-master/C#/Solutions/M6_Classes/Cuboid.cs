namespace M6_Classes
{
   
    class Cuboid
    {
        double width;
        double height;
        double depth;

        public Cuboid(double _width, double _height, double _depth)
        {
            width = _width;
            height = _height;
            depth = _depth;
        }

        public double CalculateVolume()
        {
            return width * height * depth;
        }

        public void WriteVolume()
        {
            double volume = CalculateVolume();
            System.Console.WriteLine($"The volume of the cuboid is {volume}");
        }
    }
}
