

using System.Collections.Generic;

namespace DemoWithOneProject3
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public FruitCategory Category { get; set; }
        public List<FruitInBasket> FruitInBaskets { get; set; }
    }
}
