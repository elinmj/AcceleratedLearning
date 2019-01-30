using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLab.Controllers
{
    [Route("webapi2")]
    public class WebApi2Controller : Controller
    {

        //Returnera gärna på detta sätt istället. IActionResult. Det som är utkommenterat.
        //[Route("Helloworld")]
        //public IActionResult Helloworld()
        //{
        //    return Ok("Hello World");
        //}

        [Route("Helloworld")]
        public string Helloworld()
        {
            return "Hello World";
        }

        [Route("Veckodag")]
        public string Veckodag()
        {
            string dag = DateTimeFormatInfo.CurrentInfo.GetDayName(DateTime.Now.DayOfWeek);
            return "Idag är det " + dag;
        }

        [Route("Dagens floskel")]
        public string DagensFloskel()
        {
            string dag = DateTimeFormatInfo.CurrentInfo.GetDayName(DateTime.Now.DayOfWeek);
            string floskel;

            //Använd hellre en switch
           
            if (dag == "måndag")
            {
                floskel = "Måndagströttheten har slagit till?";
            }
            else if (dag == "tisdag")
            {
                floskel = "Bollen är rund";
            }
            else if (dag == "onsdag")
            {
                floskel = "Livet går vidare";
            }
            else if (dag == "torsdag")
            {
                floskel = "Idag är det högt i tak!";
            }
            else if (dag == "fredag")
            {
                floskel = "Kunden i centrum";
            }
            else if (dag == "lördag")
            {
                floskel = "Tiden läker alla sår, även på lördagar";
            }
            else
            {
                floskel = "Söndagsångest?";
            }

            return floskel;
        }
    }
}
