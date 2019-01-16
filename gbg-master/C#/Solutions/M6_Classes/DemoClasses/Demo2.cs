// Syfte: skapa en bil-klass som innehåller fler bil-egenskaper (både färg och vikt)
using System;

namespace M6_Classes.DemoClasses
{
    public class Demo2
    {
        class Car
        {
            private string color;
            private int weight;

            public void SetColor(string x)
            {
                color = x;
            }

            public string GetColor()
            {
                return color;
            }

            public void SetWeight(int x)
            {
                weight = x;
            }

            public int GetWeight()
            {
                return weight;
            }

        }

        public void Run()
        {
            var c1 = new Car();
            var c2 = new Car();
            var c3 = new Car();

            c1.SetColor("blå");
            c1.SetWeight(1200);

            c2.SetColor("röd");
            c2.SetWeight(800);

            Console.WriteLine($"Färgen på bilen 'c1' är {c1.GetColor()} och dess vikt är {c1.GetWeight()}");
            Console.WriteLine($"Färgen på bilen 'c2' är {c2.GetColor()} och dess vikt är {c2.GetWeight()}");
            Console.WriteLine($"Färgen på bilen 'c3' är {c3.GetColor()} och dess vikt är {c3.GetWeight()}");

        }
    }
}
