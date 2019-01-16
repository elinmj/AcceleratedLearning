// Syfte: skapa en lista av djur. Men visa att det är svårt att anropa gemensamma metoder
using System.Collections.Generic;
using System;

namespace M7_Inheritance.DemoInheritance
{
    public class Demo2
    {

        class Animal
        {
        }

        class Dog : Animal
        {
            public void SayHello()
            {
                Console.WriteLine("Voff!");
            }
        }

        class Cat : Animal
        {
            public void SayHello()
            {
                Console.WriteLine("Go away!");
            }
        }


        public void Run()
        {
            List<Animal> animals = new List<Animal>();
            var d1 = new Dog();
            var d2 = new Dog();
            var d3 = new Dog();
            var c1 = new Cat();
            var c2 = new Cat();

            animals.Add(d1);
            animals.Add(d2);
            animals.Add(d3);
            animals.Add(c1);
            animals.Add(c2);

            foreach (Animal a in animals)
            {
                // a.SayHello(); => funkar inte :(
            }

        }
    }
}
