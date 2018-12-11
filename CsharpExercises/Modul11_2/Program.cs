using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Modul11_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personShort = File.ReadAllLines(@"C:\Project\AcceleratedLearning\CsharpExercises\PersonShort.csv");
            //string[] personListExtra = File.ReadAllLines(@"C:\Project\AcceleratedLearning\CsharpExercises\PersonListExtra.csv");

            //var parser = new Parser();                                                    //Extra-uppgift 1 påbörjad
            //List<Customer> list = parser.CreateListOfCustomers(personShort);
            List<Customer> list = CreateListOfCustomers(personShort);
            SortedLists(list);
        }

        private static List<Customer> CreateListOfCustomers(string[] personShort)
        {
            List<Customer> list = new List<Customer>();

            foreach (var item in personShort)
            {
                Customer newCustomer = new Customer();

                string[] split = item.Split(',');

                newCustomer.Id = int.Parse(split[0]);
                newCustomer.FirstName = split[1];
                newCustomer.LastName = split[2];
                newCustomer.Email = split[3];
                newCustomer.Gender = split[4];  
                newCustomer.Age = int.Parse(split[5]);

                list.Add(newCustomer);

            }

            return list;
        }

        private static void SortedLists(List<Customer> list)
        {
            Console.WriteLine("Sorted list by age:\n");

            foreach (Customer customer in list.OrderBy(x => x.Age))
            {
                Console.WriteLine($"{customer.FirstName}\t{customer.Age}\t{customer.Gender}");
            }

            Console.WriteLine();

            Console.WriteLine("Sorted list by first name:\n");

            foreach (Customer customer in list.OrderBy(x => x.FirstName))
            {
                Console.WriteLine($"{customer.FirstName}\t{customer.Age}\t{customer.Gender}");
            }

            Console.WriteLine();

            Console.WriteLine("Men older than 35:\n");

            foreach (Customer customer in list.Where(x => x.Age > 35).OrderBy(x => x.Age))
            {
                Console.WriteLine($"{customer.FirstName}\t{customer.Age}\t{customer.Gender}");
            }

            Console.WriteLine();

            Console.WriteLine("Manipulated:\n");

            foreach (Customer customer in list.Where(x => x.Age > 35).OrderBy(x => x.Age))
            {
                Console.WriteLine($"{customer.FirstName.ToUpper()}\t{customer.Age + 1000}\t{customer.Gender}");
            }

            Console.WriteLine();
        }
    }
}
