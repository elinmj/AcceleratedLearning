using System;

namespace Blogg
{
    class Program
    {
        readonly string s = "b";

        static void Main(string[] args)
        {
            var app = new App();
            app.Run();

            Console.ReadKey();
        }
    }
}
