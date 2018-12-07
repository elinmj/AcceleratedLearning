using System;
using System.IO;

namespace M9_Events
{
    public class WatchFiles
    {
        public void Run()
        {
            var watchingPath = @"C:\TMP";
            var watcher = new FileSystemWatcher(); 
            watcher.Path = watchingPath;
            watcher.EnableRaisingEvents = true;

            watcher.Changed += FileChanged;

            watcher.Deleted += FileDeleted;
            watcher.Deleted += FileDeleted2;

            watcher.Renamed += FileRenamed;
            watcher.Created += FileCreated;

            Console.WriteLine($"I'm watching this folder: '{watchingPath}'");
            Console.ReadKey();

        }

        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.Name} created");
        }

        private void FileRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"File {e.Name} renamed");
        }

        private void FileDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.Name} removed");
        }

        private void FileDeleted2(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("bla bla");
        }

        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.Name} changed");
        }
    }
}
