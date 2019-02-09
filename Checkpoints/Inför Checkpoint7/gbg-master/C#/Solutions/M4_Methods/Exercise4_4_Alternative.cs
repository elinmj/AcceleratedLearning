using System;

namespace M4_Methods
{
    public class Exercise4_4_Alternative
    {
        public static void Run()
        {
            string[] peopleArray;

            char separator = AskUserForSeparator();
            bool wantErrorMessage = AskUserForErrorMessage();

            while (true)
            {
                Console.Write("Enter a list of names: ");
                string response = Console.ReadLine();

                peopleArray = CreateArrayOfPeople(response, separator);
                CleanUpArray(peopleArray);

                var validationResult = Validate(peopleArray);

                if (validationResult == ValidationResult.Ok)
                    break;

                if (validationResult == ValidationResult.ListContainsNoNames && wantErrorMessage)
                    ErrorMessage("The list don't contain any names");
                else if (validationResult == ValidationResult.WrongPersonFormat && wantErrorMessage)
                    ErrorMessage("A person can only have 2 to 9 letters");
            }

            RespondToUser(peopleArray);
        }

        private static char AskUserForSeparator()
        {
            char separator;
            bool parseSuccess;

            do
            {
                Console.Write("Which separator do you want to use (default is comma) ? ");
                string answer = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(answer))
                {
                    answer = ",";
                }
                parseSuccess = char.TryParse(answer, out separator);
            } while (!parseSuccess);

            return separator;
        }

        private static bool AskUserForErrorMessage()
        {
            bool wantErrorMessage = false;
            while (true)
            {
                Console.Write("Do you want to see error messages (default is yes) ? ");
                string answer = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(answer))
                {
                    answer = "yes";
                }
                answer = answer.ToLower();

                if (answer == "yes")
                {
                    wantErrorMessage = true;
                    break;
                }
                if (answer == "no")
                    break;

            }

            return wantErrorMessage;
        }

        private static string[] CreateArrayOfPeople(string response, char separator = ',')
        {
            if (string.IsNullOrWhiteSpace(response))
                return new string[] { };

            string[] list = response.Split(separator);

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

        public static void CleanUpArray(string[] peopleArray)
        {
            for (var i = 0; i < peopleArray.Length; i++)
            {
                peopleArray[i] = peopleArray[i].Trim();
            }
        }

        private static ValidationResult Validate(string[] peopleArray)
        {
            if (peopleArray.Length == 0)
                return ValidationResult.ListContainsNoNames;

            foreach (string person in peopleArray)
            {
                if (person.Length <= 1 || person.Length >= 10)
                    return ValidationResult.WrongPersonFormat;
            }
            return ValidationResult.Ok;
        }

        private enum ValidationResult
        {
            Ok, ListContainsNoNames, WrongPersonFormat
        }

        private static void WriteGreen(object message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void ErrorMessage(object message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
