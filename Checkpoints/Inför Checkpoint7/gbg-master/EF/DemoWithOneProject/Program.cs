
using System;

namespace DemoWithOneProject
{
    class Program
    {
        static void Main()
        {
            FruitContext context = new FruitContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated(); // Använder inte migrationer för att uppdatera databasen. Kan inte senare uppdatera databasen mha migrationer

            //// Här görs en INSERT
            context.Fruits.Add(new Fruit { Name = "Äpple", Color="Rött" });
            context.SaveChanges();

            //// Här görs en SELECT
            foreach (Fruit x in context.Fruits)
            {
                Console.WriteLine(x.Id + "  " + x.Name + "  " + x.Color);
            }

            Console.ReadKey();
        }
    }
}
