using System;
using System.Collections.Generic;

namespace Modul10_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> products = BuildProductDictionary();
            DisplayProductDictionary(products);

        }

        private static bool UserWriteOver()
        {
            Console.Write("If you want to keep the first input name, type true, otherwise false: ");
            bool user = bool.Parse(Console.ReadLine());
            return user;
        }

        private static Dictionary<int, string> BuildProductDictionary()
        {
            Dictionary<int, string> products = new Dictionary<int, string>();


            do
            {
                try
                {
                    Console.Write("Enter product id and name: ");
                    string input = Console.ReadLine();
                    string separator = ",";

                    if (input == "")
                    {
                        break;
                    }
                    else if (!input.Contains(separator))
                    {
                        throw new Exception("Must contain two values separated by ','");
                    }

                    string[] sepInput = input.Split(separator);


                    if (sepInput[0] == "" || sepInput[1] == "")
                    {
                        throw new Exception("Invalid input");
                    }

                    
                    if (products.ContainsKey(int.Parse(sepInput[0])))
                    {
                        bool writeOver = UserWriteOver();

                        if (writeOver == true)
                        {
                            throw new Exception($"The productlist already contains the id {sepInput[0]}");    
                        }
                        else
                        {
                            products.Remove(int.Parse(sepInput[0]));
                        }
                    }

                    products.Add(int.Parse(sepInput[0]), sepInput[1].Trim());
                }

                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }

                Console.ResetColor();

            } while (true);

            return products;


        }

        private static void DisplayProductDictionary(Dictionary<int, string> products)
        {
            Console.WriteLine();

            foreach (var item in products)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Product id={item.Key} and name={item.Value}");
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
