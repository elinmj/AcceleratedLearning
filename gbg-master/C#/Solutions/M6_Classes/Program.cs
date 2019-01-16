using System;
using CommonStuff;

namespace M6_Classes
{
    public class Program 
    {
        public static void Main()
        {
            ConsoleHelper ch = new ConsoleHelper();
            ch.InitConsole();

            //new DemoClasses.Demo0().Run();
            //new DemoClasses.Demo1().Run();
            //new DemoClasses.Demo2().Run();
            //new DemoClasses.Demo3().Run();
            //new DemoClasses.Demo4().Run();

            //new DemoEnums.Demo1().Run();
            //new DemoGetter.Demo1().Run();
            //new DemoGetter.Demo2().Run();
            //new DemoGetter.Demo3().Run();
            //new DemoGetter.Demo4().Run();

            //new DemoSetter.Demo1().Run();
            //new DemoSetter.Demo2().Run();
            //new DemoSetter.Demo3().Run();
            //// 6.1 och 6.2
            //CreateObjectLab.Run();

            //// 6.3 Override ToString
            //ToStringLab();

            //// 6.4 Enums
            EnumLab.Run();

            //// 6.5 Get accessor + 6.6 Set accessor
            //GetAccessorLab.Run();
            //SetAccessorLab.Run();

            //ch.EndProgram();
        }


    }
}
