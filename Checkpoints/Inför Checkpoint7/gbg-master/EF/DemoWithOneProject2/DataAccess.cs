using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DemoWithOneProject2
{
    public class DataAccess 
    {
        private readonly FruitContext _context;

        public List<string> ChangeTrackerLog { get; } = new List<string>();

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

           // Alternativt: _context.RemoveRange(_context.Fruits);

            _context.SaveChanges();
        }

        public void AddCategoriesAndFruits()
        {
            var skenfrukt = new FruitCategory { Name = "Skenfrukt" };
            var torrÄkta = new FruitCategory { Name = "Torr äkta frukt" };
            var saftigÄkta = new FruitCategory { Name = "Saftig äkta frukt" };

            // Behövs inte:
            //_context.FruitCategories.Add(skenfrukt);
            //_context.FruitCategories.Add(torrÄkta);
            //_context.FruitCategories.Add(saftigÄkta);

            _context.Fruits.Add(new Fruit { Name = "Ananas", Category = skenfrukt, Price = 10.3M });
            _context.Fruits.Add(new Fruit { Name = "Nypon", Category = skenfrukt, Price = 2 });

            _context.Fruits.Add(new Fruit { Name = "Körsbär", Category = saftigÄkta, Price = 55 });
            _context.Fruits.Add(new Fruit { Name = "Mandel", Category = saftigÄkta, Price = 42 });

            _context.Fruits.Add(new Fruit { Name = "Ärtor", Category = torrÄkta, Price = 30 });
            _context.Fruits.Add(new Fruit { Name = "Kikärtor", Category = torrÄkta, Price = 100 });

            _context.SaveChanges();

        }

        public void AddCategoriesAndFruits_ChangeTracker()
        {
            var skenfrukt = new FruitCategory { Name = "Skenfrukt" };
            var torrÄkta = new FruitCategory { Name = "Torr äkta frukt" };
            var saftigÄkta = new FruitCategory { Name = "Saftig äkta frukt" };

            // Changetrackern innehåller inte nåt
            ChangeTrackerLog.Add("Log1");
            ChangeTrackerLog.AddRange(GetChangeTrackerEntries()); 

            var ananas = new Fruit {Name = "Ananas", Category = skenfrukt, Price = 10.3M};
            _context.Fruits.Add(ananas);
            ananas.Name = "ANANANANAS";
            _context.Fruits.Add(new Fruit { Name = "Nypon", Category = skenfrukt, Price=2 });

            // Ananas räknas ändå som Added och inte Modified
            // Två frukter och en kategori har lagts till (changetrackern har tre objekt)
            ChangeTrackerLog.Add("Log2"); 
            ChangeTrackerLog.AddRange(GetChangeTrackerEntries()); 

            _context.Fruits.Add(new Fruit { Name = "Körsbär", Category = saftigÄkta, Price=55 });
            _context.Fruits.Add(new Fruit { Name = "Mandel", Category = saftigÄkta, Price=42 });
            _context.Fruits.Add(new Fruit { Name = "Ärtor", Category = torrÄkta, Price=30 });
            var kikärtor = new Fruit {Name = "Kikärtor", Category = torrÄkta, Price = 100};
            _context.Fruits.Add(kikärtor);

            // Flera frukter och kategorier läggs till
            ChangeTrackerLog.Add("Log3");
            ChangeTrackerLog.AddRange(GetChangeTrackerEntries());

            _context.Fruits.Remove(kikärtor);

            // Här har kikärtor tagits bort helt från changetracker'n!
            ChangeTrackerLog.Add("Log4");
            ChangeTrackerLog.AddRange(GetChangeTrackerEntries()); 

            _context.SaveChanges();

            // Objekten har fått id på sig och är nu satt till  "Unchanged"
            ChangeTrackerLog.Add("Log5");
            ChangeTrackerLog.AddRange(GetChangeTrackerEntries()); 

            _context.SaveChanges();

            var mandel = _context.Fruits.Single(f => f.Name == "Mandel");
            mandel.Name = "MANDEL";

            // Mandeln är nu satt till "Modified"
            ChangeTrackerLog.Add("Log6");
            ChangeTrackerLog.AddRange(GetChangeTrackerEntries()); 

            _context.SaveChanges();

            // Nu är alla entiteter satt till "Unchanged" igen
            ChangeTrackerLog.Add("Log7");
            ChangeTrackerLog.AddRange(GetChangeTrackerEntries());

        }


        private List<string> GetChangeTrackerEntries()
        {
            return _context.ChangeTracker.Entries().Select(entry => GetId(entry.Entity) + "   " + entry.Entity.GetType().Name+ ": " + entry.State.ToString()).ToList();
        }

        private int GetId(object entry)
        {
            var fruit = entry as Fruit;
            var fruitCategory = entry as FruitCategory;
            if (fruit != null)
                return fruit.Id;
            if (fruitCategory != null)
                return fruitCategory.Id;
            throw new Exception();
        }

        public IEnumerable<Fruit> GetAll()
        {
            return _context.Fruits.Include(x=>x.Category);
        }

        public List<Fruit> GetFruitsInCategory(string categoryName)
        {
            return _context.FruitCategories
                       .Include(x => x.Fruits)
                       .SingleOrDefault(x => x.Name == categoryName)
                       ?.Fruits.ToList() ?? new List<Fruit>();
        }

        public IEnumerable<Fruit> GetFruitsInCategory_Alternative(string categoryName)
        {
            return _context.Fruits
                .Where(x => x.Category.Name == categoryName);
        }
    }
}
