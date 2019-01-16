using System;
using System.Collections.Generic;
using System.Linq;

namespace M11_Linq.DemoLinq
{
    public class Demo2
    {
        public void Run()
        {
            var list = new List<int> { 3, 10, 7 };

            Header("Listan:");
            Console.WriteLine($"list = {string.Join(",", list)}");

            Header("Utan linq:");

            double avg = Average(list);
            double sum = Sum(list);

            List<int> numberHigherThanFive = NumberHigherThanFive(list);
            List<string> starslist = StarifyList(list);

            Console.WriteLine($"average = {avg}");
            Console.WriteLine($"sum = {sum}");
            Console.WriteLine($"numberHigherThanFive = {string.Join(",", numberHigherThanFive)}");
            Console.WriteLine($"starslist = {string.Join(",", starslist)}");

            Header("Med linq:");

            List<int> numberHigherThanFiveLinq = list.Where(x => x > 5).ToList();
            List<string> starslistLinq = list.Select(x => "*" + x + "*").ToList();

            Console.WriteLine($"average = {list.Average()}");
            Console.WriteLine($"sum = {list.Sum()}");
            Console.WriteLine($"numberHigherThanFive = {string.Join(",", numberHigherThanFiveLinq)}");
            Console.WriteLine($"starslist = {string.Join(",", starslistLinq)}");

            Console.WriteLine();
            Console.ReadKey();
        }

        private List<int> NumberHigherThanFive(List<int> list)
        {
            var result = new List<int>();
            foreach (var i in list)
            {
                if (i > 5)
                    result.Add(i);
            }
            return result;
        }

        private double Average(List<int> list)
        {
            double sum = 0;
            int numbersInList = 0;
            foreach (var i in list)
            {
                sum += i;
                numbersInList++;
            }
            return sum / numbersInList; 
        }

        private double Average_Shorter(List<int> list)
        {
            double sum = 0;
            foreach (int i in list)
            {
                sum += i;
            }
            return sum / list.Count;
        }

        private double Average_Alternative(List<int> list)
        {
            return Sum(list) / list.Count;
        }

        private double Sum(List<int> list)
        {
            double sum = 0;
            foreach (int i in list)
            {
                sum += i;
            }
            return sum;
        }

        private List<string> StarifyList(List<int> list)
        {
            var result = new List<string>();
            foreach (int i in list)
            {
                result.Add($"*{i}*");
            }
            return result;
        }

        private void Header(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + text.ToUpper() + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
