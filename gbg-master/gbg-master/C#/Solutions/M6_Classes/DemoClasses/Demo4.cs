// Syfte: Properties gör att vi slipper skapa metoder som "SetColor" och "GetColor"

using System;

namespace M6_Classes.DemoClasses
{
    public class Demo4
    {
        class Car
        {
            public int Weight { get; set; }
            public string Color { get; set; }

            public Car(string c, int w)
            {
                Color = c;
                Weight = w;
            }

            public Car()
            {
                Color = "lila";
                Weight = 999;
            }
        }

        public void Run()
        {
            var c1 = new Car("blå", 1200);
            var c2 = new Car("röd", 800);
            var c3 = new Car(); // ska ge en bil med lila färg som väger 999kg 

            c2.Color = "gul"; 
            c2.Weight = 600;

            Console.WriteLine($"Färgen på bilen 'c1' är {c1.Color} och dess vikt är {c1.Weight}");
            Console.WriteLine($"Färgen på bilen 'c2' är {c2.Color} och dess vikt är {c2.Weight}");
            Console.WriteLine($"Färgen på bilen 'c3' är {c3.Color} och dess vikt är {c3.Weight}");
        }
    }
}
