using System;

namespace Modul4
{
    class Program
    {

        static void Main(string[] args)
        {
            bool validList = false;
            string[] nameList;

            char separator = AskUserForSeparator();
            bool errorMassage = AskUserForErrorMessage();
            do
            {
                string inputNames = GetInputFromUser();
                nameList = CreateArrayOfPeople(inputNames, separator);
                CleanUpArray(nameList);
                validList = PeopleArrayIsValid(nameList, errorMassage);
                
                
            } while (validList == false);

                RespondToUser(nameList);
        }

        private static bool AskUserForErrorMessage()
        {
            
            
                Console.Write("Do you want to see error messages (default is yes)? ");
                string inputError = Console.ReadLine();

                if (inputError == "no")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            
        }

        private static char AskUserForSeparator()
        {
            bool sep = false;
            char separator;

            
            do
            {
                Console.Write("Which seperator do you want to use (default is comma): ");
                 separator = char.Parse(Console.ReadLine());

                if (char.IsLetter(separator) != false)
                {
                    Console.WriteLine("Separator has to be a symbol");
                }
                else
                    sep = true;

            } while (sep == false);
           

            return separator;
        }

        private static string GetInputFromUser()
        {
            Console.Write("Enter names by comma (eg. Maria,Peter,Lisa): ");
            string inputNames = Console.ReadLine();
            return inputNames;
        }


        private static string[] CreateArrayOfPeople(string inputNames, char separator)
        {
            string[] nameList = inputNames.Split(separator);
            return nameList;
        }

        private static void CleanUpArray(string[] nameList)
        {
            for (int i = 0; i < nameList.Length; i++)
            {
                nameList[i] = nameList[i].Trim();
            }
        }

        private static bool PeopleArrayIsValid(string[] nameList, bool errorMessage)
        {
            if (nameList.Length == 1 && nameList[0] == "")
            {
                Console.WriteLine("The list don't contain any names");
                return false;
            }
            else if (true)
            {
                foreach (var item in nameList)
                {
                    if (item.Length < 2 || item.Length > 9)
                    {
                        Console.WriteLine("A person can only have 2 to 9 letter");
                        return false;
                    }
                }

            }
            
            {
               return true;
            }
        }

        private static void RespondToUser(string[] names)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var inputName in names)
            {
                string nameUpper = inputName.ToUpper();
                string message = $"***SUPER-{nameUpper}***";
                Console.WriteLine(message);
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        
    }
}
