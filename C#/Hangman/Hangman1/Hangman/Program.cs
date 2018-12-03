using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
            PlayGame();
            EndGame();
        }

        private static void StartGame()
        {
            Console.WriteLine("Starting the game...");
            AskForUsersName();
        }

        static void AskForUsersName()
        {
            Console.WriteLine("Asking user for name...");
        }

        private static void PlayGame()
        {
            Console.WriteLine("Playing the game...");
            DisplayMaskedWord();
            AskForLetter();
        }

        static void DisplayMaskedWord()
        {
            Console.WriteLine("Display masked word...");
        }

        static void AskForLetter()
        {
            Console.WriteLine("Asking for letter..");
        }

        private static void EndGame()
        {
            Console.WriteLine("Game over...");
        }

    }
}
