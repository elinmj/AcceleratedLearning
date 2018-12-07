namespace M7_Inheritance.DemoInheritance
{
    public class Demo1
    {

        class Animal
        {

        }

        class Mamal : Animal
        {
            public string Name { get; set; }
            public int NrOfPaws { get; set; }
        }

        class Cat : Mamal
        {
            public string FavoriteCatFood { get; set; }
        }

        class Dog : Mamal
        {
            public int BarkLevel { get; set; }
        }

        public void Run()
        {
            var myMamal = new Mamal();
            var myDog = new Dog();
        }
    }
}
