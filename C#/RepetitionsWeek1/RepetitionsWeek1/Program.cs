using System;

namespace RepetitionsWeek1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TvåEtt();
            TvåTre();

        }

        private static void TvåTre()
        {
            Console.Write("Enter fruit 1: ");
            string fruit1 = Console.ReadLine();

            Console.Write("Enter fruit 2: ");
            string fruit2 = Console.ReadLine();

            Console.Write("Enter fruit 2: ");
            string fruit3 = Console.ReadLine();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("You entered three fruits: " + fruit1 + "," + fruit2 + "," + fruit3);
            Console.WriteLine(String.Format("You entered three fruits: fruit1, fruit2, fruit3");
            Console.WriteLine($"You entered three fruits: {fruit1}, {fruit2}, {fruit3}");
        }

        private static void TvåEtt()
        {
            //Random random = new Random();

            Console.Write("What is your name? ");
            string name = Console.ReadLine();

            Console.Write("How old are you? ");
            int age = int.Parse(Console.ReadLine());
            int retierment = 65;
            int untilRetirement = retierment - age;

            Console.Write("What is your favorite letter? ");
            char letter = char.Parse(Console.ReadLine());

            //Console.Write("Where do you live? ");
            //string homeTown = Console.ReadLine();
            //Console.Write("What is your favorite color? ");
            //string color = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Thank you!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Your name is: {name}");
            Console.WriteLine($"You have {untilRetirement} years until retirement");

            if (char.IsNumber(letter))
            {
                Console.WriteLine($"You like numbers");
            }
            else
            {
            Console.WriteLine($"You don't like numbers");
            }

            //Console.WriteLine($"You are {age} years old");
            //Console.WriteLine($"Your favorite letter is: {letter}");
            //Console.WriteLine($"You live in {homeTown}");
            //Console.WriteLine($"Your favorite color is: {color}");


            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
