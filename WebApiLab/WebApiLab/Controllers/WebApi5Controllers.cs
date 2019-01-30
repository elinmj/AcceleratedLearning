using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLab.Models;

namespace WebApiLab.Controllers
{
    [Route("webapi5")]
    public class WebApi5Controllers : Controller
    {
        [Route("AddPersonValidate")]
        public IActionResult AddPersonValidate(SimplePersonWithAttributes person)
        {
            if (ModelState.IsValid)
            {
                return Ok($"{person.Name}, som är {person.Age} år, lades till i databasen");
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [Route("AddPerson")]
        public IActionResult AddPerson(SimplePerson person)
        {

            if (string.IsNullOrEmpty(person.Name))
            {
                return BadRequest("Du måste ange namn och ålder");
            }
            else if (person.Age < 0 || person.Age > 120 && person.Name.Length > 20)
            {
                return BadRequest("Åldern måste vara mellan 0 och 120 och namnet får inte vara längre än 20 tecken");
            }
            else if (person.Name.Length > 20)
            {
                return BadRequest("Namnet får inte vara längre än 20 tecken");
            }
            else if (person.Age <= 0 || person.Age > 120)
            {
                return BadRequest("Åldern måste vara mellan 0 och 120");
            }
            else
            {
                return Ok($"{person.Name}, som är {person.Age} år, lades till i databasen");
            }
        }
    }
}
