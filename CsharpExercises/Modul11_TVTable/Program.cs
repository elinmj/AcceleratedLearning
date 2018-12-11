using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Modul11_TVTable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Show> allShows = GetShowsFromTextFile();

            DisplayInfoAboutShows(allShows);

            Console.ReadKey();
        }

        private static void DisplayInfoAboutShows(List<Show> allShows)
        {
            AllaTitlar(allShows);
            SenareÄn21(allShows);
            KronologiskOrdning(allShows);
            Finns(allShows);
            Börjar20(allShows);
            StoraBokstäver(allShows);
            AllaKanaler(allShows);
           
        }

        private static void AllaKanaler(List<Show> allShows)
        {
            Console.WriteLine("ALLA KANALER");
            Console.WriteLine();

            foreach (var item in allShows.Select(x => x.Channel).Distinct())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void StoraBokstäver(List<Show> allShows)
        {
            Console.WriteLine("ALLA PROGRAMNAMN MED STORA BOKSTÄVER");
            Console.WriteLine();

            foreach (var item in allShows)
            {
                Console.WriteLine(item.Name.ToUpper());
            }
            Console.WriteLine();
        }

        private static void Börjar20(List<Show> allShows)
        {
            Console.WriteLine("ALLA PROGRAM SOM BÖRJAR KL 20.00");
            Console.WriteLine();

            foreach (Show show in allShows.Where(x => x.Time.TotalHours == 20))
            {

                Console.WriteLine(show.Name);

            }

            Console.WriteLine();
        }

        private static void Finns(List<Show> allShows)
        {
            Console.WriteLine("FINNS PROGRAMMET 'KULTURNYHETERNA' ?");
            Console.WriteLine();

            if (allShows.Any(x => x.Name == "Kulturnyheterna"))
            {
                Console.WriteLine("Ja");
            }
            else
            {
                Console.WriteLine("Nej");
            }

            Console.WriteLine();
            Console.WriteLine("FINNS PROGRAMMET 'ENSAM PAPPA SÖKER' ?");
            Console.WriteLine();

            if (allShows.Any(x => x.Name == "Ensam pappa söker"))
            {
                Console.WriteLine("Ja");
            }
            else
            {
                Console.WriteLine("Nej");
            }

            Console.WriteLine();
        }

        private static void KronologiskOrdning(List<Show> allShows)
        {
            Console.WriteLine();
            Console.WriteLine("PROGRAM FRÅN SVT2 I KRONOLOGISK ORDNING");
            Console.WriteLine();


            foreach (var item in allShows.Where(x => x.Name == "SVT2").OrderBy(x => x.Time))
            {
                Console.WriteLine($"{item.Channel}\t{item.Time}\t{item.Name}");
                //Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        private static void SenareÄn21(List<Show> allShows)
        {
            Console.WriteLine("PROGRAM SOM BÖRJAR SENARE ÄN KL 21");

            Console.WriteLine();

            foreach (var item in allShows)
            {
                if (item.Time.Hours >= 21 )
                {
                    Console.WriteLine($"{item.Channel}\t{item.Time}\t{item.Name}");

                }
            }
        }

        private static void AllaTitlar(List<Show> allShows)
        {
            Console.WriteLine("ALLA TITLAR");

            Console.WriteLine();

            foreach (var item in allShows)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine();
        }

        private static List<Show> GetShowsFromTextFile()
        {
            //string allInfo = "SVT1*21:00*Lill-Babs live från Sunnanå,SVT1*20:00*Det bästa ur Antikrundan,SVT1*20:00*Det bästa ur Antikrundan,SVT1*22:00*Fatta Sveriges demokrati,SVT2*20:00*Skymningsläge-Sverige under kalla kriget,SVT2*20:45*Vänförfrågan väntar,SVT2*21:00*Aktuellt,SVT2*21:39*Kulturnyheterna,TV3*20:00*Ensam mamma söker,TV3 *21:00*NCSI";
            //string[] readLines = allInfo.Split(',');

            string[] readLines = File.ReadAllLines(@"C:\Project\AcceleratedLearning\CsharpExercises\TVTable.txt");

            List<Show> allShows = new List<Show>();
             
            foreach (var show in readLines)
            {
                Show newShow = new Show();
                string[] split2 = show.Split('*');
                newShow.Channel = split2[0];
                newShow.Time = TimeSpan.Parse(split2[1]);
                newShow.Name = split2[2];

                allShows.Add(newShow);
            }

            return allShows;
        }
    }
}
