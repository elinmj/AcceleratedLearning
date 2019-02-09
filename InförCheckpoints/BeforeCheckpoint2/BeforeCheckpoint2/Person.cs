using System;
using System.Collections.Generic;
using System.Text;

namespace BeforeCheckpoint2
{
    class Person
    {

        public Person(string name, int year, string sex)
        {
            Name = name;
            YearOfBirth = year;
            Sex = sex;
        }

        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public string Sex { get; set; }

    }
}
