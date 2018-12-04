using System;
using System.Collections.Generic;
using System.Text;

namespace Modul6_6
{
    class Address2
    {
        //public string Street { get; set; }
        //public string StreetNumber { get; set; }
        //public string City { get; set; }
        public string ZipCode; /*{ get; set; }*/

        //public string FullStreet 

        public void SetZipCode(string ZipCode)
        {
            if (!ZipCode.Equals("[0-9]:[0-9]:[0-9]:[0-9]:[0-9]"))
            {
                Console.Write("Try again: ");
            }
        }

        public string GetZipCode()
        {
            return ZipCode;
        }

        //public string GetFullStreet()
        //{
        //    return Street + " " + StreetNumber;
        //}
    }
}
