using Mvc01.Models;
using System.Collections.Generic;

namespace Mvc01.Services
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int v);
        void Add(Product product);
    }
}