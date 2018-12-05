using System;
using System.Collections.Generic;

namespace Modul10_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //string name;
            //List<string> names = new List<string>();

            //do
            //{
            //    Console.Write("Enter a name: ");
            //    name = Console.ReadLine();
            //    names.Add(name);

            //} while (name.ToLower() != "quit");

            //Console.WriteLine();

            //if (names.Count == 1)
            //{
            //    names.RemoveAt(0);
            //}
            //else if (names.Count == 2)
            //{
            //    names.RemoveAt(names.Count - 1);
            //}
            //else if (names.Count > 2)
            //{
            //    names.RemoveAt(0);
            //    names.RemoveAt(names.Count - 1);
            //    names.RemoveAt(names.Count - 1);
            //}

            //names.Sort();

            //foreach (string item in names)
            //{
            //    Console.WriteLine($"Name: {item}");
            //}      

            int inputNumber;
            List<int> numbers = new List<int>();

            do
            {
                Console.Write("Enter a number: ");
                inputNumber = int.Parse(Console.ReadLine());
                numbers.Add(inputNumber);

            } while (inputNumber != 0);

            numbers.RemoveAt(numbers.Count);

            Console.WriteLine();

            Console.WriteLine("Mean: " + CalculateMean());
            Console.WriteLine("Mean: " + CalculateMedian());

        }

        private static string CalculateMean()
        {
            int total = 0;

            foreach (var item in numbers)
            {
                int summa = item + total;
                total = summa;
            }

            decimal mean = total / numbers.Count;
        }

        private static string CalculateMedian()
        {
            throw new NotImplementedException();
        }

        // Extrauppgiften 1 är inte klar
    }
}
