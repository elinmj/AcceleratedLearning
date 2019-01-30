using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLab.Controllers
{
    [Route("webapi4")]
    public class WebApi4Controllers : Controller
    {
        [Route("Choklad")]
        public IActionResult Choklad(int personer)
        {
            if (personer <= 0)
            {
                return BadRequest("Måste vara över 0!");
            }
            else
            {
                return Ok($"Alla får {25/personer} bitar!");
            }
        }

        [Route("Order")]
        public IActionResult Order(string order)
        {

            //Oscar har lagt upp lösningen under WebApi/webApi4
            string rgx = @"^[A-Ö]{2}-[0-9]{4}$";
            string[] split = order.Split('-');
            int number = int.Parse(split[1]);


            if (order != rgx)
            {
                return BadRequest("Fel format");
            }
            else if (number>3000)
            {
                return NotFound();
            }
            else
            {
                return Ok($"Order {order} hittades i databasen");
            }
        }

        [Route("Användarnamn")]
        public IActionResult Användarnamn(string användarnamn)
        {
            string img;
            if (användarnamn.ToLower() == "stewie")
            {
                return BadRequest("ERROR!");
            }
            else
            {

                switch (användarnamn)
                {
                    case "Peter":
                        img = "https://upload.wikimedia.org/wikipedia/commons/c/c7/Explosions.jpg";
                        break;
                    case "Lois":
                    case "Meg":
                    case "Brian":
                        img = "https://eumerch.bethesda.net/media/image/9f/a3/2c/FALLOUT_4_CAR_DECAL_THUMBS_UP_VAULT_BOY_0005_600x600.png";
                        break;
                    default:
                        img = "https://www.emojirequest.com/images/ThumbsDownEmoji.jpg";
                        break;
                }


                string html = $"<html><body><img src ={img}></body></html>";
                return Content(html, "text/html");
            }
        }
    }

}
