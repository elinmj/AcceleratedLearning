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

        private static void AskForUsersName()
        {
            Console.WriteLine("Asking for users name...");
        }

        private static void PlayGame()
        {
            Console.WriteLine("Playing the game...");
            DisplayMaskedWord();
            AskForLetter();
        }

        private static void DisplayMaskedWord()
        {
            Console.WriteLine("Display masked word...");
        }

        private static void AskForLetter()
        {
            Console.WriteLine("Asking for letter..");
        }

        private static void EndGame()
        {
            Console.WriteLine("Game over...");
        }

    }
}
