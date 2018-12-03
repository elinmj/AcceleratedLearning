using System;
using System.Collections.Generic;

namespace Modul7
{
    class Program
    {
        static void Main(string[] args)
        {
            //var shapes = new Shape();

            List<Shape> shapeList = new List<Shape>();

            string inputSelect;

            do
            {
                Console.Write("Select (T)riangle, (R)ectangle, (C)ircle or (D)one");

                inputSelect = Console.ReadLine().Trim();

                if (inputSelect == "T")
                {

                    Console.Write("Enter base of triangle: ");
                    decimal baseTriangle = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter heigth of triangle: ");
                    decimal heightTriangle = decimal.Parse(Console.ReadLine());

                    var triangle = new Triangle();
                    triangle.heights = heightTriangle;
                    triangle.bases = baseTriangle;
                    shapeList.Add(triangle);

                }
                else if (inputSelect == "R")
                {

                    Console.Write("Enter base of rectangle: ");
                    decimal baseRectangle = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter heigth of rectangle: ");
                    decimal heightRectangle = decimal.Parse(Console.ReadLine());

                    var rectangle = new Rectangle();
                    rectangle.heights = heightRectangle;
                    rectangle.bases = baseRectangle;
                    shapeList.Add(rectangle);

                }
                else if (inputSelect == "C")
                {

                    Console.WriteLine("Enter radius of circle: ");
                    decimal radiusCircle = decimal.Parse(Console.ReadLine());

                    var circle = new Circle();
                    circle.radius = radiusCircle;
                    shapeList.Add(circle);
                }

            } while (inputSelect != "D");


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;


            foreach (Shape item in shapeList)
            {
                if (item is Triangle)
                {
                    var t = (Triangle)item;
                    Console.WriteLine($"I'm a triangle with baselength={t.bases} and height={t.heights}");
                }
                else if (item is Rectangle)
                {
                    var r = (Rectangle)item;
                    Console.WriteLine($"I'm a rectangle with baselength={r.bases} and height={r.heights}");

                }
                else
                {
                    var c = (Circle)item;
                    Console.WriteLine($"I'm a circle with radius={c.radius}");
                }

            }
        }
    }
}
