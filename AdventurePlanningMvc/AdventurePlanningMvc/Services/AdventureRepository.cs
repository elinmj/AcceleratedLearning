using AdventurePlanningMvc.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventurePlanningMvc.Services
{
    public class AdventureRepository : IAdventureRepository
    {
        private IHostingEnvironment _env;

        public AdventureRepository(IHostingEnvironment env)
        {
            _env = env;
        }

        public List<Adventure> GetAll()
        {
            string name = _env.ContentRootPath;
            string filename = Path.Combine(name, "Data", "adventures.txt");
            string[] allAdv = File.ReadAllLines(filename);
            List<Adventure> advList = new List<Adventure>();

            foreach (var item in allAdv)
            {
                Adventure adv = new Adventure();
                string[] tmpArray = item.Split(',');
                adv.Id = int.Parse(tmpArray[0]);
                adv.Name = tmpArray[1];
                adv.Description = tmpArray[2];
                adv.Type = tmpArray[3];
                adv.Location = tmpArray[4];
                adv.Days = int.Parse(tmpArray[5]);
                adv.Date = DateTime.Parse(tmpArray[6]);

                advList.Add(adv);
            }

            return advList;
        }

        public Adventure GetById(int id)
        {
            List<Adventure> advList = GetAll();

            //Kan också byta ut Where mot Single. Det är coolare. COOLAST: return GetAll().Single(x => x.Id == v);
            Adventure adv = advList.Where(x => x.Id == id).Single();

            return adv;

        }

        public void Add(Adventure adv)
        {
            List<Adventure> advList = GetAll();
            string name = _env.ContentRootPath;
            string filename = Path.Combine(name, "Data", "adventures.txt");

            using (StreamWriter file =
                new StreamWriter(filename, true))
            {
                file.WriteLine((advList.Count + 1) + ", " + adv.Name + ", " + adv.Description + ", " + adv.Type + ", " + adv.Location + ", " + adv.Days + ", " + adv.Date);

            }
        }

        public void GetLocation(string location)
        {
            throw new NotImplementedException();
        }
    }
}
