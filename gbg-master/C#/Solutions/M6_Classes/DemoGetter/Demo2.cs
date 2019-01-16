using System;

namespace M6_Classes.DemoGetter
{
    public class Demo2
    {
        // Bättre för nu beräknas värdena av moms och totalpris

        class Product
        {
            public decimal Price { get; set; }

            public decimal GetVAT()
            {
                return Price * 0.25M;
            }

            public decimal GetTotalPrice()
            {
                return Price + GetVAT();
            }             
        }

        public void Run()
        {
            var telefon = new Product();
            telefon.Price = 1000;
            Console.WriteLine("Total kostnad för telefonen är: " + telefon.GetTotalPrice());
        }
    }
}
