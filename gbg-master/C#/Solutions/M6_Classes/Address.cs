using System;
using System.Text.RegularExpressions;

namespace M6_Classes
{
    /// <summary>
    /// My class for address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The street part of the <see cref="Address"/>
        /// </summary>
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }

        private string _zipCode;
        private string _zippyCode;

        // Set zip code with ordinary method

        public void SetZipCode(string newvalue)
        {
            string okZipCodePattern = @"^\d\d\d \d\d$";

            if (Regex.IsMatch(newvalue, okZipCodePattern))
            {
                _zippyCode = newvalue;
            }
        }

        // Get zip code with ordinary method

        public string GetZipCode()
        {
            return _zippyCode;
        }

        // Alternative with Set property

        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                if (ZipCodeIsValid(value))
                {
                    _zipCode = value;
                }
            }
        }

        private bool ZipCodeIsValid(string value)
        {
            return Regex.IsMatch(value, @"^\d\d\d \d\d$");

        }

        // Get method

        public string GetFullStreet()
        {
            return $"{Street} {StreetNumber}";
        }

        // Get using property instead

        public string FullStreet
        {
            get
            {
                return $"{Street} {StreetNumber}";
            }
        }

        // Same as above but shorter

        public string FullStreet_Shorter => $"{Street} {StreetNumber}";
    }
}
