using System;

namespace M6_Classes.DemoSetter
{
    public class Demo1
    {
        // Dåligt för rabatten kan av misstag sättas till t.ex -12 eller 5000
        class Tshirt
        {
            public decimal Price { get; set; }
            public decimal Discount { get; set; }
        }

        public void Run()
        {
            var t = new Tshirt();
            t.Price = 400;
            t.Discount = 0.3M;

            var priceWithDiscount = t.Price * (1 - t.Discount);

            Console.WriteLine("Priset för tshirten med rabatt är :" + priceWithDiscount);

        }
    }
}
