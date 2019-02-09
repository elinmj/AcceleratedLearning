

using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWithOneProject2
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public FruitCategory Category { get; set; }

        [Column("Sweetness", TypeName = "varchar(10)")] // Kolumnen får nytt namn med en bestämd typ. TypeName kollas inte vid migrering (Add-Migration) men det blir fel i Update-Database om datatypen inte finns
        public string Sötma { get; set; }
    }
}