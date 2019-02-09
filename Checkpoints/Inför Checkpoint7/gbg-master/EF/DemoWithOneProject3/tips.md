# Tips

## FruitInBasket

Skapa en mellanklass *FruitInBasket* 

    public class FruitInBasket
    {
        public int FruitId { get; set; }
        public Fruit Fruit { get; set; }

        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }

## AddCategoriesAndFruits


Lägg till en frukt i en korg:

    b1.FruitInBaskets.Add(new FruitInBasket
    {
        Fruit = nypon
    });

## GetAllFruitsInBasket

Använd både *Include* och *ThenInclude* 