using M3_Control.DemoLoops.Exercise;
using System;

namespace M3_Control.DemoLoops
{
    public class App
    {
        // Syfte: enkel nästad for-loop

        private static void Nested1()
        {
            for (int a = 1; a <= 3; a++)
            {
                for (int b = 1; b <= 5; b++)
                {
                    Console.WriteLine($"State: a={a} och b={b}");
                }
                Console.WriteLine();
            }
        }


        // Syfte: for-loop som har andra start och slutvärden

        private static void Nested2()
        {
            for (int a = 5; a <= 7; a++)
            {
                for (int b = 100; b <= 102; b++)
                {
                    Console.WriteLine($"State: a={a} och b={b}");
                }

                Console.WriteLine();
            }
        }

        // Syfte: samma som förra fast med "while"
        private static void Nested2_While()
        {
            int a = 5;

            while (a <= 7)
            {
                int b = 100;
                while (b <= 102)
                {
                    Console.WriteLine($"State: a={a} och b={b}");
                    b++;
                }
                a++;
                Console.WriteLine();
            }

        }

        // Syfte: Visa att det går att skicka in parameterar

        private static void Nested3(int maxA, int maxB)
        {
            for (int a = 1; a <= maxA; a++)
            {
                for (int b = 1; b <= maxB; b++)
                {
                    Console.WriteLine($"State: a={a} och b={b}");
                }

                Console.WriteLine();
            }
        }

        // Syfte: ta större kliv i looparna (a och b ökas snabbare)

        private static void Nested4(int maxA, int maxB)
        {
            for (int a = 1; a <= maxA; a = a + 2)
            {
                for (int b = 1; b <= maxB; b = b + 10)
                {
                    Console.WriteLine($"State: a={a} och b={b}");
                }

                Console.WriteLine();
            }
        }


    }
}
