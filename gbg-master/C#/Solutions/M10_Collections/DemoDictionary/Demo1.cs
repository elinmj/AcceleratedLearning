using System;
using System.Collections.Generic;

namespace M10_Collections.DemoDictionary
{
    public class Demo1
    {
        public void Run()
        {
            /*
             * A => 35kr
             * B => 45kr
             * C => 68kr
             */
            var dic = new Dictionary<char, int>();

            dic.Add('A', 35);
            dic.Add('B', 45);
            dic.Add('C', 68);

            Console.WriteLine($"Böcker i priskategori A kostar {dic['A']} kr");
            Console.WriteLine($"Böcker i priskategori B kostar {dic['B']} kr");
            Console.WriteLine($"Böcker i priskategori C kostar {dic['C']} kr");
            Console.WriteLine();

            if (dic.ContainsKey('B'))
                Console.WriteLine("Det finns en priskategori som heter B");

            if (!dic.ContainsKey('D'))
                Console.WriteLine("Det finns ingen priskategori som heter D");
            Console.WriteLine();

            dic.Add('D', 150);
            dic.Remove('B');
            dic['A'] = 20;

            Console.WriteLine("Nu har priskategori D lagts till och priskategori B tagits bort");
            Console.WriteLine($"Priskategori A kostar nu {dic['A']} kr");
        }
    }
}
