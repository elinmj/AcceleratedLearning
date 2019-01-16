// Syfte: Konstruktorer gör att det blir snabbare att skapa ett objekt med vissa egenskaper (+ att vi styr hur en bil får skapas) 

using System;

namespace M6_Classes.DemoClasses
{
    public class Demo3
    {
        class Car
        {
            private string color;
            private int weight;

            public Car()
            {
                color = "lila";
                weight = 999;
            }

            public Car(string x, int y)
            {
                color = x;
                weight = y;
            }

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
            var c1 = new Car("blå", 1200);
            var c2 = new Car("röd", 800);
            var c3 = new Car();

            Console.WriteLine($"Färgen på bilen 'c1' är {c1.GetColor()} och dess vikt är {c1.GetWeight()}");
            Console.WriteLine($"Färgen på bilen 'c2' är {c2.GetColor()} och dess vikt är {c2.GetWeight()}");
            Console.WriteLine($"Färgen på bilen 'c3' är {c3.GetColor()} och dess vikt är {c3.GetWeight()}");


        }
    }
}
