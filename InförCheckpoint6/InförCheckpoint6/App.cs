using System;
using System.Collections.Generic;
using System.Text;

namespace InförCheckpoint6
{
    public class App
    {
        internal void Run()
        {
            //LägginSkidåkareOchSkidåkTyp();
            VisaSkidåkare();
        }

        private void VisaSkidåkare()
        {
            var dataAccess = new DataAccess();
            List<Skidåkare> lista = dataAccess.HämtaSkidåkare();
            List<SkidåkTyp> lista2 = dataAccess.HämtaSkidåkTyp();

            List<string> nylista = new List<string>();

            foreach (var item in lista)
            {
                if (item.Id == lista2[0].SkidåkareId)
                {
                    nylista.Add(lista[0].Förnamn);
                    nylista.Add(lista[0].Efternamn);
                    nylista.Add(lista2[0].typ);
                }

            }
            
                Console.WriteLine($"Skidåkare: {nylista[0]} {nylista[1]} {nylista[2]}");
            

            //foreach (var item in lista)
            //{
            //    Console.WriteLine($"Skidåkare: {item.Förnamn} {item.Efternamn}\nÅker: {item.SkidåkTyps[0]} och {item.SkidåkTyps[1]}");
            //}

            Console.ReadKey();
        }

        private void LägginSkidåkareOchSkidåkTyp()
        {
            var dataAccess = new DataAccess();
            dataAccess.LägginSkidåkareOchSkidåkTyp();
        }
    }
}
