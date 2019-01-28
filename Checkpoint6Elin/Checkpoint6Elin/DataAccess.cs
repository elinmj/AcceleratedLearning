using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace Checkpoint6Elin
{
    public class DataAccess
    {
        private readonly SpaceContext _context;

        public DataAccess()
        {
            _context = new SpaceContext();
        }

        internal void AddSpaceship(string spaceship)
        {
            var s = new Spaceship();
            s.Name = spaceship;
            _context.Spaceships.Add(s);
            _context.SaveChanges();
        }

        internal List<Spaceship> GetAllSpaceShips()
        {
            return _context.Spaceships.ToList();
            
        }

        internal void AddRavioliForSpaceship(string spaceship, int ravioli, string packdate)
        {
            foreach (var ship in _context.Spaceships.ToList())
            {
                if (ship.Name == spaceship)
                {
                    ship.Ravioli = ravioli;
                    DateTime newPackdate = DateTime.Parse(packdate);
                    ship.PackDateRavioli = newPackdate;
                    DateTime bestBeforeRavioli = newPackdate.AddMonths(6); //Adderar 6 månader vilket är fel. Läste fel i uppgiften.
                    ship.BestBeforeRavioli = bestBeforeRavioli;
                }
            }

            _context.SaveChanges();

        }
    }
}
