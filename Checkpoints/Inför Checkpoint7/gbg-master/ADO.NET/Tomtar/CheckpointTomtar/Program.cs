using System;
using System.Collections.Generic;

namespace CheckpointTomtar
{
    class Program
    {
        static void Main()
        {
            AddGnome();

            var dataAccess = new DataAccess();
            List<Gnome> gnomes = dataAccess.GetGnomesFromDatabase();
            DisplayGnomes(gnomes);

            Console.ReadKey();
        }

        private static void AddGnome()
        {
            var dataAccess = new DataAccess();

            Console.Write("Ange tomte att lägga till: ");
            string name = Console.ReadLine();

            dataAccess.AddGnome_Vulnerable(name);
            Console.WriteLine();
        }

        private static void DisplayGnomes(IEnumerable<Gnome> gnomes)
        {
            DisplayRow("NAMN", "HAR SKÄGG", "ÄR OND", "TEMPERAMENT", "RAS");
            foreach (Gnome gnome in gnomes)
            {
                DisplayRow(gnome.Name, YesNo(gnome.HasBeard), YesNo(gnome.IsEvil), gnome.Temperament.ToString(), gnome.Race);

            }

            Console.WriteLine();
        }

        private static void DisplayRow(params string[] cols)
        {
            foreach (string x in cols)
                Console.Write(x.PadRight(15));

            Console.WriteLine();
        }

        private static string YesNo(bool b)
        {
            return b ? "Ja" : "Nej";
        }
    }
}
