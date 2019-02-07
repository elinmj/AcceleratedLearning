using Microsoft.AspNetCore.Hosting;
using Mvc01.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mvc01.Services
{
    public class ProductRepository : IProductRepository
    {

        private IHostingEnvironment _env;

        public ProductRepository(IHostingEnvironment env)
        {
            _env = env;
        }

        public void Add(Product product)
        {
            List<Product> productList = GetAll();
            string name = _env.ContentRootPath;
            string filename = Path.Combine(name, "Data", "products.txt");

            using (StreamWriter file =
                new StreamWriter(filename, true))
            {
                file.WriteLine((productList.Count + 1) + ", " + product.Name + ", " + product.Description);

            }
        }

        public List<Product> GetAll()
        {
            string name = _env.ContentRootPath;
            string filename = Path.Combine(name, "Data", "products.txt");
            string[] allProducts = File.ReadAllLines(filename);
            List<Product> productList = new List<Product>();

            foreach (var item in allProducts)
            {
                Product product = new Product();
                string[] tmpArray = item.Split(',');
                product.Id = int.Parse(tmpArray[0]);
                product.Name = tmpArray[1];
                product.Description = tmpArray[2];
                productList.Add(product);
            }

            return productList;
        }

        public Product GetById(int v)
        {
            List<Product> productList = GetAll();

            //Kan också byta ut Where mot Single. Det är coolare. COOLAST: return GetAll().Single(x => x.Id == v);
            Product product = productList.Where(x => x.Id == v).Single();

            return product;

            

        }
    }
}
