using CommonStuff;

namespace M8_Exception
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleHelper ch = new ConsoleHelper();
            ch.InitConsole(80,20);

            //new DemoException.Demo1().Run();
            //new DemoException.Demo2().Run();
            //new DemoFiles.Demo1().Run();

            // 8.1 Dividing chocolate
            //new ExceptionChocolate().Run();

            //// 8.2 Files and exceptions
            //ExceptionFile.Run();

            //// 8.3 Animals in a list
            new ExceptionAnimal().Run();

            ch.EndProgram();
        }

    }
}
