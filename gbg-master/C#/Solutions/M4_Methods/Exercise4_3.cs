using System;

namespace M4_Methods
{
    public class Exercise4_3
    {
        public static void Run()
        {
            string[] peopleArray;

            while (true)
            {
                string response = GetInputFromUser();
                peopleArray = CreateArrayOfPeople(response);
                CleanUpArray(peopleArray);

                if (PeopleArrayIsValid(peopleArray))
                    break;
            }

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

        private static void CleanUpArray(string[] peopleArray)
        {
            for (var i = 0; i < peopleArray.Length; i++)
            {
                peopleArray[i] = peopleArray[i].Trim();
            }
        }

        private static bool PeopleArrayIsValid(string[] peopleArray)
        {
            if (peopleArray.Length == 0)
            {
                ErrorMessage("The list don't contain any names");

                return false;
            }

            foreach (string person in peopleArray)
            {
                if (person.Length <= 1 || person.Length >= 10)
                {
                    ErrorMessage("A person can only have 2 to 9 letters");

                    return false;
                }
            }
            return true;
        }

        private static void ErrorMessage(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void WriteGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
