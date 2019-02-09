using System;

namespace M6_Classes.DemoGetter
{
    public class Demo1
    {
        // Dålig lösning

        class Product
        {
            public decimal Price { get; set; }
            public decimal VAT { get; set; }            // nackdel, detta kan råka sättas till fel värde
            public decimal TotalPrice { get; set; }     // nackdel, detta kan råka sättas till fel värde
        }

        public void Run()
        {
            var telefon = new Product();
            telefon.Price = 1000;
            telefon.VAT = 250;
            telefon.TotalPrice = 1250;
            Console.WriteLine("Total kostnad för telefonen är: " + telefon.TotalPrice);

            var kaffekopp = new Product();
            kaffekopp.Price = 24;
            kaffekopp.VAT = 8;
            kaffekopp.TotalPrice = 32;
            Console.WriteLine("Total pris för kaffekoppen är: " + kaffekopp.TotalPrice);
            
        }
    }
}
