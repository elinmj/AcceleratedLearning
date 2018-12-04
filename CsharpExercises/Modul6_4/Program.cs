using System;

namespace Modul6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Person lisa = new Person
            {
                FirstName = "Lisa",
                LastName = "Bo",
                Birthday = new DateTime(2000, 3, 4),
                FavoriteSport = Sport.Tennis,
                Gender = Gender.Female
            };

            Console.WriteLine($"Lisa is a {lisa.Gender.ToString().ToLower()}");
            Console.WriteLine($"Lisa likes to play {lisa.FavoriteSport.ToString().ToLower()}");
            Console.WriteLine($"Lisa doesn't like to play  ");

            if (lisa.FavoriteSport == Sport.Rugby)
            {
                Console.WriteLine($"Lisa likes to play rugby");
            }
            else
            {
                Console.WriteLine($"Lisa don't like to play rugby");
            }

            Console.WriteLine();

            foreach (var sportName in Enum.GetNames(typeof(Sport)))
            {
                Console.WriteLine($"* {sportName}");
            }

            Console.WriteLine();

            Console.WriteLine("Enter a sport:");

            //EJ KLAR MED UPPGIFTEN
        }
    }
}
