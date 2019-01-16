using System;

namespace M2_Fundamentals
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitConsole();
            
            // 2.1 Respond to user input
            WhatsYourName(); 

            //// 2.2 Working with diffent types
            //WhatsYourName_WithTypes();

            //// 2.3 String creation
            //FormatStringsInDiffentWays();

            //EndProgram();
        }

        // String formatting in different ways

        private static void FormatStringsInDiffentWays()
        {
            Console.Write("Enter fruit 1: ");
            string fruit1 = Console.ReadLine();

            Console.Write("Enter fruit 2: ");
            string fruit2 = Console.ReadLine();

            Console.Write("Enter fruit 3: ");
            string fruit3 = Console.ReadLine();

            string message1 = "You entered three fruits: " + fruit1 + ", " + fruit2 + ", " + fruit3 + "!";          // concatenation
            string message2 = string.Format("You entered three fruits: {0}, {1}, {2}!", fruit1, fruit2, fruit3);    // placeholders
            string message3 = $"You entered three fruits: {fruit1}, {fruit2}, {fruit3}!";                           // interpolated

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message1);
            Console.WriteLine(message2);
            Console.WriteLine(message3);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        // Get input from console and respond

        private static void WhatsYourName()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();

            Console.Write("How old are you? ");
            string age = Console.ReadLine();

            Console.Write("What is your favorite letter? ");
            string letter = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Thank you!");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Your name is: " + name);
            Console.WriteLine("You are " + age + " years old");
            Console.WriteLine("Your favorite letter is " + letter);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }




        // Parsing values to different types

        private static void WhatsYourName_WithTypes()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();

            Console.Write("How old are you? ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("What is your favorite character? ");
            char character = char.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Thank you!");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;

            int untilRetirement = 65 - age;
            bool userLikesNumbers = char.IsNumber(character);

            Console.WriteLine("Your name is: " + name);
            Console.WriteLine("You have " + untilRetirement + " years until retirement");

            if (userLikesNumbers)
                Console.WriteLine("Your like numbers");
            else
                Console.WriteLine("Your don't like numbers");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static void InitConsole()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WindowWidth = 50;
            Console.WindowHeight = 15;

            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }

        public static void EndProgram()
        {
            Console.ReadKey();
        }
    }
}
