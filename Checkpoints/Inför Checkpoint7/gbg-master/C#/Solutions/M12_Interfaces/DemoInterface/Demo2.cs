using System;

namespace M12_Interfaces.DemoInterface
{
    public class Demo2
    {
        
        class Animal
        {
            public void Hello()
            {
                Console.WriteLine("I'm an animal!");
            }
        }

        class Dog : Animal
        {

        }

        class Cat : Animal, IPackable
        {
            public string PutInBag(int xxx)
            {
                throw new NotImplementedException();
            }
        }

        interface IPackable
        {
            string PutInBag(int xxx);
        }

        class Bread : IPackable
        {
            public string PutInBag(int yyy)
            {
                throw new NotImplementedException();
            }
        }

        void DoStuff(Animal a)
        {
        }

        void DoStuff2(IPackable a)
        {
            string yyy = a.PutInBag(123);
        }

        void Run()
        {
            var a1 = new Animal();
            a1.Hello();

            var dog1 = new Dog();
            dog1.Hello();

            var cat1 = new Cat();

            var bread1 = new Bread();

            DoStuff(dog1);
            DoStuff(cat1);
            DoStuff(bread1);

            DoStuff2(dog1);
            DoStuff2(cat1);
            DoStuff2(bread1);

        }
    }
}
