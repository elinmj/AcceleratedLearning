using System;

namespace M4_Methods
{
    public class Exercise4_1
    {
        public static void Run()
        {
            string response = GetInputFromUser();

            string[] peopleArray = CreateArrayOfPeople(response);

            RespondToUser(peopleArray);
        }

        private static string GetInputFromUser()
        {
            Console.Write("Enter a list of names: ");
            string answer = Console.ReadLine();

            return answer;
        }

        private static string[] CreateArrayOfPeople(string response)
        {
            if (string.IsNullOrWhiteSpace(response))
                return new string[] { };

            string[] list = response.Split(',');

            return list;
        }

        private static void RespondToUser(string[] peopleArray)
        {
            if (peopleArray.Length == 0)
            {
                WriteGreen("No people in the list");
                return;
            }

            foreach (string person in peopleArray)
            {
                WriteGreen($"***SUPER-{person.ToUpper()}***");
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
