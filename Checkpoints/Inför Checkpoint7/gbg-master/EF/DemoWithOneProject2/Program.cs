
using System;
using System.Collections.Generic;

namespace DemoWithOneProject2
{
    class Program
    {
        static readonly DataAccess _dataAccess = new DataAccess();

        static void Main()
        {
            ClearAndInitDatabase();
            //ClearAndInitDatabase_ChangeTracker();
            //DisplayChangeTracker();
            DisplayAllFruits();
            DisplayJustSkenfrukter();
            Console.ReadKey();
        }

        private static void DisplayChangeTracker()
        {
            Console.WriteLine();
            Console.WriteLine("CHANGE TRACKER");
            Console.WriteLine();
            foreach (var log in _dataAccess.ChangeTrackerLog)
            {
                Console.WriteLine(log);
            }
        }

        private static void DisplayJustSkenfrukter()
        {
            List<Fruit> fruits = _dataAccess.GetFruitsInCategory("Skenfrukt");
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
            foreach (Fruit x in _dataAccess.GetAll()) // Include
            {
                Console.WriteLine(x.Id.ToString().PadRight(5) + x.Name.PadRight(10) +
                                  x.Price?.ToString().PadLeft(10) + "   " + x.Category.Name);
            };
        }

        private static void ClearAndInitDatabase()
        {
            _dataAccess.ClearDatabase();
            _dataAccess.AddCategoriesAndFruits();
        }

        private static void ClearAndInitDatabase_ChangeTracker()
        {
            _dataAccess.ClearDatabase();
            _dataAccess.AddCategoriesAndFruits_ChangeTracker();
        }
    }
}


 
