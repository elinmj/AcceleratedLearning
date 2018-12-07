using System;

namespace M6_Classes.DemoGetter
{
    public class Demo3
    {

        // Samma sak men med properties

        public class Product
        {
            public decimal Price { get; set; }

            public decimal VAT
            {
                get { return Price * 0.25M; }
            }

            public decimal TotalPrice
            {
                get { return Price + VAT; }
            }
        }
        
        public void Run()
        {
            var telefon = new Product();
            telefon.Price = 1000;
            Console.WriteLine("Total kostnad för telefonen är: " + telefon.TotalPrice);
        }
    }
}
