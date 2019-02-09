using System;
using System.IO;

namespace M9_Events.DemoWatcher
{
    public class Demo1
    {
        public void Run()
        {
            var watcher = new FileSystemWatcher();
            watcher.Path = @"C:\TMP";
            watcher.EnableRaisingEvents = true;

            watcher.Created += EnFilÄrSkapad;

            Console.ReadKey();
        }

        private void EnFilÄrSkapad(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.Name + " skapades!");
        }
    }
}
