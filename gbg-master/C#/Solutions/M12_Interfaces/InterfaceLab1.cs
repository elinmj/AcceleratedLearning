using System;
using System.Collections.Generic;

namespace M12_Interfaces
{
    public class InterfaceLab1
    {

        public void Run()
        {
            string[] rockstarsArray = { "Jim Morrison", "Ozzy Osborne",  "David Bowie", "Freddie Mercury"};
            List<string> rockstarsList = new List<string> { "Jim Morrison", "Ozzy Osborne", "David Bowie", "Freddie Mercury" };

            DisplayArrayOfRockStars("My rockstars: (array)", rockstarsArray);
            DisplayListOfRockStars("My rockstars: (list)", rockstarsList);

            DisplayRockStars("My rockstars: (ienumerable)", rockstarsArray);
            DisplayRockStars("My rockstars: (ienumerable)", rockstarsList);

        }

        private void DisplayArrayOfRockStars(string header, string[] rockstars)
        {

            WriteWhite(header);
            foreach (string rockstar in rockstars)
            {
                WriteDark($"* {rockstar}");
            }
            Console.WriteLine();
        }

        private void DisplayListOfRockStars(string header, List<string> rockstars)
        {

            WriteWhite(header);
            foreach (string rockstar in rockstars)
            {
                WriteDark($"* {rockstar}");
            }
            Console.WriteLine();
        }

        private void DisplayRockStars(string header, IEnumerable<string> rockstars)
        {

            WriteWhite(header);
            foreach (string rockstar in rockstars)
            {
                WriteDark($"* {rockstar}");
            }
            Console.WriteLine();
        }

        public void WriteWhite(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }

        public void WriteDark(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
        }
    }
}
