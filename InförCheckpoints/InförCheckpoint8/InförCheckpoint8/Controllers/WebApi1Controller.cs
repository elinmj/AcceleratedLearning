using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InförCheckpoint8.Controllers
{
    [Route("webapi1")]
    public class WebApi1Controller : Controller
    {
        [Route("AddPlanet")]
        public IActionResult AddPlanet()
        {
            string formContent = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                formContent = reader.ReadToEndAsync().Result;
            }

            // Du behöver göra "Planet"-klassen och metoden "ParsePlanet"
            Planet planet = ParsePlanet(formContent);

            return Ok("Ny planet " + planet.Name + " skapad med storleken " + planet.Size);
        }

        private Planet ParsePlanet(string formContent)
        {
            Planet planet = new Planet();
            var array = formContent.Split('&');
            var newArray = [];
            for (int i = 0; i < array.Length; i++)
            {
                newArray.push(array[i].Split('='));
            }

            planet.Name = array[1];
            planet.Size = int.Parse(array[4]);

            return planet;
        }
    }
}
