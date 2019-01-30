using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekdayApp.Controllers
{
    public class WeekdayController : Controller
    {
        [HttpGet("api/weekday")]
        public IActionResult Weekday(Document document)
        {
            List<string> list = new List<string>() { "sv", "en", "es", "fr" };

            if (document.Search)
            {
                if (document.Language.Length != 2)
                {
                    return BadRequest("Språkkoden är alltid två bokstäver");
                }
                else if (!list.Contains(document.Language))
                {
                    return BadRequest("Språkkoden återfinns tyvärr inte i listan");
                }
                else
                {
                    CultureInfo culture = new CultureInfo(document.Language);
                    return Ok(DateTime.Now.ToString("dddd", culture));
                } 
            }
            else
            {
                return Ok("Jaja, välkommen tillbaka");
            }
            
        }
        
    }
}
