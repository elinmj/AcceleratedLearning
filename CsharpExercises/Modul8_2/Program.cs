using System;
using System.IO;

namespace Modul8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            do
            {
                Console.Write("Enter a file name: ");

                try
                {
                    input = Console.ReadLine();
                    File.CreateText(input).Close();
                    
                    Console.WriteLine($"The file {input} is now created");
                    break;
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("You're not authorized to create this file");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Input output exception");
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("The filename is not valid");
                }

            } while (true);

            Console.Write("Enter text to file: ");
            string text = Console.ReadLine();
            File.WriteAllText(input, text);
        }
    }
}
