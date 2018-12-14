using System;
using System.Collections.Generic;

namespace Checkpoint3
{
    class Program
    {
        static void Main(string[] args)
        {
            Level1();
        }

        private static void Level1()
        {
            List<int> list = new List<int> { 2, 8, 3, 11 };
            List<int> newList = MultiplyBy100AndAdd3(list);
            DisplayResults(list, newList);
        }

        private static List<int> MultiplyBy100AndAdd3(List<int> list)
        {
            List<int> newList = new List<int>();

            foreach (int number in list)
            {
                int newNumber = (number * 100) + 3;
                newList.Add(newNumber);
            }

            return newList;
        }

        private static void DisplayResults(List<int> list, List<int> newList)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LISTAN");
            Console.ResetColor();
            Console.WriteLine(String.Join(',', list));

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("MULTIPLICERA MED 100 OCH LÄGG TILL TRE");
            Console.ResetColor();
            Console.WriteLine(String.Join(',', newList));

            Console.WriteLine();

        }
    }
}
