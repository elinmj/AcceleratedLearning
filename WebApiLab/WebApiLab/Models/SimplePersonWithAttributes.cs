using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLab.Models
{
    public class SimplePersonWithAttributes
    {
        [Required(ErrorMessage = "Namn obligatoriskt")]
        [RegularExpression(@"^(?i)[A-Z,Å,Ä,Ö,-]{1,20}$", ErrorMessage = "Namnet måste vara under 20 bokstäver")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ålder obligatoriskt")]
        [Range(1, 120, ErrorMessage = "Ålder mellan 0 och 120")]
        public int? Age { get; set; }
    }
}
