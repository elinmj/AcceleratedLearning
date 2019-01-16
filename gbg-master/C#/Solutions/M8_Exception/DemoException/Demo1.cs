// Syfte: visa hur man kan fånga olika typer av exceptions
using System;

namespace M8_Exception.DemoException
{
    public class Demo1
    {
        public void Run()
        {
            Console.Write("Ange en siffra: ");

            try
            {
                int number = int.Parse(Console.ReadLine());

                int squared = number * number;
                Console.WriteLine("Talet kvadrerat är: " + squared);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Något är galet med formatet");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Något gick knas");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

            }

        }
    }
}
