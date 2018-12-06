using System;
using System.Collections.Generic;
using System.Linq;

namespace BeforeCheckpoint2
{
    class Program
    {
        static void Main(string[] args)
        {
            string main = "Elin,1988,tjej-Victor,1988,kille-Birgitta,1962,tjej-Jan,1960,kille-Sandra,1990,tjej-Patrik,1986,kille-Astrid,2018,tjej-Linda,1995,tjej-Fredrik,1995,kille";

            string[] sep1 = main.Split('-');
            List<Person> personList = new List<Person>();

            foreach (var item in sep1)
            {
                Person newPerson = new Person();
                string[] sepArray = item.Split(',');
                newPerson.Name = sepArray[0];
                newPerson.YearOfBirth = int.Parse(sepArray[1]);
                newPerson.Sex = sepArray[2];
                personList.Add(newPerson);
            }

            Console.WriteLine();
            Console.WriteLine($"Familjen består av {personList.Count} personer\n");
            Console.WriteLine($"Familjen består av: ");

            foreach (var person in personList.OrderBy(x=>x.YearOfBirth))
            {
                Console.WriteLine($"* {person.Name}");
            }

            Console.WriteLine();

            foreach (var person in personList.OrderBy(x=>x.YearOfBirth))
            {
                if (person.YearOfBirth < 1980)
                {
                    Console.WriteLine($"{person.Name} är en gammal {person.Sex}!");
                }
                else if (person.YearOfBirth > 1980 && person.YearOfBirth < 2017)
                {
                    Console.WriteLine($"{person.Name} är en snart gammal {person.Sex}!");
                }
                else
                {
                    Console.WriteLine($"{person.Name} är en söt och liten {person.Sex}!");
                }
            }
            
            
        }
    }
}
