// Syfte: ett exception kan skickas djupt nere i programkoden och "bubbla" upp till en högre nivå där det fångas
using System;

namespace M8_Exception.DemoException
{
    public class Demo2
    {
        public void Run()
        {
            Console.Write("Ange höjd: ");
            double height = double.Parse(Console.ReadLine());

            Console.Write("Ange bredd: ");
            double width = double.Parse(Console.ReadLine());

            try
            {
                double result = TriangleArea(height, width);

                Console.WriteLine("Arean av triangeln är " + result);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private double TriangleArea(double height, double width)
        {
            if (width <0 && height <0)
                throw new ArgumentException("Både höjden och bredden är negativ!");

            if (height<0)
                throw new ArgumentException("Höjden får inte vara negativ!");

            if (width < 0)
                throw new ArgumentException("Bredden får inte vara negativ!");

            return height * width / 2;
        }
    }
}
