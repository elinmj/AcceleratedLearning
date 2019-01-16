using System;

namespace M6_Classes.DemoGetter
{
    public class Demo4
    {
        // Smidigare att bara använda en pil
        public class Product
        {
            public decimal Price { get; set; }
            public decimal VAT => Price * 0.25M;
            public decimal TotalPrice => Price + VAT;
        }

        public void Run()
        {
            var telefon = new Product
            {
                Price = 1000
            };
            Console.WriteLine("Total kostnad för telefonen är: " + telefon.TotalPrice);
        }
    }
}
