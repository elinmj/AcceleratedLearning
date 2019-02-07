using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc01.Models;
using Mvc01.Services;
using Mvc01.ViewModels;
using System.Collections.Generic;

namespace Mvc01.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Testy()
        {
            return View("testy");
        }

        public IActionResult Yrittää()
        {
            return View("yrittää");
        }

        public IActionResult Index()
        {
            var vm = new ProductListVm();
            List<Product> productList = _repo.GetAll();
            var list = new List<SelectListItem>();

            foreach (var item in productList)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });

            }

            vm.AllProducts = list;

            return View(vm);
        }

        public IActionResult Listall()
        {
            List<Product> allProducts = _repo.GetAll();
            return View(allProducts);
            
        }

        public IActionResult GetById(int id)
        {
            Product x = _repo.GetById(id);
            return View(x);

        }

        [HttpPost]
        public IActionResult Index(Product product)
        {
            _repo.Add(product);
            return View("ProductAdded",product);

        }

    }
}
