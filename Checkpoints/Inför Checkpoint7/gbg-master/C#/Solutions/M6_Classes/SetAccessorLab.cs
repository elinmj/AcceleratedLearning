using CommonStuff;
using System;

namespace M6_Classes
{
    public static class SetAccessorLab
    {
        private static void SetWithProperty()
        {
            ConsoleHelper ch = new ConsoleHelper();

            Address address = new Address
            {
                Street = "Långa gatan",
                StreetNumber = "13B",
                City = "Sundsvall",
            };

            ch.WriteDark("Try to set zipcode to 111 22");
            address.ZipCode = "111 22";
            ch.TwoColumns("ZipCode", address.ZipCode);
            Console.WriteLine();

            ch.WriteDark("Try to set zipcode to 222 33");
            address.ZipCode = "222 33";
            ch.TwoColumns("ZipCode", address.ZipCode);
            Console.WriteLine();

            ch.WriteDark("Try to set zipcode to HELLO");
            address.ZipCode = "HELLO";
            ch.TwoColumns("ZipCode", address.ZipCode);
        }

        private static void SetWithMethods()
        {
            ConsoleHelper ch = new ConsoleHelper();

            Address address = new Address
            {
                Street = "Långa gatan",
                StreetNumber = "13B",
                City = "Sundsvall",
            };


            ch.WriteDark("Try to set zippycode to 111 22");
            address.SetZipCode("111 22"); 
            ch.TwoColumns("ZippyCode", address.GetZipCode());
            Console.WriteLine();

            ch.WriteDark("Try to set zippycode to 222 33");
            address.SetZipCode("222 33");
            ch.TwoColumns("ZippyCode", address.GetZipCode());
            Console.WriteLine();

            ch.WriteDark("Try to set zippycode to HELLO");
            address.SetZipCode("HELLO");
            ch.TwoColumns("ZippyCode", address.GetZipCode());
        }

        public static void Run()
        {
            //SetWithMethods();

            //Console.WriteLine();
            //ch.Line();
            //Console.WriteLine();

            SetWithProperty();
            
        }
    }
}
