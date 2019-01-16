using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class NumberListToString
    {
        // Demo: returnera "fjärde talet är jättestort" om det är större än 10000

        public string ReportNumberOfNegativeValues(List<int> numbers)
        {
            int negativeNumbersCounter = 0;
            foreach (var number in numbers)
            {
                if (number < 0)
                    negativeNumbersCounter++;
            }

            if (negativeNumbersCounter == 0)
                return "Jippi! Det finns inga negativa tal i listan";
            else if (negativeNumbersCounter == 1)
                return "Det finns ett negativt tal i listan";
            else
                return "Det finns " + negativeNumbersCounter + " st negativa tal i listan";

        }

        public string ReportIfAllValuesAreHigherThan100(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException();

            bool highNumbers = numbers.Count != 0;

            foreach (int number in numbers)
            {
                if (number <= 100)
                    highNumbers = false;
            }

            if (highNumbers)
                return "Alla nummer är högre än 100";
            else
                return "Något nummer är lägre än (eller lika med) 100";
        }

        public string ReportFirstAndLastValue(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException();

            int first = numbers[0];
            int lastIndex = numbers.Count - 1;
            int last = numbers[lastIndex];

            return "Första siffran är " + first + " och sista siffran är " + last;
        }

        public string ReportFirstAndLastValue_Linq(List<int> numbers)
        {
            return "Första siffran är " + numbers.First() + " och sista siffran är " + numbers.Last();
        }
    }
}