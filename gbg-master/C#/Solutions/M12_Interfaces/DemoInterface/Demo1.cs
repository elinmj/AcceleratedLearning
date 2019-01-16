
namespace M12_Interfaces.DemoInterface
{
    // yxa, svärd, bröd, mus, häst

    // djur

    // packa ner

    // Klass Animal
    // IPackable        PutInBag
    // IDangerous       GiveDamage

    // Axe              IPackable, IDangerous
    // Sword            IPackable, IDangerous
    // Bread            IPackable
    // Mouse            IPackable, Animal 
    // Horse            Animal

    // PutStuffInBag       Förväntar sig en Lista av IPackable

    public class Demo1
    {
        interface IPackable
        {
            void PutInBag();
        }

        interface IDangerous
        {
            void GiveDamage();
        }
        class Animal
        {
            public void SayHello()
            {
            }
        }

        class Axe : IPackable, IDangerous
        {
            public void PutInBag()
            {

            }

            public void GiveDamage()
            {
            }
        }

        class Sword : IPackable, IDangerous
        {
            public void PutInBag()
            {

            }

            public void GiveDamage()
            {
            }
        }

        class Bread : IPackable
        {
            public void PutInBag()
            {
            }
        }

        class Mouse : Animal, IPackable
        {
            public void PutInBag()
            {
            }
        }


        class Horse : Animal
        {

        }

        void PutStuffInBag(IPackable x)
        {
            x.PutInBag();
        }

        void Greet(Animal a)
        {
            a.SayHello();
        }

        public void Run()
        {
            Greet(new Animal());
            Greet(new Mouse());
            Greet(new Horse());
            //Greet(new Bread()); // Funkar inte
            //Greet(new Axe());   // Funkar inte
            //Greet(new Sword()); // Funkar inte

            PutStuffInBag(new Axe());

            //PutStuffInBag("sssssss");    // Funkar inte 
            //PutStuffInBag(123);          // Funkar inte 
            PutStuffInBag(new Bread());
            PutStuffInBag(new Mouse());
            // Funkar inte ==> PutStuffInBag(new Horse());

        }
    }
}
