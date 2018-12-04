using System;

namespace Modul8_3
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                string[] animalList = AskForAnimals();
                ParseAnimals(animalList);
            } while (true);


            
        }

        private static string[] AskForAnimals()
        {
            Console.Write("Enter list of animals: ");
            string input = Console.ReadLine();
            string[] listAnimals = input.Split(',');
            return listAnimals;
        }

        private static void ParseAnimals(string[] animalList)
        {

                try
                {

                    foreach (string animal in animalList)
                    {
                        if (animal.Length > 10)
                        {
                            throw new FormatException($"Animal: {animal} has too many letters!");
                        }
                        else if (animal.Length <= 0)
                        {
                                throw new FormatException($"Animals must contain letters!");

                        }

                        foreach (char item in animal)
                            {
                                if (char.IsNumber(item))
                                {
                                    throw new FormatException($"Animal: {animal} contains numbers!");
                                }
                                else if (char.IsWhiteSpace(item))
                                {
                                    throw new FormatException($"Animals can't contain white space!!");
                                }
                                else if (char.IsSymbol(item))
                                {
                                    throw new FormatException($"Animal: {animal} contains invalid letters!");
                                }
                            }


                    }

                    Console.WriteLine($"There are {animalList.Length} animals in the list");
                    // TODO: Få den att sluta loopa där uppe. Alltså sluta vid denna Console.WriteLine
                }

                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            
        }

    }
}
