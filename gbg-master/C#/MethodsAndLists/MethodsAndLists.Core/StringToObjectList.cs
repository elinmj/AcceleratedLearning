using System;
using System.Collections.Generic;
using MethodsAndLists.Core.Models;

namespace MethodsAndLists.Core
{
    public class StringToObjectList
    {
        public List<City> ParseCities(string input)
        {
            if (input == null)
                throw new ArgumentException();

            var result = new List<City>();

            if (input.Trim() == "")
                return result;

            string[] cityStringList = input.Split(";");

            foreach (string cityString in cityStringList)
            {
                string name = cityString.Split(',')[0];
                int population = int.Parse(cityString.Split(',')[1]);
                var city = new City
                {
                    Name = name,
                    Population = population
                };
                result.Add(city);
            }
            return result;
        }
    }
}
