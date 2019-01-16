// Syfte: skapa en bil-klass som innehåller bil-egenskaper (använd ej propertys)
using System;

namespace M6_Classes.DemoClasses
{
    public class Demo1
    {
        class Car
        {
            string color;

            public void SetColor(string xxx)
            {
                color = xxx;
            }

            public string GetColor()
            {
                return color;
            }
        }

        public void Run()
        {
            var c1 = new Car();
            var c2 = new Car();
            var c3 = new Car();

            c1.SetColor("blå");
            c2.SetColor("röd");

            Console.WriteLine("Färgen på bilen 'c1' är " + c1.GetColor());
            Console.WriteLine("Färgen på bilen 'c2' är " + c2.GetColor());
            Console.WriteLine("Färgen på bilen 'c3' är " + c3.GetColor());
        }
    }
}
