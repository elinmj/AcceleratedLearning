using System;
using System.Collections.Generic;
using System.Linq;

namespace M11_Linq
{
    public class LinqLab
    {
        public void Run()
        {
            // 11.1 Work with a list of string
            //ListOfStringLab();

            // 11.2 Work with list of Customers
            ListOfCustomerLab();

            //DemoLinq();
        }


        private void ListOfStringLab()
        {
            var parser = new Parser();
            List<string> list = parser.CreateListOfNames("PersonShort.csv");

            list.Sort();
            DisplayListOfString("Sorted list:", list);

            var startsWithJ = list.Where(name => name.StartsWith("J")).ToList();
            DisplayListOfString("Start with J:", startsWithJ);

            var startsWithDAndUpper = startsWithJ.Select(name => name.ToUpper()).ToList();
            DisplayListOfString("Start with J and uppercase:", startsWithDAndUpper);

            Console.ReadKey();
        }

        private void DisplayListOfString(string header, List<string> list)
        {
            WriteLineWhite(header);
            foreach (string s in list)
            {
                WriteLineDark(s);
            }
            Console.WriteLine();
        }


        private void ListOfCustomerLab()
        {
            var parser = new Parser();
            List<Customer> list = parser.CreateListOfCustomers("PersonShort.csv");

            list.Sort((c1, c2) => c1.Age - c2.Age);
            DisplayListOfCustomers("Sorted list by age:", list);

            list.Sort((c1, c2) => string.Compare(c1.FirstName, c2.FirstName));
            DisplayListOfCustomers("Sorted list by first name:", list);

            var menOlderThan35 = list.Where(c => c.Gender == Gender.Male && c.Age > 35);
            DisplayListOfCustomers("Men older than 35:", menOlderThan35);

            var manipulatedList = menOlderThan35.Select(c => new Customer
            {
                Id = c.Id,
                Age = c.Age + 1000,
                FirstName = c.FirstName.ToUpper(),
                LastName = c.LastName.ToUpper(),
                Email = c.Email,
                Gender = c.Gender
            });

            DisplayListOfCustomers("Manipulated:", manipulatedList);
        }

        private void DisplayListOfCustomers(string header, IEnumerable<Customer> list)
        {
            WriteLineWhite(header);

            foreach (Customer c in list)
                WriteLineDark(c.FirstName.PadRight(20) + c.Age.ToString().PadRight(20) + c.Gender.ToString().PadRight(20));

            Console.WriteLine();
        }

        private void WriteLineDark(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(s);
        }


        private void WriteLineWhite(string s)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(s);
        }
    }
    

}
