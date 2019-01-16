using System;

namespace M6_Classes.DemoSetter
{
    public class Demo3
    {
        // Samma som Demo2 men med properties

        class Tshirt
        {
            private decimal discount=0;

            public decimal Price { get; set; }

            public decimal Discount
            {
                get
                {
                    return discount;
                }
                set
                {
                    if (value >= 0 && value <= 1)
                    {
                        discount = value;
                    }
                }
            }

        }

        public void Run()
        {
            var t = new Tshirt();
            t.Price = 400;
            t.Discount = 0.3M;
            t.Discount = 123M; // här kommer inget ske

            var priceWithDiscount = t.Price * (1 - t.Discount);

            Console.WriteLine("Priset för tshirten med rabatt är :" + priceWithDiscount);

        }
    }
}
