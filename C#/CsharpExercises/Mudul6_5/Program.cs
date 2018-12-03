using System;

namespace Mudul6_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address = new Address
            {
                Street = "Långa gatan",
                StreetNumber = "13B",
                City = "Sundsvall",
                ZipCode = "111 22",
            };

            Console.WriteLine($"Street:\t\t\t {address.Street}");
            Console.WriteLine($"StreetNumber:\t\t {address.StreetNumber}");
            Console.WriteLine($"City:\t\t\t {address.City}");
            Console.WriteLine($"ZipCode:\t\t {address.ZipCode}");
            Console.WriteLine($"FullStreet:\t\t {address.GetFullStreet()}");

            Console.WriteLine();


            // Ej klar med uppgiften
        }

    }
}
