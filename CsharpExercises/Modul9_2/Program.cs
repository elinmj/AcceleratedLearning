using System;
using System.IO;

namespace Modul9_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Project\statistisc.txt";
            Console.WriteLine("You are monitoring the filepath Project");
            File.CreateText(path);
            var watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Project";
            watcher.EnableRaisingEvents = true;
            watcher.Created += FileCreated;
            watcher.Deleted += FileDeleted;
            watcher.Changed += FileChanged;
            watcher.Renamed += FileRenamed;



            Console.ReadKey();

        }


        private static void FileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.Name} is created");
        }

        private static void FileDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.Name} is removed");
        }

        private static void FileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.Name} is changed");
        }

        private static void FileRenamed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.Name} is renamed");
        }
    }
}