using System;

namespace M6_Classes.DemoSetter
{
    public class Demo2
    {
        // Bättre för nu kan inte rabatten bli vad som helst

        class Tshirt
        {
            private decimal discount=0;

            public decimal Price { get; set; }

            public void SetDiscount(decimal d)
            {
                if (d >= 0 && d <= 1)
                {
                    discount = d;
                }
            }

            public decimal GetDiscount()
            {
                return discount;
            }
        }

        public void Run()
        {
            var t = new Tshirt();
            t.Price = 400;
            t.SetDiscount(0.3M);
            t.SetDiscount(123M); // här kommer inget ske

            var priceWithDiscount = t.Price * (1 - t.GetDiscount());

            Console.WriteLine("Priset för tshirten med rabatt är :" + priceWithDiscount);

        }
    }
}
