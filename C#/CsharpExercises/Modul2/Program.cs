using System;
using System.Collections.Generic;
using System.Data;

namespace Modul2
{
    class Program
    {

        static void Main(string[] args)
        {

            //WhatsYourName();
            //WhatsYourNameTypes();
            //DifferentStringTypes();
            //WhenDidYouGoToBed();
            //RepeatName();
            //RepeatNameFor();
            //NameList();
            //NameListZelda();
            //EqualTo20();
            //EqualTo20Conditional();
        }


        private static void WhatsYourName()
        {


            Console.Write("What is your name? ");
            string name = Console.ReadLine();

            Console.Write("How old are you? ");
            string age = Console.ReadLine();

            Console.Write("What is  your favorite letter? ");
            string favoriteLetter = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Thank you!");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Your name is: {name}");
            Console.WriteLine($"You are {age} years old");
            Console.WriteLine($"Your favourite letter is {favoriteLetter}");

            Console.ForegroundColor = ConsoleColor.White;

        }

        private static void WhatsYourNameTypes()
        {

            Console.Write("What is your name? ");
            string name = Console.ReadLine();

            Console.Write("How old are you? ");
            string age = Console.ReadLine();
            int userAge = Convert.ToInt32(age);
            int retirementAge = 65;
            int untilRetirement = retirementAge - userAge;

            Console.Write("What is your favorite character? ");
            string favoriteCharacter = Console.ReadLine();
            char inputCharacter = Convert.ToChar(favoriteCharacter);

            Console.WriteLine();
            Console.WriteLine("Thank you!");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Your name is: {name}");
            Console.WriteLine($"You have {untilRetirement} years until retierment");

            if (Char.IsNumber(inputCharacter))
            {
                Console.WriteLine("You like numbers");
            }
            else
            {
                Console.WriteLine("You don't like numbers");
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        private static void DifferentStringTypes()
        {

            List<String> list = new List<String>();

            Console.Write("How many fruits do you want to add?: ");
            var numberFruits = Console.ReadLine();
            int fruits = Convert.ToInt32(numberFruits);

            for (int i = 1; i <= fruits; i++)
            {
                Console.Write($"Enter fruit {i}: ");
                Console.ReadLine();
                list.Add(numberFruits);
            }

            Console.WriteLine($"You entered {fruits} fruits: " );
       

            //Console.Write("Enter fruit 1: ");
            //string fruitOne = Console.ReadLine();

            //Console.Write("Enter fruit 2: ");
            //string fruitTwo = Console.ReadLine();

            //Console.Write("Enter fruit 3: ");
            //string fruitThree = Console.ReadLine();

            //string allFruits = String.Format("You entered three fruits: {0}, {1}, {2}", fruitOne, fruitTwo, fruitThree);

            //Console.WriteLine();
            //Console.WriteLine("You entered three fruits: " + fruitOne + "," + fruitTwo + "," + fruitThree + "!");
            //Console.WriteLine(allFruits);
            //Console.WriteLine($"You enterd three fruits: {fruitOne}, {fruitTwo}, {fruitThree}!");
        }

        private static void WhenDidYouGoToBed()
        {

            Console.Write("When did you go to bed yesterday? ");
            var bedTime = Console.ReadLine();
            int inputBed = Convert.ToInt32(bedTime);
            int sleepBefore24 = 24 - inputBed;
            

            Console.Write("When did you wake up? ");
            var wakeupTime = Console.ReadLine();
            int inputWakeup = Convert.ToInt32(wakeupTime);


            int sleep = sleepBefore24 + inputWakeup;
            int enoughSleep = 8;
            int muchSleep = 10;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;


            if (sleep >= muchSleep)
            {
                Console.WriteLine($"You slept {sleep} hours. That's alot!");
            }
            else
            {
                if (sleep >= enoughSleep)
                {
                Console.WriteLine($"You slept {sleep} hours. Great!");
                }
                else
                {
                Console.WriteLine($"You only slept {sleep} hours. Back to bed!");
                }
            }

            Console.ResetColor();
            Console.WriteLine();

        }

        private static void RepeatName()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            if (name.Length < 2 || name.Length > 15)
            {
                Console.Write("Your name need to be between 2 and 15 characters long. Please, enter another name: ");
                name = Console.ReadLine();
            } 
            
            Console.Write("Times to repeat: ");
            var inputRepeat = Console.ReadLine();
            int repeat = Convert.ToInt32(inputRepeat);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;


            //while (repeat >= 1)
            //{
            //    Console.WriteLine($"Your name is {name}");
            //    repeat--;
            //}

            while (true)
            {
                Console.WriteLine($"Your name is {name}");
                repeat--;

                if (repeat<1)
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        private static void RepeatNameFor()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            //Console.Write("Times to repeat: ");
            //var inputRepeat = Console.ReadLine();
            //int repeat = Convert.ToInt32(inputRepeat);

            Console.Write("Enter number of columns: ");
            int inputColumns = int.Parse(Console.ReadLine());

            Console.Write("Enter number of rows: ");
            int inputRows = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < inputRows; i++)
            {
                for (int j = 1; j < inputColumns; j++)
                {
                    Console.Write($"{name}\t");
                }
                Console.WriteLine(name);
            }

            //for (int i = 0; i < repeat; i++)
            //{
            //    Console.WriteLine($"Your name is {name}");
            //}

            Console.WriteLine();
            Console.ResetColor();
        }

        private static void NameList()
        {

            Console.WriteLine("Enter names in a list (like Maria,Peter,Lisa): ");
            string inputNames = Console.ReadLine();
            string[] nameList = inputNames.Split(',');
            

            foreach (var inputName in nameList)
            {
                Console.WriteLine($"{inputName} Andersson");
            }

        }

        private static void NameListZelda()
        {
            Console.WriteLine("Enter names in a list (like Maria,Peter,Lisa): ");
            string inputNames = Console.ReadLine();
            string[] nameList = inputNames.Split(',');

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var value in nameList)
            {
                if (value == "AllowZelda")
                {
                    Console.WriteLine($"{value} Andersson"); 
                    
                }
                else
                {
                    if (value != "Zelda")
                    {
                        Console.WriteLine($"{value} Andersson");
                    }
                    else
                    {
                        Console.WriteLine("Zelda Andersson");
                        break;
                    }

                }
                
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        private static void EqualTo20()
        {
            //Console.WriteLine("Enter a number: ");
            //var inputNumber = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter a number to compare with: ");
            //var inputCompare = int.Parse(Console.ReadLine());



            //Console.WriteLine();
            //Console.ForegroundColor = ConsoleColor.Green;

            //if (inputNumber < inputCompare)
            //{
            //    Console.WriteLine($"Lower than {inputCompare}");
            //}
            //else
            //{
            //    if (inputNumber > inputCompare)
            //    {
            //        Console.WriteLine($"Higher than {inputCompare}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Equal to {inputCompare}");
            //    }
            //}

            Console.WriteLine("Enter gender: ");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            if (age > 65)
            {
                Console.WriteLine($"You are an old {gender}");
            }
            else
            {
                if (age < 30)
                {
                    Console.WriteLine($"You are still a young {gender}!");
                }
                else
                {
                    Console.WriteLine($"You are a middle aged {gender}!");
                }
            }

            Console.WriteLine();

            Random random = new Random();
            int number = random.Next(1, 100);
            int inputGuess;
            
            do
            {
                Console.WriteLine("Enter a guess: ");
                inputGuess = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;

                if (inputGuess < number)
                {
                    Console.WriteLine("Too low!");
                }
                else
                {
                    if (inputGuess > number)
                    {
                        Console.WriteLine("Too high!");
                    }
                    else
                    {
                        Console.WriteLine($"Yes! You guessed {number}");
                        break;
                    }
                }

                Console.WriteLine();
                Console.ResetColor();

            } while (inputGuess != number);


            Console.WriteLine();
            Console.ResetColor();
        }

        private static void EqualTo20Conditional()
        {
            Console.Write("Enter a number: ");
            int inputNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter a number to compare with: ");
            int inputCompare = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            string message = inputNumber > inputCompare ? "Higher than " : (inputNumber == inputCompare ? "Equal to " : "Lower than ");
            Console.WriteLine(message + inputCompare);

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
