using System;
using System.Collections.Generic;

namespace DemoWithOneProject3
{
    class Program
    {
        static void Main()
        {
            ClearAndInitDatabase();
            //DisplayAllFruits();
            //DisplayJustSkenfrukter();
            DisplayBaskets();

            Console.ReadKey();
        }

        private static void DisplayBaskets()
        {
            var dataAccess = new DataAccess();
            IEnumerable<Basket> baskets = dataAccess.GetAllBaskets();
            foreach (var b in baskets)
            {
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("VARUKORG: " + b.Name);
                Console.WriteLine();

                IEnumerable<Fruit> fruits = dataAccess.GetAllFruitsInBasket(b.Id);
                //IEnumerable<Fruit> fruits = dataAccess.GetAllFruitsInBasket_Alternative(b.Id);
                //IEnumerable<Fruit> fruits = dataAccess.GetAllFruitsInBasket_Alternative2(b.Id);
                //IEnumerable<Fruit> fruits = dataAccess.GetAllFruitsInBasket_Alternative3(b.Id);
                foreach (var f in fruits)
                {
                    Console.WriteLine(f.Name);
                }

            }
        }

        private static void DisplayJustSkenfrukter()
        {
            var dataAccess = new DataAccess();
            List<Fruit> fruits = dataAccess.GetFruitsInCategory("Skenfrukt");
            Console.WriteLine();
            Console.WriteLine("SKENFRUKTER");
            Console.WriteLine();
            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit.Name);
            }
        }

        private static void DisplayAllFruits()
        {
            var dataAccess = new DataAccess();
            foreach (Fruit x in dataAccess.GetAll())
            {
                Console.WriteLine(x.Id.ToString().PadRight(5) + x.Name.PadRight(20) +
                                  x.Price.ToString().PadRight(10) + x.Category.Name.PadRight(10));
            };
        }

        private static void ClearAndInitDatabase()
        {
            var dataAccess = new DataAccess();
            dataAccess.ClearDatabase();
            dataAccess.AddCategoriesAndFruits();
            dataAccess.SaveChanges();
        }
    }
}



