using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApiLab.Controllers
{
    [Route("webapi0")]
    public class WebApi0Controller : Controller
    {
        //Ärver från Controller, inte controllers. Då skappas rätt using. 


        [Route("kalle")]
        public string Kalle()
        {
            return "Hej från servern!";
        }

        [Route("kalle2")]
        public string Kalle2()
        {
            return "Klockan är" + DateTime.Now;
        }

        [Route("kalle3")]
        public int Kalle3()
        {
            int i = 10 + 32;
            return i;
        }

        //HttpPost och HttpGet
        [Route("kalle4"), HttpGet]
        //Kan också skriva
        [HttpGet ("kalle4")]
        public IActionResult Kalle4()
        {
            //Innanför Ok kan vara vad som helst. Det ska vara okej om det "går bra". Under är NotFound. Det finns fler.
            //return Ok(66);
            //return NotFound();
            return Ok("Klockan är " + DateTime.Now); 
        }
    }
}
