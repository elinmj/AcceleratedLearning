using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRootApp.Controllers
{
    public class SquareRootController : Controller
    {
        [HttpGet("api/squareroot")]
        public IActionResult SquareRoot (int? number)
        {
            if (number < 0)
            {
                return BadRequest("Går inte att ta roten ur ett negativt tal.");
            }
            if (number == null )
            {
                return BadRequest("Ange ett tal!");
            }
            return Ok(Math.Sqrt((int)number));
        }
        
    }
}
