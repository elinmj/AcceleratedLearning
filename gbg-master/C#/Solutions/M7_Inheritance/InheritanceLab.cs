using CommonStuff;
using System;
using System.Collections.Generic;

namespace M7_Inheritance
{
    public class InheritanceLab
    {
        ConsoleHelper ch = new ConsoleHelper();

        public void Run()
        {
            List<Shape> shapeList = AskForListOfShapes();

            PrintAllShapes(shapeList);

            ReportAreaOfShapes(shapeList);
        }

 
        private void ReportAreaOfShapes(List<Shape> shapeList)
        {
            Console.WriteLine();

            double totalArea = 0;

            Console.ForegroundColor = ConsoleColor.DarkGray;

            foreach (Shape shape in shapeList)
            {
                double area = shape.CalculateArea();
                ch.TwoColumns(shape.GetType().Name, Math.Round(area, 2).ToString());
                totalArea += area;
            }
            ch.TwoColumns("Total area:", Math.Round(totalArea, 2).ToString());

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PrintAllShapes(List<Shape> shapeList)
        {
            Console.WriteLine();

            foreach (Shape shape in shapeList)
            {
                ch.WriteDark(shape.ToString());
            }
        }


        private List<Shape> AskForListOfShapes()
        {
            bool oneMore = true;
            List<Shape> allShapes = new List<Shape>();

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Select (T)riangle, (R)ectangle, (C)ircle or (D)one: ");
                Console.ForegroundColor = ConsoleColor.Green;

                char answer = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (answer.ToString().ToLower())
                {
                    case "t":
                        Triangle triangle = AskForTriangle();
                        allShapes.Add(triangle);
                        break;

                    case "r":
                        Rectangle rectangle = AskForRectangle();
                        allShapes.Add(rectangle);
                        break;

                    case "c":
                        Circle circle = AskForCircle();
                        allShapes.Add(circle);
                        break;

                    case "d":
                        oneMore = false;
                        break;
                }

            } while (oneMore);

            return allShapes;
        }

        private Circle AskForCircle()
        {
            double radius = ch.AskForNumber("Enter radius of circle");
            return new Circle(radius);
        }

        private Rectangle AskForRectangle()
        {
            double width = ch.AskForNumber("Enter width of rectangle");
            double height = ch.AskForNumber("Enter height of rectangle");
            return new Rectangle(height, width);
        }

        private Triangle AskForTriangle()
        {
            double baselength = ch.AskForNumber("Enter base of triangle");
            double height = ch.AskForNumber("Enter height of triangle");
            return new Triangle(baselength, height);
        }

    }
}
