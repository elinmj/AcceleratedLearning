using System;

namespace M6_Classes
{
    public static class EnumLab
    {
        public static void Run()
        {
            Person lisa = new Person
            {
                FirstName = "Lisa",
                LastName = "Smith",
                Birthday = new DateTime(1980, 1, 2),
                FavoriteSport = Sport.Tennis,
                Gender = Gender.Female
            };

            Console.WriteLine($"Lisa is {lisa.Gender.ToString().ToLower()}");
            Console.WriteLine($"Lisa likes to play {lisa.FavoriteSport.ToString().ToLower()}");

            if (lisa.FavoriteSport == Sport.Rugby)
            {
                Console.WriteLine($"Lisa likes to play rugby");
            } else
            {
                Console.WriteLine($"Lisa don't like to play rugby");
            }
            Console.WriteLine();

            Console.WriteLine("Here is a list of all Sport enums:");
            foreach (string sportName in Enum.GetNames(typeof(Sport)))
            {
                Console.WriteLine($"* {sportName}");
            }

            Console.WriteLine();
            Console.Write("Enter a sport: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string maybeSport = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (Enum.TryParse(maybeSport, true, out Sport sport))
            {
                Console.WriteLine($"Oh, I know {sport}!");
            } else
            {
                Console.WriteLine($"I don't know the sport {maybeSport}");
            }
        }
    }
}



//Enum.GetNames ger string-array
//Enum.GetValues ger enum-array

//foreach (object x in Enum.GetValues(typeof(Sport)))
//{
//}

//foreach (string x in Enum.GetNames(typeof(Sport)))
//{
//}