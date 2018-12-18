using System;

namespace OneToOne
{
    class Program
    {
        enum Language
        {
            English,
            Swedish
        }

        static void Main(string[] args)
        {
            Language language = AskForLanguage();
            bool upperCase = AskForUppercaseOrNot(language);
            int a = AskForNumber(1, language, upperCase);
            int b = AskForNumber(2, language, upperCase);
            int sum = a + b;
            DisplaySum(sum, language, upperCase);
        }

        private static bool AskForUppercaseOrNot(Language language)
        {
            string upperCase;

            do
            {
                Console.Write("Uppercase letters (y/n): ");
                upperCase = Console.ReadLine().ToLower();

            } while (upperCase != "y" && upperCase != "n");


            if (upperCase == "y")
            {
                return true; 
            }
            else
            {
                return false;

            }
        }

        private static Language AskForLanguage()
        {
            string language;


            do
            {
                Console.Write("(S)wedish or (E)nglish? ");
                language = Console.ReadLine().ToUpper();

            } while (language != "E" && language != "S" );

            if (language == "E")
            {
                return Language.English;
            }
            else
            {
                return Language.Swedish;
            }

           
            
        }

        private static int AskForNumber(int a, Language s, bool b)
        {
            string language;

            if (s == Language.English)
            {
                language = $"Enter number {a}: ";
            }
            else
            {
                language = $"Nummer {a}: ";

            }

            int z;
            bool x = true;

            do
            {
                if (b == true)
                {
                    Console.Write($"{language.ToUpper()}");
                }
                else
                {
                    Console.Write($"{language}");

                }
                x = int.TryParse(Console.ReadLine(), out z);

                if (x == false)
                {
                    Console.WriteLine("Invalid input!");
                }

            } while (x == false);

            return z;
            
        }

        private static void DisplaySum(int sum, Language s, bool b)
        {
            if (s == Language.English)
            {
                Console.WriteLine($"Sum: {sum}");

            }
            else
            {
                Console.WriteLine($"Summa: {sum}");

            }
        }


    }
}
