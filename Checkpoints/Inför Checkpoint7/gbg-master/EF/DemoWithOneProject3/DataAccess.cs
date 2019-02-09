using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DemoWithOneProject3
{
    public class DataAccess 
    {
        private readonly FruitContext _context;

        public DataAccess()
        {
            _context = new FruitContext();
        }

        public void ClearDatabase()
        {
            foreach (var category in _context.FruitCategories)
            {
                _context.Remove(category);
            }

            foreach (var fruit in _context.Fruits)
            {
                _context.Remove(fruit);
            }

            foreach (var basket in _context.Baskets)
            {
                _context.Remove(basket);
            }
        }

        public void AddCategoriesAndFruits()
        {
            var skenfrukt = new FruitCategory { Name = "Skenfrukt" };
            var torrÄkta = new FruitCategory { Name = "Torr äkta frukt" };
            var saftigÄkta = new FruitCategory { Name = "Saftig äkta frukt" };

            var ananas = new Fruit { Name = "Ananas", Category = skenfrukt, Price = 10.3M };
            var nypon = new Fruit { Name = "Nypon", Category = skenfrukt, Price = 2 };
            var korsbar = new Fruit { Name = "Körsbär", Category = saftigÄkta, Price = 55 };
            var mandel = new Fruit { Name = "Mandel", Category = saftigÄkta, Price = 42 };
            var artor = new Fruit { Name = "Ärtor", Category = torrÄkta, Price = 30 };
            var kikartor = new Fruit { Name = "Kikärtor", Category = torrÄkta, Price = 100 };

            _context.Fruits.AddRange(ananas, nypon, korsbar, mandel, artor, kikartor);

            var b1 = new Basket
            {
                Name = "Min kundvagn",
                FruitInBaskets = new List<FruitInBasket>
                {
                    new FruitInBasket {Fruit = nypon},
                    new FruitInBasket {Fruit = mandel},
                }
            };

            var b2 = new Basket
            {
                Name = "Min andra kundkorg",
                FruitInBaskets = new List<FruitInBasket>
                {
                    new FruitInBasket {Fruit = nypon},
                    new FruitInBasket {Fruit = artor},
                    new FruitInBasket {Fruit = kikartor},
                }
            };

            _context.Baskets.AddRange(b1, b2);

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Fruit> GetAll()
        {
            return _context.Fruits.Include(x=>x.Category).ToList();
        }

        public List<Fruit> GetFruitsInCategory(string categoryName)
        {
            return _context.FruitCategories
                       .Include(x => x.Fruits)
                       .SingleOrDefault(x => x.Name == categoryName)
                       ?.Fruits.ToList() ?? new List<Fruit>();
        }

        public IEnumerable<Basket> GetAllBaskets()
        {
            return _context.Baskets;
        }

        public IEnumerable<Fruit> GetAllFruitsInBasket(int basketId)
        {
            /* 
               Utgå från Baskets
               Två steg: 
               1) hämta först kundkorgen (krävs Include och ThenInclude)
               2) plocka fram den frukter som finns i kundkorgen
            */
            Basket basket = _context
                .Baskets
                .Include(x => x.FruitInBaskets)
                .ThenInclude(x => x.Fruit)
                .Single(b => b.Id == basketId);

            return basket.FruitInBaskets.Select(x => x.Fruit);
        }

        public IEnumerable<Fruit> GetAllFruitsInBasket_Alternative(int basketId)
        {
            /*
              Samma som ovan men i ett svep
             */
            return _context
                .Baskets
                .Include(x => x.FruitInBaskets)
                .ThenInclude(x => x.Fruit)
                .Single(b => b.Id == basketId)
                .FruitInBaskets
                .Select(x => x.Fruit);
        }


        public IEnumerable<Fruit> GetAllFruitsInBasket_Alternative2(int basketId)
        {
            /*
                Utgå ifrån Fruits
                Hämta de FruitInBaskets som har id "basketId"
                "FruitInBaskets.Select(x => x.BasketId)" ger en lista av kundkorgsid
             */
            return _context
                .Fruits
                .Where(f => f.FruitInBaskets.Select(x => x.BasketId).Contains(basketId));
        }

        public IEnumerable<Fruit> GetAllFruitsInBasket_Alternative3(int basketId)
        {
            /*
             Utgå ifrån mellantabellen FruitInBaskets
             Enklast!
             */
            return _context
                .FruitInBaskets
                .Where(f => f.BasketId == basketId)
                .Select(x=>x.Fruit);
        }
    }
}
