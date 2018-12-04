using System;

namespace Modul6_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter zipcode: ");

            Address2 address = new Address2
            {
                //Street = "Långa gatan",
                //StreetNumber = "13B",
                //City = "Sundsvall",
                ZipCode = Console.ReadLine(),
            };

            
            

            //Console.WriteLine($"Street:\t\t\t {address.Street}");
            //Console.WriteLine($"StreetNumber:\t\t {address.StreetNumber}");
            //Console.WriteLine($"City:\t\t\t {address.City}");
            Console.WriteLine($"ZipCode:\t\t {address.GetZipCode()}");
            //Console.WriteLine($"FullStreet:\t\t {address.GetFullStreet()}");

            Console.WriteLine();

            //Kolla denna uppgiften!!!
        }
    }
}
