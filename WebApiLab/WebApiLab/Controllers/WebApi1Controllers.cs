using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApiLab.Controllers
{
    [Route("webapi1")]
    public class WebApi1Controller : Controller
    {

        //[Route("GetPlanet")]
        //public IActionResult GetPlanet()
        //{

        //    string formContent = "";
        //    using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
        //    {
        //        formContent = reader.ReadToEndAsync().Result;
        //    }

        //    // Du behöver göra "Planet"-klassen och metoden "ParsePlanet"
        //    Planet planet = ParsePlanetGet(formContent);

        //    //return Ok("Söker i databasen efter planeter med namn " + <%= Request.QueryString("Planet") %> + " och storlek " + <%= Request.QueryString("Size") %>);
        //}

        [HttpGet("GetPlanet2")]
        public IActionResult GetPlanet2(Planet planet)
        {
            return Ok("Söker i databasen efter planeter med namn " + planet.Name +" och storlek " + planet.Size );
        }


        private Planet ParsePlanetGet(string formContent)
        {
            Planet planet = new Planet();

            string[] form = formContent.Split('&');

            planet.Name = form[0].Remove(0, 8);

            planet.Size = int.Parse(form[1].Remove(0, 5));

            return planet;
        }

        //[Route("AddPlanet")]
        //public IActionResult AddPlanet()
        //{
        //    string formContent = "";
        //    using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
        //    {
        //        formContent = reader.ReadToEndAsync().Result;
        //    }

        //    // Du behöver göra "Planet"-klassen och metoden "ParsePlanet"
        //    Planet planet = ParsePlanet(formContent);

        //    return Ok("Ny planet " + planet.Name + " skapad med storleken " + planet.Size);
        //}

        [Route("AddPlanet2")]
        public IActionResult AddPlanet2(Planet planet)
        {
            return Ok("Ny planet " + planet.Name + " skapad med storleken " + planet.Size);
        }

        private Planet ParsePlanet(string formContent)
        {
            Planet planet = new Planet();

            string[] form = formContent.Split('&');

            planet.Name = form[0].Remove(0,7);

            planet.Size = int.Parse(form[1].Remove(0,5));

            return planet;
        }
    }
}
