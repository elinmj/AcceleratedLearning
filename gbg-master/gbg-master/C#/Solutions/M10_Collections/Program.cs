using CommonStuff;

namespace M10_Collections
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleHelper ch = new ConsoleHelper();
            ch.InitConsole(50, 15);

            //new DemoDictionary.Demo1().Run();

            //// 10.1 till 10.4
            new ListLab().Run();

            //// 10.5 och 10.6
            //new DictionaryLab().Run();

            ch.EndProgram();
        }
    }
}
