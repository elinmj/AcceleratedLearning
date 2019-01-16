using System;

namespace M4_Methods
{
    public class Exercise4_1_no_methods
    {
        public static void Run()
        {
            // Get list of names from user

            Console.Write("Enter a list of names: ");
            string listOfNames = Console.ReadLine();

            // Create list

            string[] list = listOfNames?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            // Report to user

            if (list == null || list.Length == 0)
            {
                WriteGreen("No people in the list");
            }
            else
            {
                foreach (string person in list)
                {
                    WriteGreen($"***SUPER-{person.ToUpper()}***");
                }
            }
        }

        private static void WriteGreen(object message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}