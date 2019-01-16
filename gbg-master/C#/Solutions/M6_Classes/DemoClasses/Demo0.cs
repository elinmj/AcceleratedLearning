// todo: gör övningar av dessa filer!

// Syfte: visa hur dåligt det blir om inte klasser används

using System;

namespace M6_Classes.DemoClasses
{
    public class Demo0
    {
        public void Run()
        {
            string car1Color = "röd";
            int car1Weight = 1300;

            string car2Color = "blå";
            int car2Weight = 800;

            Console.WriteLine("Färgen på bilen 'car1' är " + car1Color + " och dess vikt är " + car1Weight);
            Console.WriteLine("Färgen på bilen 'car2' är " + car2Color + " och dess vikt är " + car2Weight);
            Console.WriteLine();

        }
    }
}
