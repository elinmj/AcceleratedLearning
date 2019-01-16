// Syfte: skapa en lista av djur. Här går det att anropa SayHello på alla djur

using System.Collections.Generic;
using System;

namespace M7_Inheritance.DemoInheritance
{
    public class Demo3
    {

        abstract class Animal
        {
            public abstract void SayHello();
        }

        class Dog : Animal
        {
            public override void SayHello()
            {
                Console.WriteLine("Voff!");
            }
        }

        class Cat : Animal
        {
            public override void SayHello()
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
                a.SayHello();
            }

        }
    }
}
