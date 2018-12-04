using System;

namespace Modul8
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal chocolatePieces = 24M;
            decimal share;

            Console.WriteLine($"The chocolate contains {chocolatePieces} pieces");

            Console.Write("How many want to share? ");

            try
            {
                share = int.Parse(Console.ReadLine());

                if (share < 0)
                {
                    throw new Exception("Must be above zero!");
                }
               

                decimal get = chocolatePieces / share;
                Console.WriteLine($"Everyone gets {get} pieces");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Zero people can't devide a chocolate");
            }
            
            catch (FormatException)
            {
                Console.WriteLine("You have to enter digits");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
