using CommonStuff;
using System;

namespace M8_Exception
{
    public class ExceptionChocolate
    {
        public void Run()
        {
            ChocolateTest1();
            ChocolateTest2();
        }

        private void ChocolateTest1()
        {
            ConsoleHelper ch = new ConsoleHelper();
            Console.WriteLine("The chocolate contains 24 pieces");
            int people = ch.AskForWholeNumber("How many want to share?");
            decimal piecePerPerson =  24M / people; // Has to have M to avoid int division

            // Alternative: 
            // decimal piecePerPerson = decimal.Divide(24, people);

            // Doesn't work, gives Infinity as answer (not exception):
            //double piecePerPerson = 24.0 / people; // Has to have .0 to avoid int division

            Console.WriteLine($"Everyone get {piecePerPerson:.##} pieces");
        }

        private void ChocolateTest2()
        {
            ConsoleHelper ch = new ConsoleHelper();
            Console.WriteLine("The chocolate contains 10 pieces");
            int people = ch.AskForWholeNumber("How many want to share?");

            try
            {
                decimal piecePerPerson = 10M / people;
                Console.WriteLine($"Everyone get {piecePerPerson:.##} pieces");
            }
            catch (DivideByZeroException ex)
            {
                ch.ErrorMessage("Zero people can't divide a chocolate");
            }
            catch (Exception ex)
            {
                ch.ErrorMessage("Something strange happened!");
            }

        }
    }
}
