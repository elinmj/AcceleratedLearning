using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InförCheckpoint6
{
    class DataAccess
    {
        private readonly Context _context;

        public DataAccess()
        {
            _context = new Context();
        }

        internal void LägginSkidåkareOchSkidåkTyp()
        {
            //var typ1 = new SkidåkTyp();
            //typ1.typ = "Längd";

            //var typ2 = new SkidåkTyp();
            //typ2.typ = "Alpint";

            var typ3 = new SkidåkTyp();
            typ3.typ = "Barmark";

            //_context.SkidåkTyps.Add(typ1);
            //_context.SkidåkTyps.Add(typ2);
            _context.SkidåkTyps.Add(typ3);


            var s2 = new Skidåkare()
            {
                Förnamn = "Jan",
                Efternamn = "Johansson",
                SkidåkTyps = new List<SkidåkTyp> { typ3 }
            };

            _context.Skidåkares.Add(s2);

            _context.SaveChanges();


        }

        internal List<SkidåkTyp> HämtaSkidåkTyp()
        {
            return _context.SkidåkTyps.ToList();
        }

        internal List<Skidåkare> HämtaSkidåkare()
        {
            return _context.Skidåkares.ToList();
        }
    }
}
