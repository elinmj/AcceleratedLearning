using System;

namespace ConsoleService
{
    public class ConsoleHelper
    {
        ConsoleColor defaultColor = ConsoleColor.White;
        int defaultColumn1Width = 25;
        int defaultColumn2Width = 25;

        public void Line(string header = "", string subheader = "", ConsoleColor lineColor = ConsoleColor.DarkGray)
        {
            string line = "---";

            if (!string.IsNullOrWhiteSpace(header))
            {
                line += $" {header}";

                if (subheader == "")
                {
                    line += " ";
                }
            }

            if (!string.IsNullOrWhiteSpace(subheader))
            {
                line += $" --- ({subheader}) ";
            }

            int repeat = Console.WindowWidth - line.Length;

            string lineEnd = new string('-', repeat - 1);

            line += lineEnd;

            Console.ForegroundColor = lineColor;
            Console.WriteLine(line);

            SetDefaultColor();
        }

        private void SetDefaultColor()
        {
            Console.ForegroundColor = defaultColor;
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Green(object text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            SetDefaultColor();
        }

        public void Red(object text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            SetDefaultColor();
        }

        public void Green(object text1, object text2)
        {
            text1 = text1 ?? "";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text1.ToString().PadRight(defaultColumn1Width));
            Console.WriteLine(text2);
            SetDefaultColor();
        }


        public void Green(object text1, object text2, object text3)
        {
            text1 = text1 ?? "";
            text2 = text2 ?? "";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text1.ToString().PadRight(defaultColumn1Width));
            Console.Write(text2.ToString().PadRight(defaultColumn2Width));
            Console.WriteLine(text3);
            SetDefaultColor();
        }

        public void Init()
        {
            Console.SetWindowSize(80, 20);
        }
    }
}
