using System;

namespace M6_Classes.DemoEnums
{
    public class Demo1
    {
        enum CoffeMachineMaterial
        {
            Plastic, Wood, Metal, Glass
        }

        enum CoffeMachineColor
        {
            White, Black, Red
        }

        class CoffeMachine
        {
            public DateTime Ordered { get; set; }
            public decimal Price { get; set; }
            public bool NeedMaintenance { get; set; }
            public string ProductName { get; set; }
            //public string Color { get; set; } 
            //public string Material { get; set; } 
            public CoffeMachineColor Color { get; set; } 
            public CoffeMachineMaterial Material { get; set; } 
        }


        public void Run()
        {
            var x = new CoffeMachine
            {
                Ordered = new DateTime(2018, 8, 10),
                Price = 123,
                NeedMaintenance = false,
                ProductName = "Sage the Barista",
                //Color = "White",
                //Material = "Plastic",
                Color = CoffeMachineColor.White,
                Material = CoffeMachineMaterial.Plastic
            };

            if (x.Color == CoffeMachineColor.White)
            {
                Console.WriteLine("Maskinen är vit");
            }

            Console.Write("Ändra maskinen till ett annat material: ");
            string answer = Console.ReadLine();
            CoffeMachineMaterial y = (CoffeMachineMaterial) Enum.Parse(typeof(CoffeMachineMaterial), answer);
            x.Material = y;

            Console.WriteLine("Materialet är nu: " + x.Material);
        }
    }
}
