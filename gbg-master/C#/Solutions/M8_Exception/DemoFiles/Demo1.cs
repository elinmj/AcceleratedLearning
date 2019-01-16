using System;
using System.IO;

namespace M8_Exception.DemoFiles
{
    public class Demo1
    {
        public void Run()
        {

            try
            {
                File.CreateText(@"c:\aaaaaaaa.txt"); 

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Något fel på filnamnet!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Du har inte rättighet att skapa en fil här!");
            }

        }
    }
}
