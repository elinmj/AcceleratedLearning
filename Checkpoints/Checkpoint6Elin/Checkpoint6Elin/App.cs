using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint6Elin
{
    class App
    {
        internal void Run()
        {
            RecreateDatabase();

            AddSpaceship("USS Enterprise");
            AddSpaceship("Millennium Falcon");
            AddSpaceship("Cylon Raider");

            AddRavioliForSpaceship("Cylon Raider", 1, "2018-04-19");
            AddRavioliForSpaceship("Millennium Falcon", 1, "2017-01-01");
            AddRavioliForSpaceship("Millennium Falcon", 2, "2018-01-01");
            AddRavioliForSpaceship("Nalle Puh", 99, "1950-01-01");

            List<Spaceship> list = GetAllSpaceships();
            DisplaySpaceships(list);

        }

        private void AddRavioliForSpaceship(string spaceship, int ravioli, string packdate)
        {
            var dataAccess = new DataAccess();
            dataAccess.AddRavioliForSpaceship(spaceship, ravioli, packdate);
        }

        private void DisplaySpaceships(List<Spaceship> list)
        {
            //Level1
            //foreach (Spaceship spaceship in list)
            //{
            //    Console.WriteLine(spaceship.Name);
            //    Console.WriteLine();
            //}

            //Level2
            foreach (Spaceship spaceship in list)
            {
                Console.WriteLine(spaceship.Name);

                for (int i = 0; i < spaceship.Ravioli; i++)
                {

                    if (spaceship.Ravioli == null) //Här hittade jag inget sätt att kolla om ravioli var null
                    {
                        Console.WriteLine("Slut på ravioli!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green; 
                        // Här hittade jag inget sätt att ta bort tiden från DateTime. Kanske kunde konverterat tillbaka till string?
                        Console.WriteLine($"{"Ravioli", -10} Packdatum: {spaceship.PackDateRavioli, -15} Bästföre: {spaceship.BestBeforeRavioli}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private List<Spaceship> GetAllSpaceships()
        {
            var dataAccess = new DataAccess();
            List<Spaceship> list = dataAccess.GetAllSpaceShips();
            return list;
        }

        private void AddSpaceship(string spaceship)
        {
            var dataAccess = new DataAccess();
            dataAccess.AddSpaceship(spaceship);
        }

        private void RecreateDatabase()
        {
            using (var context = new SpaceContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
