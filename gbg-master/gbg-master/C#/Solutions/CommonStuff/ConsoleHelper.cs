using System;
using System.Linq;

namespace CommonStuff
{
    public class ConsoleHelper
    {
        public void InitConsole(int width=60, int height=20)
        {
            SetStandardColor();

            Console.WindowWidth = width;
            Console.WindowHeight = height;

            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }

        public void SetStandardColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            SetStandardColor();
        }

        public void EndProgram()
        {
            Console.WriteLine();
            SetStandardColor();
            Console.ReadKey();
        }

        public void Line()
        {
            Console.WriteLine("---------------------------------------");
        }

        public void WriteDark(object message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
            SetStandardColor();
        }

        public void WriteGreen(object message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            SetStandardColor();
        }

        public void TwoColumns(string col1, string col2, int firstColumnSize=20)
        {
            Console.WriteLine($"{col1.PadRight(firstColumnSize)}{col2}");
        }

        public double AskForNumber(string question)
        {
            double answer;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(question + " ");
                Console.ForegroundColor = ConsoleColor.Green;

            } while (!double.TryParse(Console.ReadLine(), out answer));

            SetStandardColor();

            return answer;
        }

        public int AskForWholeNumber(string question)
        {
            int answer;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(question + " ");
                Console.ForegroundColor = ConsoleColor.Green;

            } while (!int.TryParse(Console.ReadLine(), out answer));

            SetStandardColor();

            return answer;
        }
        public string AskForString(string question, string defaultAnswer="")
        {
            Console.Write($"{question} ");
            Console.ForegroundColor = ConsoleColor.Green;
            string answer = Console.ReadLine();
            SetStandardColor();
            if (string.IsNullOrWhiteSpace(answer))
            {
                return defaultAnswer;
            }
            return answer;
        }

        public char AskForKey(string question, char[] validKeys=null)
        {
            while(true)
            {
                SetStandardColor();
                Console.Write($"{question} ");
                Console.ForegroundColor = ConsoleColor.Green;
                char answer = Console.ReadKey().KeyChar;
                answer = CharToUpper(answer);
                SetStandardColor();
                if (validKeys==null || validKeys.Contains(answer))
                {
                    return answer;
                }
            }
        }

        private char CharToUpper(char c)
        {

            if (!char.IsLetter(c))
                return c;

            return c.ToString().ToUpper()[0];
        }
    }
}
