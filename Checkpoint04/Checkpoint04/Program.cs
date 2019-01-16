using System;
using System.Collections.Generic;

namespace Checkpoint04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Level1
            //var dataAccess = new DataAccess();
            //List<string> gnomes = dataAccess.GetGnomesFromDatabase();
            //DisplayGnomes(gnomes);

            //Level2
            var dataAccess = new DataAccess();
            List<Gnome> gnomes = dataAccess.GetGnomesFromDatabase();
            DisplayGnomes(gnomes);
        }

        private static void DisplayGnomes(List<Gnome> gnomes)
        {
            //Level1 - fungerar nu endast om metoden istället tar in en lista av strängar
            //for (int i = 0; i < gnomes.Count; i++)
            //{
            //    if (i == 0)
            //    {
            //        Console.WriteLine("TOMTAR");
            //    }
            //    Console.WriteLine(gnomes[i]);
            //}


            //Level2

            for (int i = 0; i < gnomes.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"{"TOMTAR",-15}{"HAR SKÄGG",-15}{"ÄR OND",-15}{"TEMPERAMENT",-15}{"RAS",-15}");
                }

                Console.WriteLine($"{gnomes[i].Name,-15}{gnomes[i].Beard,-15}{gnomes[i].Evil,-15}{gnomes[i].Temperament,-15}{gnomes[i].Race,-15}");
            }

            Console.ReadKey();
        }
    }
}
