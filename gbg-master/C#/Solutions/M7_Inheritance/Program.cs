using CommonStuff;

namespace M7_Inheritance
{
    public class Program
    {
        public static void Main()
        {
            ConsoleHelper ch = new ConsoleHelper();

            ch.InitConsole();

            // 7.1, 7.2 och 7.3
            new InheritanceLab().Run();

            ch.EndProgram();

        }


    }
}
