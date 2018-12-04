using System;

namespace Modul6
{
    class Program
    {
        class Car
        {
            //string color;
            //int weight;

            //public void SetColor(string xxx)
            //{
            //    color = xxx;
            //}

            //public string GetColor()
            //{
            //    return color;
            //}

            //public void SetWeight(int yyy)
            //{
            //    kg = yyy;
            //}

            //public int GetWeight()
            //{
            //    return kg;
            //}

            public string Color { get; set; }
            public int Weight { get; set; }
            public int Year { get; set; }


            public Car(string c, int w, int y)
            {
                Color = c;
                Weight = w;
                Year = y;
            }

            public Car()
            {

            }


        }
        static void Main(string[] args)

        {
            //Console.WriteLine("Ange hur många bilar du önskar: ");
            //int numberOfCars = int.Parse(Console.ReadLine());

            //for (int i = 0; i < numberOfCars; i++)
            //{
            //Console.WriteLine("Ange färg, vikt och produktionsår för bilen: ");
            //var c[i] = new Car(Console.ReadLine(), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            //    i++;
            //}
            
            //var c2 = new Car("blå", 1200, 2016);
            //var c3 = new Car("grön", 800, 1960);

            //Console.Write("Välj färg på bil 1: ");
            //c1.SetColor(Console.ReadLine());

            //Console.Write("Välj färg på bil 2: ");
            //c2.SetColor(Console.ReadLine());

            //Console.Write("Välj färg på bil 3: ");
            //c3.SetColor(Console.ReadLine());


            //Console.Write("Välj vikt på bil 1: ");
            //c1.SetWeight(int.Parse(Console.ReadLine()));

            //Console.Write("Välj vikt på bil 1: ");
            //c2.SetWeight(int.Parse(Console.ReadLine()));

            //Console.Write("Välj vikt på bil 1: ");
            //c3.SetWeight(int.Parse(Console.ReadLine()));


            //var yyy = c1.GetColor();

            //var zzz = c2.GetColor();

            //var qqq = c3.GetColor();



            //Console.WriteLine($"Färgen på bilen 'c1' är {c1.Color}, dess vikt är {c1.Weight} kg och den är producerad år {c1.Year}");
            //Console.WriteLine($"Färgen på bilen 'c2' är {c2.Color}, dess vikt är {c2.Weight} kg och den är producerad år {c2.Year}");
            //Console.WriteLine($"Färgen på bilen 'c3' är {c3.Color}, dess vikt är {c3.Weight} kg och den är producerad år {c3.Year}");



            //        Console.WriteLine("Enter car: ");
            //        string car = Console.ReadLine();

            //        Console.WriteLine("Enter color: ");
            //        string color = Console.ReadLine();

            //        Console.WriteLine("Enter kg: ");
            //        int kg = int.Parse(Console.ReadLine());

            //        Console.WriteLine($"Färgen på bilen '{car}' är {color} och dess vikt är {kg}");
        }
    }
}
