using System;
using System.Collections.Generic;
using System.Text;

namespace Modul6._1
{
    public class Circle
    {
        public string name { get; set; }
        public double radius { get; set; }


        public Circle(string n, double r)
        {
            name = n;
            radius = r;
        }

        public Circle(string n)
        {
            radius = 5;
            name = n;
        }

        public Circle()
        {
            radius = 5;
            name = "Unknown";
        }

        public void SayHello()
        {
            Console.WriteLine($"I'm a circle with the name of {name}!");
        }

        public void WriteArea()
        {
            double area = radius * radius * Math.PI;
            Console.WriteLine($"My name is {name}. I have a radius of {radius} and an area of {area:.##}");
        }
    }
}
