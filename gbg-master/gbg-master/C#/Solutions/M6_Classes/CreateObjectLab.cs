using System;

namespace M6_Classes
{
    public static class CreateObjectLab
    {
        public static void Run()
        {
            // 6.1 Create circles
            //CreateCircles();

            // 6.2 Create cubes
            CreateCuboids();

            //CreateSimpleCuboids();

            Console.WriteLine();
        }

        private static void CreateCircles()
        {
            Circle bob = new Circle("Bob", 8);
            Circle lisa = new Circle("Lisa", 30);

            bob.SayHello();
            lisa.SayHello();

            Console.WriteLine();

            bob.WriteArea();
            lisa.WriteArea();
        }

        private static void CreateCuboids()
        {
            Cuboid myCuboid = new Cuboid(2, 3, 4);
            Cuboid superCuboid = new Cuboid(100, 200, 300);

            myCuboid.WriteVolume();
            superCuboid.WriteVolume();

            double volume = myCuboid.CalculateVolume();
            Console.WriteLine($"Volume: {volume}");

            double supervolume = superCuboid.CalculateVolume();
            Console.WriteLine($"Volume: {supervolume}");
        }

        // Den enda skillnaden är att SimpleCuboid inte har nån konstruktor, utan vi jobbar med properties

        private static void CreateSimpleCuboids()
        {
            SimpleCuboid mycuboid = new SimpleCuboid() {Width = 3, Height = 4, Depth = 5};

            mycuboid.WriteVolume();

            double volume = mycuboid.CalculateVolume();
            Console.WriteLine($"Volume: {volume}");

        }
    }
}
