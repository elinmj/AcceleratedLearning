using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLab.Controllers 
{
    [Route("webapi3")]
    public class WebApi3Controller : Controller
    {

        [Route("Frukost")]
        public IActionResult Frukost(string frukost)
        {
            string message;

            //Gör hellre såhär. Och sedan en ifsats
            //if (string.IsNullOrWhiteSpace(frukost))
            //{
            //    message = "Skriv in din frukostmat";
            //}

            switch (frukost.ToLower())
            {
                case "Mango":
                    message = "Mango är gott!";
                    break;
                case null:
                    message = "Skriv in din frukostmat";
                    break;
                default:
                    message = frukost + " är äckligt";
                    break;
            }

            return Ok(message);
        }

        [Route("Kvadrera")]
        public IActionResult Kvadrera(int kvadrera)
        {
            return Ok(kvadrera*kvadrera);
        }


        [Route("Lista")]
        public IActionResult Lista(int från, int till)
        {
            List<int> nummerLista = new List<int>(); 

            for (int i = från; i <= till; i++)
            {
                nummerLista.Add(i);
            }
            string nyLista = string.Join(',', nummerLista);
            return Ok(nyLista);
        }
    }
}
