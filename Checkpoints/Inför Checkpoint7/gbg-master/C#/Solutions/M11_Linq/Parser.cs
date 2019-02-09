using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace M11_Linq
{
    public class Parser
    {
        public List<Customer> CreateListOfCustomers(string dataFileWithCustomers)
        {
            // Read file to a list 

            List<string> peopleRows = ReadFileToList(dataFileWithCustomers);

            // Remove first line

            RemoveFirstLine(peopleRows);

            // Create list of customers

            var customerList = new List<Customer>();

            foreach (var row in peopleRows)
            {
                
                if (string.IsNullOrWhiteSpace(row))
                {
                    continue;
                }

                Customer customer = ParseCustomerFromRow(row);
                
                customerList.Add(customer);
            }

            return customerList;
        }

        private Customer ParseCustomerFromRow(string row)
        {
            // Expect this format: Id,First name,Last name,Email,Gender,Age

            string[] rowArray = row.Split(',');

            Gender gender;

            if (!Enum.TryParse(rowArray[4], out gender))
            {
                throw new Exception($"Couldn't parse gender {rowArray[4]}");
            }

            var customer = new Customer
            {
                Id = int.Parse(rowArray[0]),
                FirstName = rowArray[1],
                LastName = rowArray[2],
                Email = rowArray[3],
                Gender = gender,
                Age = int.Parse(rowArray[5])
            };
            return customer;
        }

        public List<string> CreateListOfNames(string dataFileWithCustomers)
        {
            // Read file to a list 

            List<string> peopleRows = ReadFileToList(dataFileWithCustomers);

            // Remove first line

            RemoveFirstLine(peopleRows);

            // Create list of names

            return CreateListOfNamesFromRows(peopleRows);

        }

        private List<string> CreateListOfNamesFromRows(List<string> peopleRows)
        {
            var nameList = new List<string>();

            foreach (var row in peopleRows)
            {

                // Expect this format: Id,First name,Last name,Email,Gender,Age
                if (string.IsNullOrWhiteSpace(row))
                {
                    continue;
                }
                string[] rowArray = row.Split(',');

                string fullName = rowArray[1] + " " + rowArray[2];
                nameList.Add(fullName);
            }

            return nameList;
        }

        private void RemoveFirstLine(List<string> peopleRows)
        {
            peopleRows.RemoveAt(0);
        }

        private List<string> ReadFileToList(string dataFileWithCustomers)
        {
            string contentRootPath = "Data";
            return File.ReadAllLines($"{contentRootPath}\\{dataFileWithCustomers}").ToList();
        }
    }
}
