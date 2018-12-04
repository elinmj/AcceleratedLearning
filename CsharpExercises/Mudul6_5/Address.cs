using System;
using System.Collections.Generic;
using System.Text;

namespace Mudul6_5
{
    class Address
    {
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        //public string FullStreet 

    public string GetFullStreet()
    {
            return Street + " " + StreetNumber;
    }
    }


    
}
