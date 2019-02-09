using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace M11_Linq.DemoLinq
{

    public class Demo1
    {
        public void Run()
        {
            // Uppgift: se slutresultatet. Klura i 5-10min hur programmet ska lösas.

            List<Show> allShows = GetShowsFromTextFile();

            DisplayInfoAboutShows(allShows);

            Console.ReadKey();
        }

        private void ExtraStuff(List<Show> allShows)
        {
            // ----- Extra ------------- (ej viktigt)

            // Test med en ny metod

            Header("användning av en ny metod 'WriteShows'");

            WriteShows(allShows.Where(x => x.Channel == "SVT1").OrderBy(x => x.StartAt));


            // ----- Extra ------------- (ej viktigt)

            Header("sortera en lista");

            allShows.Sort((a, b) => String.CompareOrdinal(a.Title, b.Title));

            WriteShows(allShows);
        }

        private void DisplayInfoAboutShows(List<Show> allShows)
        {

            // Alla programtitlar

            Header("alla titlar");

            foreach (Show show in allShows)
            {
                Console.WriteLine(show.Title);
            }



            // Alla program som börjar senare än 21.00 (på två sätt)

            Header("program som börjar senare än kl 21");

            var laterThan21 = new List<Show>();

            foreach (Show show in allShows)
            {
                if (show.StartAt.Hours >= 21)
                {
                    laterThan21.Add(show);
                }
            }

            foreach (Show show in laterThan21)
            {
                WriteInfoAboutShow(show);
            }

            // Alla program som börjar senare än 21.00 (på två sätt) - med Linq

            Header("program som börjar senare än kl 21 - med Linq");

            foreach (Show show in allShows.Where(show => show.StartAt.Hours >= 21))
            {
                WriteInfoAboutShow(show);
            }

            // Program från SVT2 i kronologisk ordning

            Header("program från svt2 i kronologisk ordning");

            foreach (Show show in allShows.Where(x => x.Channel == "SVT2").OrderBy(x => x.StartAt))
            {
                WriteInfoAboutShow(show);
            }


            Header("Finns programmet 'Kulturnyheterna'?");

            //if (allShows.Where(x=>x.Title=="Kulturnyheterna").Count()>0) // Alternativ: 
            if (allShows.Any(x=>x.Title=="Kulturnyheterna"))
                Console.WriteLine("Ja");
            else
                Console.WriteLine("Nej");

            Header("Finns programmet 'Ensam pappa söker'?");

            if (allShows.Any(x => x.Title == "Ensam pappa söker"))
                Console.WriteLine("Ja");
            else
                Console.WriteLine("Nej");

            Header("Alla program som börjar kl 20.00");

            foreach (Show show in allShows.Where(x => x.StartAt.TotalHours == 20))
            //foreach (Show show in allShows.Where(x => x.StartAt == new TimeSpan(20,0,0)))
            {
                WriteInfoAboutShow(show);
            }

            Header("Alla programnamn med stora bokstäver");

            foreach (string loudTitle in allShows.Select(x=>x.Title.ToUpper()))
            {
                Console.WriteLine(loudTitle);
            }

            // Alla kanaler
            Header("alla kanaler");
           
            foreach (string show in allShows.Select(x=>x.Channel).Distinct()) 
            {
                Console.WriteLine(show);
            }
        }

        private List<Show> GetShowsFromTextFile()
        {

            // 1. Läs in textfilen

            string[] allLines = File.ReadAllLines("DemoLinq\\tv-data.txt");

            // 2. Skapa en lista av "Show"

            var allShows = new List<Show>();

            foreach (string line in allLines)
            {
                /*
                   "line" kan t.ex se ut såhär:
                   SVT1*22:00*Fatta Sveriges demokrati
                */
                string[] splittedLine = line.Split('*');
 
                var show = new Show
                {
                    Title = splittedLine[2],
                    Channel = splittedLine[0],
                    StartAt = TimeSpan.Parse(splittedLine[1])
                };

                allShows.Add(show);
            }
            return allShows;
        }

        private void WriteShows(IEnumerable<Show> shows)
        {
            foreach (var show in shows)
            {
                WriteInfoAboutShow(show);
            }
        }

        private void Header(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + text.ToUpper() + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void WriteInfoAboutShow(Show show)
        {
            Console.WriteLine(show.Channel.PadRight(4) + " " + show.StartAt + " " + show.Title);
        }

    }
}
