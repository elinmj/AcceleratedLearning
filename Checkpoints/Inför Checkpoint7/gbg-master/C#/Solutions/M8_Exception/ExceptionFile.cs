using CommonStuff;
using System;
using System.IO;

namespace M8_Exception
{
    public static class ExceptionFile
    {
        public static void Run()
        {
            ConsoleHelper ch = new ConsoleHelper();
            
            while(true)
            {
                string filename = ch.AskForString("Enter a file name:");
                bool success = CreateTextfile(filename);

                if (success)
                    break;

            } 
        }

        private static bool CreateTextfile(string filename)
        {
            ConsoleHelper ch = new ConsoleHelper();
            try
            {
                File.CreateText(filename);
                Console.WriteLine($"The file '{filename}' is now created");
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                ch.ErrorMessage("You're not authorized to create this file");
            }
            catch (DirectoryNotFoundException)
            {
                ch.ErrorMessage("Directory not found");
            }
            catch (IOException)
            {
                ch.ErrorMessage("Input output exception");
            }
            catch (ArgumentException)
            {
                ch.ErrorMessage("The filename is not valid");
            }
            catch (Exception)
            {
                ch.ErrorMessage($"Something strange happened");
            }
            return false;
        }

    }
}
