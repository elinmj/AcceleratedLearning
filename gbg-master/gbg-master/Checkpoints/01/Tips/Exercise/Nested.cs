using System;

namespace M3_Control.DemoLoops.Exercise
{
    public class Nested
    {
        
        public static void MultiplicationTable(int maxA)
        {
            Console.WriteLine();
            for (int a = 1; a <= maxA; a++)
            {
                Console.WriteLine("┌────────────────────────────┐");
                Console.WriteLine($"│ Multiplication table for {a} │");
                Console.WriteLine("└────────────────────────────┘");

                for (int b = 1; b <= 10; b++)
                {
                    Console.WriteLine($"  {a} * {b} = {a * b}");
                }

                Console.WriteLine();
            }
        }


        public static void DrawSquare(int size, int indent = 0)
        {
            for (int a = 1; a <= size; a++)
            {
                string spaces = new string(' ', indent);
                Console.Write(spaces);
                for (int b = 1; b <= size; b++)
                {
                    Console.Write("●");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
