using System.Collections.Generic;

namespace DemoWithOneProject3
{
    public class Basket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FruitInBasket> FruitInBaskets { get; set; }
    }
}
