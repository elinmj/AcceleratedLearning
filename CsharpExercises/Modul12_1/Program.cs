using System;
using System.Collections.Generic;

namespace Modul12_1
{
    class Program
    {
        static void Main(string[] args)         //Kolla lösningen!
        {
            string[] rockstarsArray = new string[] { "Jim Morrison", "Ozzy Osborne", "David Bowie", "Freddie Mercury" };
            List<string> rockstarsList = new List<string> { "Jim Morrison", "Ozzy Osborne", "David Bowie", "Freddie Mercury" };

            DisplayArrayOfRockStars(rockstarsArray);
            DisplayListOfRockStars(rockstarsList);
            IenumerableOfStrings(rockstarsArray,rockstarsList);

        }

        private static void IenumerableOfStrings(IEnumerable<string> rockstarsArray,IEnumerable<string> rockstarsList)
        {
            Console.WriteLine("My rockstars, ienumerable:");

            foreach (var item in rockstarsList)
            {
                Console.WriteLine($"* {item}");
            }

            Console.WriteLine();

            Console.WriteLine("My rockstars, ienumerable:");

            foreach (var item in rockstarsArray)
            {
                Console.WriteLine($"* {item}");
            }

            Console.WriteLine();
        }

        private static void DisplayListOfRockStars(List<string> rockstarsList)
        {
            Console.WriteLine("My rockstars, array:");

            foreach (var item in rockstarsList)
            {
                Console.WriteLine($"* {item}");
            }

            Console.WriteLine();
        }

        private static void DisplayArrayOfRockStars(string[] rockstarsArray)
        {
            Console.WriteLine("My rockstars, list:");

            foreach (var item in rockstarsArray)
            {
                Console.WriteLine($"* {item}");
            }

            Console.WriteLine();
        }
    }
}
