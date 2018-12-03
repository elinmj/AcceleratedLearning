using System;

namespace Module6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Grunduppgift 

            //Cube mycube = new Cube(2, 3, 4);
            //Cube supercube = new Cube(100, 200, 300);

            //mycube.WriteVolume();
            //supercube.WriteVolume();

            //Console.WriteLine();


            //Extra

            //Cube mycube = new Cube(2, 3, 4);
            //Cube supercube = new Cube(100, 200, 300);

            //double volume = mycube.CalculateVolume();
            //Console.WriteLine($"Volume: {volume}");

            //double supervolume = supercube.CalculateVolume();
            //Console.WriteLine($"Volume: {supervolume}");


            //Extra 2

            //Cube mycube = new Cube(2, 3, 4);
            //Cube supercube = new Cube(100, 200, 300);

            //double area = mycube.CalculateArea();
            //Console.WriteLine($"Area: {volume}");

            //double superarea = supercube.CalculateArea();
            //Console.WriteLine($"Area: {superarea}");


            //Extra 3

            Console.WriteLine("Choose color for Cube:");
            Cube mycube = new Cube(2, 3, 4, Console.ReadLine(), "wood");

            Console.WriteLine("Choose color for Supercube:");
            Cube supercube = new Cube(100, 200, 300, Console.ReadLine(), "steel");

            double volume = mycube.CalculateVolume();
            double area = mycube.CalculateArea();
            string color = mycube.CubeColor();
            string material = mycube.CubeMaterial();
            Console.WriteLine($"Volume: {volume}, Area: {area}, Color: {color}, Material: {material}");

            double supervolume = supercube.CalculateVolume();
            double superarea = supercube.CalculateArea();
            string supercolor = supercube.CubeColor();
            string supermaterial = supercube.CubeMaterial();
            Console.WriteLine($"Volume: {supervolume}, Area: {superarea}, Color: {supercolor}, Material: {supermaterial}");
        }

    }
}
