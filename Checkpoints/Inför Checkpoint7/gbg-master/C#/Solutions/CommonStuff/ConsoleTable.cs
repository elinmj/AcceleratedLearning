using System;
using System.Collections.Generic;

namespace CommonStuff
{
    public class ConsoleTable
    {
        public List<ConsoleColumn> Columns { get; set; }

        private ConsoleTable()
        {

        }

        public static ConsoleTable Create(int columns, ConsoleColor color=ConsoleColor.White, int columnWidth=30)
        {
            var ct = new ConsoleTable();
            ct.Columns = new List<ConsoleColumn>();
            for (int i=0; i<columns; i++)
            {
                ct.Columns.Add(new ConsoleColumn {
                    Color = color,
                    Width = columnWidth
                });
            }
            return ct;
        }

        public void Write(params object[] columnText)
        {
            if (columnText == null)
            {
                throw new ArgumentNullException("columnText");
            }
            if (columnText.Length != Columns.Count)
            {
                throw new ArgumentException($"columnText.Length:{columnText.Length} Columns.Count:{Columns.Count}");
            }

            int columnIndex = 0;

            var previousColor = Console.ForegroundColor;

            foreach (object text in columnText)
            {
                Console.ForegroundColor = Columns[columnIndex].Color;
                Console.Write(text.ToString().PadRight(Columns[columnIndex].Width));
                columnIndex++;
            }
            Console.WriteLine();

            Console.ForegroundColor = previousColor;
        }

    }
}
