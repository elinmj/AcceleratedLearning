using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkpoint0._2Elin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = new List<string>();

            string listInput = "";
            
            int x = 0;

            Console.WriteLine();
            Console.WriteLine("Skriv in produkter. Avsluta med att skriva 'exit'");
            Console.WriteLine();

            while (!listInput.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Ange produkt: ");
                listInput = Console.ReadLine().Trim();

                if (listInput == string.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du får inte ange ett tomt värde");
                }
                else
                {
                products.Add(listInput);
                x++;
                }
            }

            products.RemoveAt(products.Count - 1);

            var sortedList = products.OrderBy(y=>y).ToList();

            Console.WriteLine();
            Console.WriteLine("Du angav följande produkter (sorterade):");
            Console.WriteLine();

            for (int i = 0; i < x-1; i++)
            {
                Console.WriteLine("* " + sortedList[i]);
            }

            Console.WriteLine();
        }
    }
}
